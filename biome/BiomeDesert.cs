namespace jfcraft.biome
{
	/// <summary>
	/// BiomeDesert
	/// </summary>

	using jfcraft.data;
	using jfcraft.tree;
	using static jfcraft.data.Blocks;
	using static jfcraft.data.Biomes;

	public class BiomeDesert : BiomeBase
	{

	  public override sbyte ID
	  {
		  get
		  {
			return DESERT;
		  }
	  }

	  private const int TREE_ODDS = 100;
	  private const int FLOWER_CHUNK_ODDS = 2;
	  private const int FLOWER_BLOCK_ODDS = 50;
	  private static readonly int TALLGRASS_CHUNK_ODDS = INF;
	  private static readonly int TALLGRASS_BLOCK_ODDS = INF;
	  private static readonly int ANIMAL_CHUNK_ODDS = INF;
	  private static readonly int ANIMAL_BLOCK_ODDS = INF;

	  public override void build(int x, int y, int z, BiomeData data)
	  {
		if (canPlantOn(x, y, z, SAND))
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
			  setBlock(x,y + 1,z,DEADBUSH,0,0);
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
		return Static.trees.trees[Trees.CACTUS];
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
		return -1;
	  }

	  public virtual int getEnemy(int rv)
	  {
		switch (rv % 3)
		{
		  case 0:
			  return Entities.ZOMBIE;
		  case 1:
			  return Entities.SKELETON;
		  case 2:
			  return Entities.ENDERMAN;
		}
		return -1;
	  }
	}

}