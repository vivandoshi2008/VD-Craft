namespace jfcraft.biome
{
	/// <summary>
	/// BiomeBase interface
	/// </summary>

	using javaforce;

	using BlockBase = jfcraft.block.BlockBase;
	using jfcraft.tree;
	using jfcraft.data;
	using EntityBase = jfcraft.entity.EntityBase;
	using static jfcraft.data.Blocks;

	public abstract class BiomeBase
	{
	  public static Chunk chunk;
	  public static readonly int INF = int.MaxValue; //infinite odds (ie: never)
	  public static Chunk Chunk
	  {
		  set
		  {
			BiomeBase.chunk = value;
		  }
	  }
	  public abstract sbyte ID {get;}
	  /// <summary>
	  /// Adds trees/flowers/etc to coords in chunk. </summary>
	  /// <param name="x">,y,z = coord of top block of soil in chunk </param>
	  /// <param name="rand"> = random int value (absolute) </param>
	  public abstract void build(int x, int y, int z, BiomeData data);
	  private BlockBase getBlock(int x, int y, int z)
	  {
		if (y < 0)
		{
			return null;
		}
		if (y > 255)
		{
			return null;
		}
		Chunk c = chunk;
		while (x < 0)
		{
		  c = c.W;
		  x += 16;
		}
		while (x > 15)
		{
		  c = c.E;
		  x -= 16;
		}
		while (z < 0)
		{
		  c = c.N;
		  z += 16;
		}
		while (z > 15)
		{
		  c = c.S;
		  z -= 16;
		}
		return Static.blocks.blocks[c.getBlock(x,y,z)];
	  }
	  public virtual void setBlock(int x, int y, int z, char id, int dir, int var)
	  {
		if (y < 1)
		{
			return; //do not change bedrock
		}
		if (y > 255)
		{
			return;
		}
		Chunk c = chunk;
		while (x < 0)
		{
		  c = c.W;
		  x += 16;
		}
		while (x > 15)
		{
		  c = c.E;
		  x -= 16;
		}
		while (z < 0)
		{
		  c = c.N;
		  z += 16;
		}
		while (z > 15)
		{
		  c = c.S;
		  z -= 16;
		}
		if (c.getBlock(x, y, z) != AIR)
		{
			return;
		}
		c.setBlock(x, y, z, id, jfcraft.data.Chunk.makeBits(dir,var));
	  }
	  public virtual void setBlock2(int x, int y, int z, char id, int dir, int var)
	  {
		setBlock(x,y,z,id,dir,var);
		setBlock(x,y + 1,z,id,dir,var + VAR_UPPER);
	  }
	  public virtual bool canPlantOn(int x, int y, int z)
	  {
		BlockBase block = getBlock(x,y,z);
		BlockBase blockA = getBlock(x,y + 1,z);
		return block.canPlantOn && (blockA.id == AIR || blockA.id == SNOW);
	  }
	  public virtual bool canPlantOn(int x, int y, int z, char id)
	  {
		BlockBase block = getBlock(x,y,z);
		BlockBase blockA = getBlock(x,y + 1,z);
		return block.id == id && (blockA.id == AIR || blockA.id == SNOW);
	  }
	  public virtual void spawnAnimal(int x, int y, int z, int id)
	  {
		if (id == -1)
		{
			return;
		}
		EntityBase e = Static.entities.getEntity(id).spawn(chunk);
		if (e == null)
		{
			return; //failed to spawn
		}
		e.uid = Static.server.world.generateUID();
		chunk.addEntity(e);
		Static.server.world.addEntity(e);
	  }
	}

}