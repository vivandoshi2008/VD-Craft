using System;

namespace jfcraft.block
{
	/// <summary>
	/// Block for wheat.
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce;
	using javaforce.gl;

	using jfcraft.data;
	using Item = jfcraft.item.Item;
	using jfcraft.opengl;
	using static jfcraft.data.Direction;

	public class BlockWheat : BlockBase
	{
	  private static GLModel model;
	  public BlockWheat(string id, string[] names, string[] images) : base(id, names, images)
	  {
		isOpaque = false;
		isAlpha = false;
		isComplex = true;
		isSolid = false;
		isVar = true;
		varMask = 0x7;
		resetBoxes(BlockHitTest_Type.BOTH);
		addBox(0, 0, 0, 16, 4, 16, BlockHitTest_Type.SELECTION);
		model = Assets.getModel("wheat").model;
		adjustTextureSize(model.getObject("WHEAT"));
	  }
	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		RenderBuffers buf = dest.getBuffers(buffersIdx);
		buildBuffers(model.getObject("WHEAT"), buf, data, textures[data.var[X] & varMask]);
	  }
	  public override void rtick(Chunk chunk, int gx, int gy, int gz)
	  {
		int x = chunk.cx * 16 + gx;
		int y = gy;
		int z = chunk.cz * 16 + gz;
		int var = chunk.incVar(gx,gy,gz,7);
		if (var == -1)
		{
			return;
		}
		Static.server.broadcastSetBlock(chunk.dim,x,y,z,id,Chunk.makeBits(0,var));
	  }
	  private static Random rnd = new Random();
	  public override Item[] drop(Coords c, int var)
	  {
		if (var == 7)
		{
		  //full wheat
		  return new Item[]
		  {
			  new Item(Items.SEEDS, (sbyte)0, (sbyte)(rnd.Next(2) + 1)),
			  new Item(Items.WHEAT_ITEM)
		  };
		}
		else
		{
		  //drop just seeds
		  return new Item[] {new Item(Items.SEEDS)};
		}
	  }
	}

}