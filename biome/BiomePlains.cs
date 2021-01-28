namespace jfcraft.biome
{
	/// <summary>
	/// BiomePlains
	/// </summary>

	using jfcraft.data;
	using jfcraft.tree;
	using static jfcraft.data.Blocks;
	using static jfcraft.data.Biomes;

	public class BiomePlains : BiomeBase
	{

	  public override sbyte ID
	  {
		  get
		  {
			return PLAINS;
		  }
	  }

	  private const int TREE_ODDS = 2000;
	  private const int WEEDS_ODDS = 20;
	  private const int FLOWER_CHUNK_ODDS = 30;
	  private const int FLOWER_BLOCK_ODDS = 25;
	  private const int TALLGRASS_CHUNK_ODDS = 3;
	  private const int TALLGRASS_BLOCK_ODDS = 25;
	  private const int ANIMAL_CHUNK_ODDS = 10;
	  private const int ANIMAL_BLOCK_ODDS = 50;

	  public override void build(int x, int y, int z, BiomeData data)
	  {
		if (canPlantOn(x, y, z))
		{
		  if (data.b1 % TREE_ODDS == 0)
		  {
			getTree(data.b2).plant(x, y + 1, z, data);
			return;
		  }
		  if (data.b2 % WEEDS_ODDS == 0)
		  {
			setBlock(x,y + 1,z,WEEDS,0,0);
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
		return Static.trees.trees[rv % 3]; //OAK/SPRUCE/BIRCH
	  }

	  private sbyte[] flowers = new sbyte[] {VAR_POPPY, VAR_BLUE_ORCHID, VAR_ALLIUM, VAR_AZURE_BLUET, VAR_TULIP_RED, VAR_TULIP_ORANGE, VAR_TULIP_WHITE, VAR_TULIP_PINK, VAR_OXEYE_DAISY};

	  public virtual int getFlower(int rv)
	  {
		return flowers[rv % flowers.Length];
	  }

	  private sbyte[] grasses = new sbyte[] {VAR_TALL_GRASS, VAR_LARGE_FERN};

	  public virtual int getTallGrass(int rv)
	  {
		return grasses[rv % grasses.Length];
	  }

	  private sbyte[] plants = new sbyte[] {VAR_LILAC, VAR_ROSE_BUSH, VAR_PEONY};

	  public virtual int getTallPlant(int rv)
	  {
		return plants[rv % plants.Length];
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