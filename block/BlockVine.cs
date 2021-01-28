using System.Collections.Generic;

namespace jfcraft.block
{
	/// 
	/// <summary>
	/// @author vivandoshi
	/// </summary>

	using javaforce.gl;

	using jfcraft.client;
	using jfcraft.data;
	using jfcraft.opengl;
	using static jfcraft.data.Direction;

	public class BlockVine : BlockFace
	{
	  private static GLModel model;
	  public BlockVine(string id, string[] names, string[] images) : base(id, names, images)
	  {
		isDirFace = true;
		isSupported = true;
		dropBlock = "air";
	  }

	  public override void rtick(Chunk chunk, int x, int y, int z)
	  {
		int bits = chunk.getBits(x, y, z);
		int dir = Chunk.getDir(bits);
		if (dir == A || dir == B)
		{
			return;
		}
		if (y == 0)
		{
			return;
		}
		y--;
		if (chunk.setBlockIfEmpty(x, y, z, id, bits))
		{
		  x += chunk.cx * 16;
		  z += chunk.cz * 16;
		  Static.server.broadcastSetBlock(chunk.dim, x, y, z, id, bits);
		}
	  }

	  private static Coords supportingBlock = new Coords();

	  public override bool checkSupported(Coords thisBlock)
	  {
		//get supporting block
		supportingBlock.copy(thisBlock);
		supportingBlock.adjacentBlock();
		Static.server.world.getBlock(thisBlock.chunk.dim, supportingBlock.x, supportingBlock.y, supportingBlock.z, supportingBlock);
		if (supportingBlock.block.canSupportBlock(thisBlock))
		{
			return true;
		}
		//check if vines above or leaves under
		if (Static.server.world.getID(thisBlock.chunk.dim, thisBlock.x, thisBlock.y + 1, thisBlock.z) == id)
		{
			return true;
		}
		if (supportingBlock.block.id == Blocks.LEAVES)
		{
			return true;
		}
		return false;
	  }

	  public override bool place(Client client, Coords c)
	  {
		if (c.y == 0 || c.y == 255)
		{
			return false;
		}
		if (c.dir == A || c.dir == B)
		{
			return false; //can only place on walls
		}
		Coords s = c.clone();
		s.adjacentBlock();
		Static.server.world.getBlock(c.chunk.dim, s.x, s.y, s.z, s);
		if (!s.block.isSolid)
		{
		  return false;
		}
		return base.place(client, c);
	  }

	  private static List<Box> empty = new List<Box>();

	  public override List<Box> getBoxes(Coords c, BlockHitTest_Type type)
	  {
		if (type == BlockHitTest_Type.ENTITY)
		{
			return empty;
		}
		return base.getBoxes(c, type);
	  }
	}

}