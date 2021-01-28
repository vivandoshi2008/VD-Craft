namespace jfcraft.biome
{
	/// <summary>
	/// BiomeNether
	/// </summary>

	using jfcraft.data;
	using jfcraft.tree;
	using static jfcraft.data.Blocks;
	using static jfcraft.data.Biomes;

	public class BiomeNether : BiomeBase
	{

	  public override sbyte ID
	  {
		  get
		  {
			return NETHER;
		  }
	  }

	  private static readonly int TREE_ODDS = INF;
	  private static readonly int FLOWER_CHUNK_ODDS = INF;
	  private static readonly int FLOWER_BLOCK_ODDS = INF;
	  private static readonly int TALLGRASS_CHUNK_ODDS = INF;
	  private static readonly int TALLGRASS_BLOCK_ODDS = INF;
	  private const int ANIMAL_CHUNK_ODDS = 100;
	  private const int ANIMAL_BLOCK_ODDS = 100;

	  public override void build(int x, int y, int z, BiomeData data)
	  {
		if (canPlantOn(x, y, z))
		{
		  if (data.b1 % TREE_ODDS == 0)
		  {
			getTree(data.b2).plant(x, y + 1, z, data);
			return;
		  }
		  if (data.c1 % FLOWER_CHUNK_ODDS == 0)
		  {
			if (data.b1 % FLOWER_BLOCK_ODDS == 0)
			{
			  setBlock(x,y + 1,z,FLOWER,0,getFlower(data.c2));
			  return;
			}
		  }
		  if (data.c2 % TALLGRASS_CHUNK_ODDS == 0)
		  {
			if (data.b1 % TALLGRASS_BLOCK_ODDS == 0)
			{
			  setBlock2(x,y + 1,z,TALLGRASS,0,getTallGrass(data.c1));
			  return;
			}
		  }
		  if (data.c3 % ANIMAL_CHUNK_ODDS == 0)
		  {
			if (data.b1 % ANIMAL_BLOCK_ODDS == 0)
			{
			  spawnAnimal(x, y + 1, z, getAnimal(data.c1));
			}
		  }
		}
	  }

	  public virtual TreeBase getTree(int rv)
	  {
		return null;
	  }

	  public virtual int getFlower(int rv)
	  {
		return -1;
	  }

	  public virtual int getTallGrass(int rv)
	  {
		return -1;
	  }

	  public virtual int getAnimal(int rv)
	  {
		return Entities.ZOMBIE_PIGMAN;
	  }

	  public virtual int getEnemy(int rv)
	  {
		return Entities.ZOMBIE_PIGMAN;
	  }
	}

}