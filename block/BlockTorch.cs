using System.Collections.Generic;

namespace jfcraft.block
{
	/// <summary>
	/// Torch
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce.gl;

	using jfcraft.client;
	using jfcraft.data;
	using jfcraft.opengl;
	using static jfcraft.data.Direction;

	public class BlockTorch : BlockBase
	{
	  private static GLModel model;
	  private static List<Box> lb = new List<Box>();
	  private static List<Box> ln = new List<Box>();
	  private static List<Box> le = new List<Box>();
	  private static List<Box> ls = new List<Box>();
	  private static List<Box> lw = new List<Box>();
	  public BlockTorch(string id, string[] names, string[] images) : base(id, names, images)
	  {
		isOpaque = false;
		isAlpha = false;
		isComplex = true;
		isSolid = false;
		isDirFace = true;
		isSupported = true;
		if (model == null)
		{
		  model = Assets.getModel("torch").model;
		  lb.Add(new Box(6, 0, 6, 10,11,10));
		  ln.Add(new Box(6, 3, 0, 10,14, 8));
		  le.Add(new Box(8, 3, 6, 16,14,10));
		  ls.Add(new Box(6, 3, 8, 10,14,16));
		  lw.Add(new Box(0, 3, 6, 8,14,10));
		}
	  }

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		RenderBuffers buf = dest.getBuffers(buffersIdx);
		SubTexture st = getTexture(data);
		data.rotate = -45.0f;
		data.rotate2 = 0;
		switch (data.dir[X])
		{
		  case N:
			data.translate_pre = new float [] {0.0f, 0.0f, -0.3f};
			break;
		  case E:
			data.translate_pre = new float [] {0.3f, 0.0f, 0.0f};
			break;
		  case S:
			data.translate_pre = new float [] {0.0f, 0.0f, 0.3f};
			break;
		  case W:
			data.translate_pre = new float [] {-0.3f, 0.0f, 0.0f};
			break;
		  case A:
			Static.log("Torch with invalid dir:A:@" + data.x + "," + data.y + "," + data.z);
			break;
		  case B:
			data.rotate = 0; //do not rotate
			break;
		}
		buildBuffers(model.getObject("TORCH"), buf, data, st);
		data.resetRotate();
	  }
	  public override bool place(Client client, Coords c)
	  {
		if (c.dir == A)
		{
			return false; //can not place torch on ceiling
		}
		return base.place(client, c);
	  }
	  public override List<Box> getBoxes(Coords c, BlockHitTest_Type type)
	  {
		if (type == BlockHitTest_Type.ENTITY)
		{
			return boxListEmpty;
		}
		int bits = c.chunk.getBits(c.gx, c.gy, c.gz);
		int dir = Chunk.getDir(bits);
		switch (dir)
		{
		  case B:
			  return lb;
		  case N:
			  return ln;
		  case E:
			  return le;
		  case S:
			  return ls;
		  case W:
			  return lw;
		}
		return null;
	  }
	}

}