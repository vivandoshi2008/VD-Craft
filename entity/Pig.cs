






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Pig entity
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce;
	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.audio;
	using jfcraft.data;
	using Item = jfcraft.item.Item;
	using MoveCreature = jfcraft.move.MoveCreature;
	using jfcraft.opengl;

	public class Pig : CreatureBase
	{
	  private float walkAngle; //angle of legs/arms as walking
	  private float walkAngleDelta;

	  //render assets
	  private RenderDest dest;
	  private static Texture texture;
	  private static string textureName;
	  private static GLModel model;

	  public static int initHealth = 10;

	  public Pig()
	  {
		id = Entities.PIG;
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
			return "PIG";
		  }
	  }

	  public override void init(World world)
	  {
		base.init(world);
		width = 0.6f;
		width2 = width / 2;
		height = 0.8f;
		height2 = height / 2;
		depth = 1.3f;
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
		textureName = "entity/pig/pig";
		model = loadModel("pig");
	  }

	  public override void initStaticGL()
	  {
		base.initStaticGL();
		texture = Textures.getTexture(textureName, 0);
	  }

	  public override void initInstance()
	  {
		base.initInstance();
		dest = new RenderDest(parts.Length);
	  }

	  private static string[] parts = new string[] {"HEAD", "BODY", "L_ARM", "R_ARM", "L_LEG", "R_LEG", "SNOUT"};

	  private const int SNOUT = 6;

	  public override void setMatrixModel(int bodyPart, RenderBuffers buf)
	  {
		mat.setIdentity();
		mat.addRotate(-ang.y, 0, 1, 0);
		switch (bodyPart)
		{
		  case HEAD:
		  case SNOUT:
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
			mat.addRotate2(-walkAngle, 1, 0, 0);







