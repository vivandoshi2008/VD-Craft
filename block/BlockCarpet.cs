namespace jfcraft.block
{
	/// <summary>
	/// Thin blocks (carpet, etc.)
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce.gl;

	using jfcraft.data;
	using jfcraft.opengl;

	public class BlockCarpet : BlockBase
	{
	  private static GLModel model;
	  public BlockCarpet(string name, string[] names, string[] images) : base(name, names, images)
	  {
		isOpaque = false;
		isAlpha = false;
		isComplex = true;
		isSolid = false;
		resetBoxes(BlockHitTest_Type.BOTH);
		addBox(0,0,0, 16,1,16,BlockHitTest_Type.SELECTION);
		if (model == null)
		{
		  model = Assets.getModel("carpet").model;
		}
	  }

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		RenderBuffers buf = dest.getBuffers(buffersIdx);
		buildBuffers(model.getObject("CARPET"), buf, data, getTexture(data));
	  }
	}

}