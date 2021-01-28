






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Zombie entity
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce;
	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.audio;
	using jfcraft.data;
	using jfcraft.item;
	using jfcraft.opengl;
	using jfcraft.move;

	public class Zombie : HumaniodBase
	{
	  private float walkAngle; //angle of legs/arms as walking
	  private float walkAngleDelta;

	  //render assets
	  public static RenderDest dest;
	  private static Texture texture;
	  private static string textureName;
	  private static GLModel model;

	  private static int initHealth = 20;
	  private static int initArmor = 2;

	  public Zombie() : base(1, 4)
	  {
		id = Entities.ZOMBIE;
	  }

	  public override string Name
	  {
		  get
		  {
			return "Zombie";
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
		walkAngleDelta = 5.0f;
		if (world.isServer)
		{
		  ar = initArmor;
		  eyeHeight = 1.3f;
		  jumpVelocity = 0.58f; //results in jump of 1.42
		  //speeds are blocks per second
		  walkSpeed = 4.3f;
		  runSpeed = 5.6f;
		  sneakSpeed = 1.3f;
		  swimSpeed = (walkSpeed / 2.0f);
		  reach = 5.0f;
		  attackRange = 2.0f;
		  attackDelay = 30; //1.5 sec per attack
		  attackDmg = 1.0f;
		  maxAge = 20 * 60 * 15; //15 mins
		}
		Move = new MoveHostile();
	  }

	  public override void initStatic()
	  {
		base.initStatic();
		textureName = "entity/zombie/zombie";
		dest = new RenderDest(parts.Length);
		model = loadModel("zombie");
	  }

	  public override void initStaticGL()
	  {
		base.initStaticGL();
		texture = Textures.getTexture(textureName, 0);
	  }

	  private static string[] parts = new string[] {"HEAD", "BODY", "L_ARM", "R_ARM", "L_LEG", "R_LEG"};

	  public override void bindTexture()
	  {
		texture.bind();
	  }

	  public override void setMatrixModel(int bodyPart, RenderBuffers buf)
	  {
		mat.setIdentity();
		mat.addRotate(-ang.y, 0, 1, 0);
		switch (bodyPart)
		{
		  case HEAD:
			mat.addTranslate(0, buf.org.y, 0);
			mat.addRotate(-ang.x, 1, 0, 0);
			mat.addTranslate2(0, -buf.org.y, 0);
			break;
		  case BODY:
			break;
		  case L_ARM:
			mat.addTranslate(0, buf.org.y, 0);
			mat.addRotate2(90.0f, 1, 0, 0);
			mat.addTranslate2(0, -buf.org.y, 0);
			break;







