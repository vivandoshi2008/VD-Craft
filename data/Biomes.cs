namespace jfcraft.data
{
	/// <summary>
	/// Biomes
	/// 
	/// </summary>

	using jfcraft.biome;

	public class Biomes
	{
	  public BiomeBase[] biomes;

	  //biome types
	  public const sbyte TUNDRA = 0; //snow plains
	  public const sbyte TAIGA = 1; //snow forest
	  public const sbyte PLAINS = 2; //dry plains (few trees)
	  public const sbyte DESERT = 3; //dry sand
	  public const sbyte FOREST = 4; //lots o trees
	  public const sbyte SWAMP = 5; //swamp/marsh area
	  public const sbyte JUNGLE = 6; //thick trees/bush/plants
	  public const sbyte OCEAN = 7; //the sea/rivers
	  public const sbyte NETHER = 8; //nether
	  public const sbyte DARK_FOREST = 9; //darker larger trees
	  public const sbyte END = 10; //end world
	  public const sbyte SAVANA = 11; //savana
	  public const sbyte BADLANDS = 12; //badlands

	  private const int COUNT = 13;

	  public Biomes()
	  {
		biomes = new BiomeBase[COUNT];
		biomes[0] = new BiomeTundra();
		biomes[1] = new BiomeTaiga();
		biomes[2] = new BiomePlains();
		biomes[3] = new BiomeDesert();
		biomes[4] = new BiomeForest();
		biomes[5] = new BiomeSwamp();
		biomes[6] = new BiomeJungle();
		biomes[7] = new BiomeOcean();
		biomes[8] = new BiomeNether();
		biomes[9] = new BiomeDarkForest();
		biomes[10] = new BiomeEnd();
		biomes[11] = new BiomeSavana();
		biomes[12] = new BiomeBadLands();
	  }

	  public static string getBiomeName(sbyte type)
	  {
		switch (type)
		{
		  case TUNDRA:
			  return "TUNDRA";
		  case TAIGA:
			  return "TAIGA";
		  case PLAINS:
			  return "PLAINS";
		  case DESERT:
			  return "DESERT";
		  case FOREST:
			  return "FOREST";
		  case SWAMP:
			  return "SWAMP";
		  case JUNGLE:
			  return "JUNGLE";
		  case OCEAN:
			  return "OCEAN";
		  case NETHER:
			  return "NETHER";
		  case DARK_FOREST:
			  return "DARK FOREST";
		  case END:
			  return "END";
		  case SAVANA:
			  return "SAVANA";
		  case BADLANDS:
			  return "BAD LANDS";
		}
		return null;
	  }
	}

}