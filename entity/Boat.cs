






namespace jfcraft.entity
{
	/// <summary>
	/// Boat entity
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.data;
	using jfcraft.client;
	using jfcraft.item;
	using jfcraft.opengl;
	using jfcraft.move;

	public class Boat : VehicleBase
	{
	  //render assets
	  public static Texture texture;
	  private static string textureName;
	  private static GLModel model;
	  private static int initHealth = 5;

	  public float waterSpeed, fastWaterSpeed, landSpeed;
	  public RenderDest dest;

	  public Boat()
	  {
		id = Entities.BOAT;
		health = initHealth;
	  }

	  public override string Name
	  {
		  get
		  {
			return "boat";
		  }
	  }

	  public override RenderDest Dest
	  {
		  get
		  {
			return dest;
		  }
	  }

	  public override void init(World world)
	  {
		base.init(world);
		yDrag = Static.dragSpeed;
		xzDrag = yDrag * 4.0f;
		waterSpeed = 6.2f;
		fastWaterSpeed = 7.0f;
		landSpeed = 0.39f;
		width = 1.0f;
		width2 = width / 2f;
		height = 1.0f;
		height2 = height / 2f;
		depth = 1.0f;
		depth2 = depth / 2f;
		dest = new RenderDest(parts.Length);
		Move = new MoveBoat();
	  }

	  public override void initStatic()
	  {
		base.initStatic();
		textureName = "entity/boat";
		model = loadModel("boat");
	  }

	  public override void initStaticGL()
	  {
		base.initStaticGL();
		texture = Textures.getTexture(textureName, 0);
	  }

	  public override void initInstance()
	  {
		base.initInstance();
	  }

	  private static string[] parts = new string[] {"BASE", "NORTH", "EAST", "SOUTH", "WEST"};


	  public override void bindTexture()
	  {
		texture.bind();
	  }

	  public override void copyBuffers()
	  {
		dest.copyBuffers();
	  }

	  private void setMatrixModel()
	  {
		mat.setIdentity();
		mat.addRotate(-ang.y, 0, 1, 0);
		mat.addTranslate(pos.x, pos.y, pos.z);
		glUniformMatrix4fv(Static.uniformMatrixModel, 1, GL_FALSE, mat.m); //model matrix
	  }

	  public override void render()
	  {
		setMatrixModel(); //all parts share the same matrix
		int cnt = parts.Length;
		for (int a = 0;a < cnt;a++)
		{
		  RenderBuffers buf = dest.getBuffers(a);
		  buf.bindBuffers();
		  buf.render();
		}
		glUniformMatrix4fv(Static.uniformMatrixModel, 1, GL_FALSE, Static.identity.m); //model matrix
	  }






