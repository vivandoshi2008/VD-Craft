using System.Collections.Generic;

namespace jfcraft.block
{
	/// <summary>
	/// Blocks with 1 double-sided face (vines, etc.)
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce;
	using javaforce.gl;

	using jfcraft.data;
	using jfcraft.opengl;
	using static jfcraft.data.Direction;

	public class BlockFace : BlockBase
	{
	  private static GLModel model;
	  public BlockFace(string id, string[] names, string[] images) : base(id, names, images)
	  {
		isOpaque = false;
		isAlpha = false;
		isComplex = true;
		isSolid = false;
		isDir = true;
		model = Assets.getModel("face").model;
	  }

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		RenderBuffers buf = dest.getBuffers(buffersIdx);
		buildBuffers(model.getObject("FACE"), buf, data, textures[0]);
	  }

	  public override List<Box> getBoxes(Coords c, BlockHitTest_Type type)
	  {
		List<Box> list = new List<Box>();
		int bits = c.chunk.getBits(c.gx, c.gy, c.gz);
		int dir = Chunk.getDir(bits);
		switch (dir)
		{
		  case A:
			  list.Add(new Box(0,15, 0, 16,16,16));
			  break;
		  case B:
			  list.Add(new Box(0, 0, 0, 16, 1,16));
			  break;
		  case N:
			  list.Add(new Box(0, 0, 0, 16,16, 1));
			  break;
		  case E:
			  list.Add(new Box(15, 0, 0, 16,16,16));
			  break;
		  case S:
			  list.Add(new Box(0, 0,15, 16,16,16));
			  break;
		  case W:
			  list.Add(new Box(0, 0, 0, 1,16,16));
			  break;
		}
		return list;
	  }
	}

}