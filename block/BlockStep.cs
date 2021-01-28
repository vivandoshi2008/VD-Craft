using System.Collections.Generic;

namespace jfcraft.block
{
	/// <summary>
	/// Step blocks
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using jfcraft.data;
	using jfcraft.opengl;
	using static jfcraft.data.Direction;

	public class BlockStep : BlockBase
	{
	  public BlockStep(string id, string[] names, string[] images) : base(id, names, images)
	  {
		isOpaque = false;
		isAlpha = false;
	//    hasShape = true;  //TODO
		isComplex = true;
		isSolid = false;
		dropBlock = "AIR";
		canPlace_Conflict = false; //too complex
		isSupported = true;
	  }

	  private static bool[] q = new bool[8];

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		RenderBuffers buf = dest.getBuffers(buffersIdx);
		/*
		  -z
		 0|1    y+
		--|--x
		 2|3    y-
	
		 4|5    y+
		-----x
		 6|7    y-
		  +z
		*/
		int bits = data.bits;
		q[0] = (bits & QUNW) != 0;
		q[1] = (bits & QUNE) != 0;
		q[2] = (bits & QLNW) != 0;
		q[3] = (bits & QLNE) != 0;
		q[4] = (bits & QUSW) != 0;
		q[5] = (bits & QUSE) != 0;
		q[6] = (bits & QLSW) != 0;
		q[7] = (bits & QLSE) != 0;

		SubTexture st = getTexture(data);
		for (int a = 0;a < 8;a++)
		{
		  if (q[a])
		  {
			addQuad(buf, data, a, st);
		  }
		}
	  }

	  public override void setShape(Chunk chunk, int gx, int gy, int gz, bool live, Coords c)
	  {
		int bits = chunk.getBits(gx,gy,gz);
		int old = bits;
		int x = gx + chunk.cx * 16;
		int y = gy;
		int z = gz + chunk.cz * 16;
		World world = Static.server.world;
		//TODO!!!
		if (old != bits)
		{
		  Static.log("setShape:old=" + old + ",new=" + bits);
		  chunk.setBits(gx,gy,gz, bits);
		  if (live)
		  {
			Static.server.broadcastSetBlock(chunk.dim, x, y, z, id, bits);
		  }
		}
	  }

	  public override List<Box> getBoxes(Coords c, BlockHitTest_Type type)
	  {
		List<Box> list = new List<Box>();

		int bits = c.chunk.getBits(c.gx, c.gy, c.gz);
		q[0] = (bits & QUNW) != 0;
		q[1] = (bits & QUNE) != 0;
		q[2] = (bits & QLNW) != 0;
		q[3] = (bits & QLNE) != 0;
		q[4] = (bits & QUSW) != 0;
		q[5] = (bits & QUSE) != 0;
		q[6] = (bits & QLSW) != 0;
		q[7] = (bits & QLSE) != 0;

		if (q[0])
		{
			list.Add(new Box(0, 8, 0, 8,16, 8));
		}
		if (q[1])
		{
			list.Add(new Box(8, 8, 0, 16,16, 8));
		}
		if (q[2])
		{
			list.Add(new Box(0, 0, 0, 8, 8, 8));
		}
		if (q[3])
		{
			list.Add(new Box(8, 0, 0, 16, 8, 8));
		}
		if (q[4])
		{
			list.Add(new Box(0, 8, 8, 8,16,16));
		}
		if (q[5])
		{
			list.Add(new Box(8, 8, 8, 16,16,16));
		}
		if (q[6])
		{
			list.Add(new Box(0, 0, 8, 8, 8,16));
		}
		if (q[7])
		{
			list.Add(new Box(8, 0, 8, 16, 8,16));
		}

		return list;
	  }
	}

}