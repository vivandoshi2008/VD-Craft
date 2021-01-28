namespace jfcraft.recipe
{
	/// <summary>
	/// Makes pickaxe.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipePickAxe : Recipe
	{
	  public RecipePickAxe() : base(3,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		char id = items[0].id;
		if (items[1].id != id)
		{
			return null;
		}
		if (items[2].id != id)
		{
			return null;
		}

		if (items[3].id != Blocks.AIR)
		{
			return null;
		}
		if (items[4].id != Items.STICK)
		{
			return null;
		}
		if (items[5].id != Blocks.AIR)
		{
			return null;
		}

		if (items[6].id != Blocks.AIR)
		{
			return null;
		}
		if (items[7].id != Items.STICK)
		{
			return null;
		}
		if (items[8].id != Blocks.AIR)
		{
			return null;
		}

		if (id == Items.DIAMOND)
		{
			return new Item(Items.DIAMOND_PICKAXE, 1.0f);
		}
		if (id == Items.GOLD_INGOT)
		{
			return new Item(Items.GOLD_PICKAXE, 1.0f);
		}
		if (id == Items.IRON_INGOT)
		{
			return new Item(Items.IRON_PICKAXE, 1.0f);
		}
		if (id == Blocks.COBBLESTONE)
		{
			return new Item(Items.STONE_PICKAXE, 1.0f);
		}
		if (id == Blocks.PLANKS)
		{
			return new Item(Items.WOOD_PICKAXE, 1.0f);
		}
		return null;
	  }
	}

}