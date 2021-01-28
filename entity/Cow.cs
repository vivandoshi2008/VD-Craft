






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Cow entity
	/// 
	/// @author vivandoshi
	/// 

	/// </summary>

	using javaforce;
	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.audio;
	using jfcraft.data;
	using jfcraft.move;
	using jfcraft.item;
	using jfcraft.opengl;

	public class Cow : CreatureBase
	{
	  public float walkAngle; //angle of legs/arms as walking
	  public float walkAngleDelta;
	  public static RenderDest dest;

	  //render assets
	  public static Texture texture;
	  protected internal static string textureName;
	  private static GLModel model;

	  public static int initHealth = 10;

	  public Cow()
	  {
		id = Entities.COW;
	  }

	  public override RenderDest Dest
	  {
		  get
		  {
			return dest;
		  }
	  }

	  public override string Name
	  {
		  get
		  {
			return "cow";
		  }
	  }

	  public override void init(World world)
	  {
		base.init(world);
		isStatic = true;
		width = 0.6f;
		width2 = width / 2;
		height = 1.0f;
		height2 = height / 2;
		depth = 1.5f;
		depth2 = depth / 2;
		walkAngleDelta = 5.0f;
		if (world.isServer)
		{
		  eyeHeight = 0.5f;
		  jumpVelocity = 0.58f; //results in jump of 1.42
		  //speeds are blocks per second
		  walkSpeed = 2.3f;
		  runSpeed = 3.9f;
		  sneakSpeed = 1.3f;
		  swimSpeed = (walkSpeed / 2.0f);
		}
		Move = new MoveCreature();
	  }

	  public override void initStatic()
	  {
		base.initStatic();
		textureName = "entity/cow/cow";
		dest = new RenderDest(parts.Length);
		model = loadModel("cow");
	  }

	  public override void initStaticGL()
	  {
		base.initStaticGL();
		texture = Textures.getTexture(textureName, 0);
	  }

	  private static string[] parts = new string[] {"HEAD", "BODY", "L_ARM", "R_ARM", "L_LEG", "R_LEG", "L_HORN", "R_HORN"};

	  private const int L_HORN = 6;
	  private const int R_HORN = 7;

	  public override void bindTexture()
	  {
		texture.bind();
	  }

	  public override void copyBuffers()
	  {
		dest.copyBuffers();
	  }

	  //transforms are applied in reverse
	  public override void setMatrixModel(int bodyPart, RenderBuffers buf)
	  {
		mat.setIdentity();
		mat.addRotate(-ang.y, 0, 1, 0);
		switch (bodyPart)
		{
		  case HEAD:
		  case L_HORN:
		  case R_HORN:
			mat.addTranslate2(0, buf.org.y, 0);
			mat.addRotate2(-ang.x, 1, 0, 0);
			mat.addTranslate2(0, -buf.org.y, 0);
			break;
		  case BODY:
			break;
		  case L_ARM:
		  case R_LEG:
			mat.addTranslate2(buf.org.x, buf.org.y, buf.org.z);
			mat.addRotate2(walkAngle, 1, 0, 0);
			mat.addTranslate2(-buf.org.x, -buf.org.y, -buf.org.z);
			break;
		  case R_ARM:
		  case L_LEG:
			mat.addTranslate2(buf.org.x, buf.org.y, buf.org.z);





