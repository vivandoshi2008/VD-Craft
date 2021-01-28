namespace jfcraft.block
{
	/// <summary>
	/// Block that can fall : sand / gravel.
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.data;
	using jfcraft.entity;
	using static jfcraft.data.Direction;

	public class BlockFalling : BlockOpaque
	{
	  public BlockFalling(string id, string[] names, string[] images) : base(id, names, images)
	  {
	  }
	  private Coords c = new Coords();
	  public override void tick(Chunk chunk, Tick tick)
	  {
		//check if block below is empty
	//    Static.log("tick falling:" + chunk + ":" + tick);
		char id1 = chunk.getBlock(tick.x, tick.y - 1, tick.z);
		if (id1 == Blocks.AIR)
		{
		  //convert to entity
		  tick.toWorldCoords(chunk, c);
		  MovingBlock mb = new MovingBlock();
		  mb.init(Static.server.world);
		  mb.dim = chunk.dim;
		  mb.uid = Static.server.world.generateUID();
		  mb.pos.x = c.x;
		  mb.pos.y = c.y;
		  mb.pos.z = c.z;
		  mb.blockid = id;
		  mb.type = MovingBlock.FALL;
		  mb.dir = B;
		  chunk.addEntity(mb);
		  Static.server.world.addEntity(mb);
		  chunk.clearBlock(tick.x, tick.y, tick.z);
		  Static.server.broadcastB2E(chunk.dim, c.x, c.y, c.z, mb.uid);
		}
		base.tick(chunk, tick);
	  }
	}

}