






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Player state
	/// 
	/// NOTE : The player is removed from the Chunk on the client side and only exists
	///        in the world entities list.
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.client;
	using jfcraft.item;
	using jfcraft.data;
	using jfcraft.opengl;

	public class Player : HumaniodBase
	{
	  //inventory (first 9 are active items)
	  public string name;

	  public Client client;

	  public int gainedLife, tookHungerDmg;

	  public float walkAngle; //angle of legs/arms as walking
	  public float walkAngleDelta;

	  //would like to move Render Assets to Entity, but it's static!!!
	  //render assets
	  private static RenderDest dest;
	  //texture size
	  private static Texture texture;
	  private static GLModel model;

	  public Player() : base(4 * 9 + 1, 4) //+1 for shield
	  {
		id = Entities.PLAYER;
	  }

	  public override string Name
	  {
		  get
		  {
			return "player";
		  }
	  }

	  public override void init(World world)
	  {
		base.init(world);
		isStatic = true;
		width = 0.6f;
		width2 = width / 2;
		height = 1.6f;
		height2 = height / 2;
		depth = width;
		depth2 = width2;
		eyeHeight = 1.3f;
		jumpVelocity = 0.58f; //results in jump of 1.42
		//speeds are blocks per second
		walkSpeed = 4.3f;
		runSpeed = 5.6f;
		sneakSpeed = 1.3f;
		swimSpeed = (walkSpeed / 2.0f);
		reach = 5.0f;
		walkAngleDelta = 5.0f;
		yDrag = Static.dragSpeed;
		xzDrag = yDrag * 4.0f;
		attackDmg = 1.0f; //base damage (fists)
		attackRange = 5.0f;
		legLength = 0.625f;
		if (Static.debugTest)
		{
		  runSpeed = 25.0f;
		  fastSwimSpeed = 25.0f;
		}
	  }

	  public override void initStatic()
	  {
		model = loadModel("steve");
	  }

	  public override void initStaticGL()
	  {
		base.initStaticGL(); //HumanoidBase
		texture = Textures.getTexture("entity/steve", 0);
		dest = new RenderDest(parts.Length);
	  }

	  public override void tick()
	  {
		if (health > 0 && health < 20 && gainedLife == 0 && hunger >= 18)
		{
		  exhaustion += 3.0f;
		  health++;
		  gainedLife = 4 * 20;
		  client.serverTransport.sendHealth(this);
		}
		else if (gainedLife > 0)
		{
		  gainedLife--;
		}
		if (exhaustion >= 4)
		{
		  exhaustion -= 4;
		  if (saturation > 0)
		  {
			if (saturation < 1)
			{
			  saturation = 0;
			}
			else
			{
			  saturation -= 1;
			}
		  }
		  else if (hunger > 0)
		  {
			if (hunger < 1)
			{
			  hunger = 0;
			}
			else
			{
			  hunger -= 1;
			}
			client.serverTransport.sendHunger(this);
		  }
		}
		if (hunger == 0 && tookHungerDmg == 0)
		{
		  takeDmg(1, null);
		  tookHungerDmg = 4 * 20;
		}
		else if (tookHungerDmg > 0)
		{
		  tookHungerDmg--;
		}
		base.tick();
	  }

	  private static string[] parts = new string[] {"HEAD", "BODY", "L_ARM", "R_ARM", "L_LEG", "R_LEG"};

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		base.buildBuffers(base.Dest, data); //HumanoidBase
		//transfer data into dest
		for (int a = 0;a < parts.Length;a++)
		{
		  RenderBuffers buf = dest.getBuffers(a);
		  GLObject obj = model.getObject(parts[a]);
		  if (obj == null)
		  {
			Console.WriteLine("Warning:Couldn't find part:" + parts[a]);
		  }
		  buf.addVertex(obj.vpl.toArray());
		  buf.addPoly(obj.vil.toArray());
		  int cnt = obj.vpl.size();
		  for (int b = 0;b < cnt;b++)
		  {
			buf.addDefault();
		  }
		  if (obj.maps.size() == 1)
		  {
			GLUVMap map = obj.maps.get(0);







