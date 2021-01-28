






using System;
using System.Collections.Generic;

namespace jfcraft.data
{
	/// <summary>
	/// Registered items
	/// 
	/// @author vivandoshi
	
	/// </summary>

	using javaforce;
	using javaforce.gl;

	using jfcraft.block;
	using jfcraft.item;
	using jfcraft.entity;
	using jfcraft.opengl;
	using static jfcraft.data.Types;
	using static jfcraft.data.Direction;

	public class Items
	{
	  public const int MAX_ID = 65536;
	  public const char FIRST_ID = (char)32768;
	  public int itemCount = 0;
	  public ItemBase[] items; //items (ordered by id)
	  public ItemBase[] regItems = new ItemBase[MAX_ID]; //registered items (not ordered by id)
	  public bool valid;

	  public static char getItemID(string name)
	  {
		return Static.server.world.getItemID(name);
	  }

	  private List<AssetImage> tiles = new List<AssetImage>(); //main stitched images
	  private List<AssetImage> others = new List<AssetImage>(); //other images

	  public virtual void registerItem(ItemBase item)
	  {
		regItems[itemCount++] = item;
	  }

	  public virtual void orderItems()
	  {
		items = new ItemBase[MAX_ID];
		for (int a = 0;a < MAX_ID;a++)
		{
		  ItemBase ib = regItems[a];
		  if (ib == null)
		  {
			  continue;
		  }
		  items[ib.id] = ib;
		}
		for (int a = 0;a < MAX_ID;a++)
		{
		  if (items[a] == null)
		  {
			items[a] = items[0]; //air
		  }
		}
	  }

	  public static char IRON_SHOVEL;
	  public static char IRON_PICKAXE;
	  public static char IRON_AXE;
	  public static char FLINT_STEEL;
	  public static char APPLE;
	  public static char BOW;
	  public static char ARROW;
	  public static char COAL;
	  public static char DIAMOND;
	  public static char IRON_INGOT;
	  public static char GOLD_INGOT;
	  public static char IRON_SWORD;
	  public static char WOOD_SWORD;
	  public static char WOOD_SHOVEL;
	  public static char WOOD_PICKAXE;
	  public static char WOOD_AXE;
	  public static char STONE_SWORD;
	  public static char STONE_SHOVEL;
	  public static char STONE_PICKAXE;
	  public static char STONE_AXE;
	  public static char DIAMOND_SWORD;
	  public static char DIAMOND_SHOVEL;
	  public static char DIAMOND_PICKAXE;
	  public static char DIAMOND_AXE;
	  public static char STICK;
	  public static char BOWL;
	  public static char MUSHROOM_STEW;
	  public static char GOLD_SWORD;
	  public static char GOLD_SHOVEL;
	  public static char GOLD_PICKAXE;
	  public static char GOLD_AXE;
	  public static char STRING;
	  public static char FEATHER;
	  public static char GUN_POWDER;
	  public static char WOOD_HOE;
	  public static char STONE_HOE;
	  public static char IRON_HOE;
	  public static char DIAMOND_HOE;
	  public static char GOLD_HOE;
	  public static char SEEDS;
	  public static char WHEAT_ITEM; //dup?  remove it?
	  public static char BREAD;
	  public static char LEATHER_CAP;
	  public static char LEATHER_CHEST;
	  public static char LEATHER_PANTS;
	  public static char LEATHER_BOOTS;
	  public static char CHAIN_HELMET;
	  public static char CHAIN_CHEST;
	  public static char CHAIN_PANTS;
	  public static char CHAIN_BOOTS;
	  public static char IRON_HELMET;
	  public static char IRON_CHEST;
	  public static char IRON_PANTS;
	  public static char IRON_BOOTS;
	  public static char DIAMOND_HELMET;
	  public static char DIAMOND_CHEST;
	  public static char DIAMOND_PANTS;
	  public static char DIAMOND_BOOTS;
	  public static char GOLD_HELMET;
	  public static char GOLD_CHEST;
	  public static char GOLD_PANTS;
	  public static char GOLD_BOOTS;
	  public static char FLINT;
	  public static char PORK_RAW;
	  public static char PORK_COOKED;
	  public static char PAINTING;







