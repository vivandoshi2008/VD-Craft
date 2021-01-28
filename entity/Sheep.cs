






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Sheep entity
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce;
	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.client;
	using jfcraft.audio;
	using jfcraft.data;
	using jfcraft.item;
	using jfcraft.opengl;
	using jfcraft.move;
	using static jfcraft.data.Types;

	public class Sheep : CreatureBase
	{
	  private float walkAngle; //angle of legs/arms as walking
	  private float walkAngleDelta;

	  //render assets
	  private static RenderDest dest;
	  private static Texture texture, furTexture;
	  private static GLModel model;

	  public static int initHealth = 10;

	  public const int FLAG_FUR = 1;

	  public virtual bool hasFur()
	  {
		return (flags & FLAG_FUR) != 0;
	  }

	  public virtual bool Fur
	  {
		  set
		  {
			if (value)
			{
			  flags |= FLAG_FUR;
			}
			else
			{
			  flags &= -1 - FLAG_FUR;
			}
		  }
	  }

	  public Sheep() : base()
	  {
		id = Entities.SHEEP;
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
			return "Sheep";
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
		depth = 1.8f;
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
		model = loadModel("sheep");
	  }

	  public override void initStaticGL()
	  {
		base.initStaticGL();
		texture = Textures.getTexture("entity/sheep/sheep", 0);
		furTexture = Textures.getTexture("entity/sheep/sheep_fur", 0);
		dest = new RenderDest(parts.Length);
	  }

	  private static string[] parts = new string[] {"HEAD", "BODY", "L_ARM", "R_ARM", "L_LEG", "R_LEG", "HEAD_FUR", "BODY_FUR", "L_ARM_FUR", "R_ARM_FUR", "L_LEG_FUR", "R_LEG_FUR"};

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
			mat.addTranslate2(0, buf.org.y, 0);
			mat.addRotate2(-ang.x, 1, 0, 0);
			mat.addTranslate2(0, -buf.org.y, 0);
			break;
		  case BODY:
			break;
		  case L_ARM:
		  case R_LEG:







