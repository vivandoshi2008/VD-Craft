namespace jfcraft.block
{
	/// <summary>
	/// Block dirt
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce;

	using jfcraft.client;
	using jfcraft.data;
	using jfcraft.item;
	using static jfcraft.data.Types;

	public class BlockDirt : BlockOpaque
	{
	  //var are for dirt only
	  public const int VAR_DIRT = 0;
	  public const int VAR_PODZOL = 1;
	  public const int VAR_FARM_DRY = 2;
	  public const int VAR_FARM_WET = 3;
	  public BlockDirt(string id, string[] names, string[] images) : base(id, names, images)
	  {
	  }
	  public override bool useTool(Client client, Coords c)
	  {
		int bits = c.chunk.getBits(c.gx, c.gy, c.gz);
		int var = Chunk.getVar(bits);
		if (var == VAR_FARM_DRY)
		{
			return base.useTool(client, c);
		}
		if (var == VAR_FARM_WET)
		{
			return base.useTool(client, c);
		}
		if (var == VAR_PODZOL)
		{
			return base.useTool(client, c);
		}
		lock (client.@lock)
		{
		  char toolid = client.player.items[client.player.activeSlot].id;
		  ItemBase item = Static.items.items[toolid];
		  if (item.isTool && item.tool == TOOL_HOE)
		  {
			//change to farm soil
			char newid = id;
			if (id == Blocks.GRASS)
			{
				newid = Blocks.DIRT; //change grass to dirt
			}
			c.chunk.setBlock(c.gx,c.gy,c.gz,newid,Chunk.makeBits(0,VAR_FARM_DRY));
			Static.server.broadcastSetBlock(c.chunk.dim,c.x,c.y,c.z,newid,Chunk.makeBits(0,VAR_FARM_DRY));
			c.chunk.addTick(c, false);
			return true;
		  }
		}
		return base.useTool(client, c);
	  }
	  public override Item[] drop(Coords c, int var)
	  {
		switch (var)
		{
		  case VAR_DIRT:
			  var = VAR_DIRT;
			  break;
		  case VAR_PODZOL:
			  var = VAR_PODZOL;
			  break;
		  case VAR_FARM_DRY:
			  var = VAR_DIRT;
			  break;
		  case VAR_FARM_WET:
			  var = VAR_DIRT;
			  break;
		}
		return new Item[] {new Item(dropID, var)};
	  }
	  public override void rtick(Chunk chunk, int gx, int gy, int gz)
	  {
		int x = chunk.cx * 16 + gx;
		int y = gy;
		int z = chunk.cz * 16 + gz;
		int var = Chunk.getVar(chunk.getBits(gx, gy, gz));
		switch (var)
		{
		  case VAR_FARM_DRY:
		  {
			//check for nearby water and convert to wet farmland
			for (int dx = -4;dx <= 4;dx++)
			{
			  for (int dy = -1;dy <= 1;dy++)
			  {
				for (int dz = -4;dz <= 4;dz++)
				{
				  if (chunk.getBlock2(dx + gx, dy + gy, dz + gz) == Blocks.WATER)
				  {
					chunk.setBlock(gx,gy,gz,id,Chunk.makeBits(0,VAR_FARM_WET));
					Static.server.broadcastSetBlock(chunk.dim,x,y,z,id,Chunk.makeBits(0,VAR_FARM_WET));
					return;
				  }
				}
			  }
			}
			break;
		  }
		  case VAR_DIRT:
		  {
			//grow grass
			if (chunk.getBlock(gx, gy + 1, gz) != (char)0)
			{
			  if (chunk.getBlockType(gx, gy + 1, gz).isSolid)
			  {
				  return;
			  }
			}
			if (chunk.getBlock2(gx, gy + 1, gz) != (char)0)
			{
				return;
			}
			if (chunk.getSunLight(gx, gy + 1, gz) == 0)
			{
				return;
			}
			for (int dx = -1;dx <= 1;dx++)
			{
			  for (int dy = -1;dy <= 1;dy++)
			  {
				for (int dz = -1;dz <= 1;dz++)
				{
				  if (chunk.getBlock(dx + gx, dy + gy, dz + gz) == Blocks.GRASS)
				  {
					chunk.setBlock(gx, gy, gz, Blocks.GRASS, 0);
					Static.server.broadcastSetBlock(chunk.dim, x, y, z, Blocks.GRASS, 0);
					return;
				  }
				}
			  }
			}
			break;
		  }
		}
	  }
	}

}