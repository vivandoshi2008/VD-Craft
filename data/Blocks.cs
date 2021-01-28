






using System;
using System.Collections.Generic;

namespace jfcraft.data
{
	/// <summary>
	/// Registered blocks
	/// 
	/// @author vivandoshi
	/// 
	/// Created : Mar 25, 2014
	/// </summary>

	using javaforce;
	using javaforce.gl;

	using jfcraft.block;
	using jfcraft.item;
	using jfcraft.data;
	using jfcraft.opengl;
	using static jfcraft.data.Types;
	using static jfcraft.data.Direction;

	public class Blocks
	{
	  private const int MAX_ID = 65536;
	  private List<AssetImage> tiles = new List<AssetImage>(); //main stitched images

	  public int blockCount = 0;
	  public BlockBase[] blocks = new BlockBase[MAX_ID]; //blocks (in order of id)
	  public BlockBase[] regBlocks = new BlockBase[MAX_ID]; //registered blocks (not in order of id)
	  public Texture stitched; //main stitched texture (including animated textures and cracks)
	  public Texture cracks; //cracks
	  public SubTexture[] subcracks;
	  public BlockBase solid;

	  public bool valid;

	  public static char getBlockID(string name)
	  {
		return Static.server.world.getBlockID(name);
	  }

	  public virtual BlockBase registerBlock(BlockBase block)
	  {
		regBlocks[blockCount++] = block;
		return block;
	  }

	  public virtual BlockBase getBlock(int id)
	  {
		return blocks[id];
	  }

	  public virtual BlockBase getRegisteredBlock(string name)
	  {
		for (int idx = 0;idx < MAX_ID;idx++)
		{
		  BlockBase bb = regBlocks[idx];
		  if (bb == null)
		  {
			  continue;
		  }
		  if (bb.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
		  {
			return bb;
		  }
		}
		return null;
	  }

	  public virtual void orderBlocks()
	  {
		blocks = new BlockBase[MAX_ID];
		for (int a = 0;a < MAX_ID;a++)
		{
		  BlockBase bb = regBlocks[a];
		  if (bb == null)
		  {
			  continue;
		  }
		  blocks[bb.id] = bb;
		  Static.items.items[bb.id] = bb;
		}
		for (int a = 0;a < MAX_ID;a++)
		{
		  if (blocks[a] == null)
		  {
			blocks[a] = blocks[0]; //air
		  }
		}
	  }

	  public static char AIR; //will be zero
	  public static char DIRT;
	  public static char GRASS;
	  public static char GRASSBANK;
	  public static char WEEDS;
	  public static char SNOW;
	  public static char WATER;
	  public static char LAVA;
	  public static char SAND;
	  public static char CLAY;
	  public static char TERRACOTA;
	  public static char OIL;
	  public static char GRAVEL;
	  public static char STONE;
	  public static char COBBLESTONE;
	  public static char PLANKS;
	  public static char SAPLING;
	  public static char BEDROCK;
	  public static char GOLDORE;
	  public static char IRONORE;
	  public static char COALORE;
	  public static char WOOD;
	  public static char LEAVES;
	  public static char SPONGE;
	  public static char GLASSBLOCK;
	  public static char LAPIS_ORE;
	  public static char LAPIS_BLOCK;
	  public static char DISPENSER;
	  public static char SAND_STONE;
	  public static char NOTE_BLOCK;
	  public static char RAIL_POWERED;
	  public static char RAIL_DETECTOR;
	  public static char PISTON_STICKY;
	  public static char WEB;
	  public static char FERN;
	  public static char TALLGRASS;
	  public static char TALLPLANT;
	  public static char DEADBUSH;
	  public static char PISTON;
	  public static char WOOL;
	  public static char DANDELION;
	  public static char FLOWER;
	  public static char MUSHROOM_BROWN;
	  public static char MUSHROOM_RED;
	  public static char GOLD_BLOCK;
	  public static char IRON_BLOCK;
	  public static char STONE_VARS;
	  public static char SLAB;
	  public static char BRICK;
	  public static char TNT;
	  public static char BOOKSHELF;
	  public static char OBSIDIAN;







