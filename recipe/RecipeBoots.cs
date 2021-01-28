namespace jfcraft.recipe
{
	/// <summary>
	/// Makes boots
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeBoots : Recipe
	{
	  public RecipeBoots() : base(3,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		char id = items[0].id;
		if (items[1].id != Blocks.AIR)
		{
			return null;
		}
		if (items[2].id != id)
		{
			return null;
		}

		if (items[3].id != id)
		{
			return null;
		}
		if (items[4].id != Blocks.AIR)
		{
			return null;
		}
		if (items[5].id != id)
		{
			return null;
		}

		if (id == Items.DIAMOND)
		{
			return new Item(Items.DIAMOND_BOOTS, 1.0f);
		}
		if (id == Items.GOLD_INGOT)
		{
			return new Item(Items.GOLD_BOOTS, 1.0f);
		}
		if (id == Items.IRON_INGOT)
		{
			return new Item(Items.IRON_BOOTS, 1.0f);
		}
		if (id == Items.CHAIN)
		{
			return new Item(Items.CHAIN_BOOTS, 1.0f);
		}
		if (id == Items.LEATHER)
		{
			return new Item(Items.LEATHER_BOOTS, 1.0f);
		}
		return null;
	  }
	}

}