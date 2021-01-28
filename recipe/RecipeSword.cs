namespace jfcraft.recipe
{
	/// <summary>
	/// Makes sword.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeSword : Recipe
	{
	  public RecipeSword() : base(1,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		char id = items[0].id;
		if (items[1].id != id)
		{
			return null;
		}
		if (items[2].id != Items.STICK)
		{
			return null;
		}

		if (id == Items.DIAMOND)
		{
		  return new Item(Items.DIAMOND_SWORD, 1.0f);
		}
		if (id == Items.GOLD_INGOT)
		{
		  return new Item(Items.GOLD_SWORD, 1.0f);
		}
		if (id == Items.IRON_INGOT)
		{
		  return new Item(Items.IRON_SWORD, 1.0f);
		}
		if (id == Blocks.COBBLESTONE)
		{
		  return new Item(Items.STONE_SWORD, 1.0f);
		}
		if (id == Blocks.PLANKS)
		{
		  return new Item(Items.WOOD_SWORD, 1.0f);
		}
		return null;
	  }
	}

}