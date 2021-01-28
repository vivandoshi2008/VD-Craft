namespace jfcraft.entity
{
	/// <summary>
	/// Chest entity
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.data;
	using jfcraft.item;
	using jfcraft.opengl;

	public class Chest : BlockEntity
	{
	  public float lidAngle;
	  public RenderDest dest; //can not be static since chest can be damaged
	  public static GLModel model;

	  //render assets
	  private static Texture texture;
	  protected internal static string textureName;

	  public Chest()
	  {
		id = Entities.CHEST;
	  }

	  public override string Name
	  {
		  get
		  {
			return "chest";
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
		dest = new RenderDest(parts.Length);
		isBlock = true;
	  }

	  public override void initStatic()
	  {
		base.initStatic();
		textureName = "entity/chest/normal";
		model = loadModel("chest");
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

	  private static string[] parts = new string[] {"CONTAINER", "LID", "LATCH"};

	  public override void bindTexture()
	  {
		texture.bind();
	  }

	  public override void copyBuffers()
	  {
		dest.copyBuffers();
	  }

	  public override void setMatrixModel(int bodyPart, RenderBuffers buf)
	  {
		mat.setIdentity();
		mat.addRotate(-ang.y, 0, 1, 0);
		switch (bodyPart)
		{
		  case 0: //container
			break;
		  case 1: //lid
		  case 2: //lock
			mat.addTranslate2(buf.org.x, buf.org.y, buf.org.z);
			mat.addRotate2(lidAngle, 1, 0, 0);
			mat.addTranslate2(-buf.org.x, -buf.org.y, -buf.org.z);
			break;
		}
		mat.addTranslate(pos.x, pos.y, pos.z);
		if (scale != 1.0f)
		{
		  mat.addScale(scale, scale, scale);
		}
		glUniformMatrix4fv(Static.uniformMatrixModel, 1, GL_FALSE, mat.m); //model matrix
	  }

	  public override void render()
	  {
		for (int a = 0;a < dest.count();a++)
		{
		  RenderBuffers buf = dest.getBuffers(a);
		  setMatrixModel(a, buf);
		  buf.bindBuffers();
		  buf.render();
		}
		glUniformMatrix4fv(Static.uniformMatrixModel, 1, GL_FALSE, Static.identity.m); //model matrix
	  }
	  public override bool canSelect()
	  {
		return true;
	  }
	}

}