namespace jfcraft.entity
{
	/// <summary>
	/// Shield entity
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.data;
	using jfcraft.item;
	using jfcraft.opengl;

	public class Shield : BlockEntity
	{
	  public float lidAngle;
	  public static RenderDest dest;
	  public static GLModel model;

	  //render assets
	  private static Texture texture;
	  protected internal static string textureName;

	  public Shield()
	  {
		id = Entities.SHIELD;
	  }

	  public override string Name
	  {
		  get
		  {
			return "shield";
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
	  }

	  public override void initStatic()
	  {
		base.initStatic();
		textureName = "entity/shield_base_nopattern";
		model = loadModel("shield");
		dest = new RenderDest(parts.Length);
	  }

	  public override void initStaticGL()
	  {
		base.initStaticGL();
		texture = Textures.getTexture(textureName, 0);
	  }

	  public override void initInstance()
	  {
		part = L_ITEM;
		base.initInstance();
	  }

	  private static string[] parts = new string[] {null, null, null, null, null, null, "L_SHIELD", "R_SHIELD"};


	  public override void bindTexture()
	  {
		texture.bind();
	  }

	  public override void copyBuffers()
	  {
		dest.copyBuffers();
	  }

	  public override void render()
	  {
		RenderBuffers buf = dest.getBuffers(part);
		buf.bindBuffers();
		buf.render();
	  }
	}

}