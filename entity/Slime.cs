






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Slime entity
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

	public class Slime : CreatureBase
	{
	  private float walkAngle; //angle of legs/arms as walking
	  private float walkAngleDelta;

	  //render assets
	  private static RenderDest dest;
	  private static Texture texture;
	  private static string textureName;
	  private static GLModel model;

	  private static int initHealth = 20;
	  private static int initArmor = 2;

	  public Slime() : base()
	  {
		id = Entities.SLIME;
	  }

	  public override string Name
	  {
		  get
		  {
			return "Slime";
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
		textureName = "entity/slime/slime";
		dest = new RenderDest(parts.Length);
		model = loadModel("slime");
	  }

	  public override void initStaticGL()
	  {
		base.initStaticGL();
		texture = Textures.getTexture(textureName, 0);
	  }

	  private static string[] parts = new string[] {"INNER", "L_EYE", "R_EYE", "MOUTH", "OUTTER"}; //outter MUST be last (transparent)

	  public override void copyBuffers()
	  {
		dest.copyBuffers();
	  }

	  public override void bindTexture()
	  {
		texture.bind();
	  }

	  public override void setMatrixModel(int bodyPart, RenderBuffers buf)
	  {
		mat.setIdentity();
		mat.addRotate(-ang.y, 0, 1, 0);
		mat.addTranslate(pos.x, pos.y, pos.z);
		glUniformMatrix4fv(Static.uniformMatrixModel, 1, GL_FALSE, mat.m); //model matrix
	  }

	  public override void render()
	  {
		for (int a = 0;a < dest.count();a++)
		{
		  RenderBuffers buf = dest.getBuffers(a);
		  if (buf.BufferEmpty)
		  {
			  continue;
		  }
		  setMatrixModel(a, buf);
		  buf.bindBuffers();
		  buf.render();
		}
	  }






