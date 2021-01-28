namespace jfcraft.biome
{
	/// <summary>
	/// BiomeTundra
	/// </summary>

	using jfcraft.data;
	using jfcraft.tree;
	using static jfcraft.data.Blocks;
	using static jfcraft.data.Biomes;

	public class BiomeTundra : BiomeBase
	{

	  public override sbyte ID
	  {
		  get
		  {
			return TUNDRA;
		  }
	  }

	  private const int TREE_ODDS = 500;
	  private static readonly int FLOWER_CHUNK_ODDS = INF;
	  private static readonly int FLOWER_BLOCK_ODDS = INF;
	  private static readonly int TALLGRASS_CHUNK_ODDS = INF;
	  private static readonly int TALLGRASS_BLOCK_ODDS = INF;
	  private static readonly int ANIMAL_CHUNK_ODDS = INF;
	  private static readonly int ANIMAL_BLOCK_ODDS = INF;

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
		return Static.trees.trees[rv % 2]; //OAK or SPRUCE
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
		switch (rv % 4)
		{
		  case 0:
			  return Entities.COW;
		  case 1:
			  return Entities.PIG;
		  case 2:
			  return Entities.HORSE;
		  case 3:
			  return Entities.SHEEP;
		};
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