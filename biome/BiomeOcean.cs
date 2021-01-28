namespace jfcraft.biome
{
	/// <summary>
	/// BiomeOcean
	/// </summary>

	using jfcraft.data;
	using jfcraft.tree;
	using static jfcraft.data.Blocks;
	using static jfcraft.data.Biomes;

	public class BiomeOcean : BiomeBase
	{

	  public override sbyte ID
	  {
		  get
		  {
			return OCEAN;
		  }
	  }

	  private const int WEEDS_ODDS = 10;
	  private static readonly int ANIMAL_CHUNK_ODDS = INF;
	  private static readonly int ANIMAL_BLOCK_ODDS = INF;

	  public override void build(int x, int y, int z, BiomeData data)
	  {
		if (canPlantOn(x, y, z))
		{
		  if (data.b1 % WEEDS_ODDS == 0)
		  {
			int odds = data.b2 % 3;
			if (odds == 0)
			{
			  getTree(data.c1).plant(x, y + 1, z, data);
			  return;
			}
			if (odds == 1 && y <= 63)
			{
			  setBlock(x,y + 1,z,SEAWEEDS,0,0);
			  return;
			}
			if (odds == 2 && y <= 62)
			{
			  setBlock2(x,y + 1,z,TALLSEAWEEDS,0,0);
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
		return Static.trees.trees[Trees.KELP];
	  }

	  public virtual int getFlower(int rv)
	  {
		return jfcraft.data.Blocks.SEAWEEDS;
	  }

	  public virtual int getTallGrass(int rv)
	  {
		return jfcraft.data.Blocks.TALLSEAWEEDS;
	  }

	  public virtual int getAnimal(int rv)
	  {
		//fish ???
		return -1;
	  }

	  public virtual int getEnemy(int rv)
	  {
		return -1;
	  }
	}

}