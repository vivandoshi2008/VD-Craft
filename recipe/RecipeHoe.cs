namespace jfcraft.recipe
{
	/// <summary>
	/// Makes hoe.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeHoe : Recipe
	{
	  public RecipeHoe() : base(2,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		char id = items[0].id;

		if (items[1].id != id)
		{
			return null;
		}

		if (items[2].id == Blocks.AIR)
		{
		  if (items[3].id != Items.STICK)
		  {
			  return null;
		  }
		  if (items[4].id != Blocks.AIR)
		  {
			  return null;
		  }
		  if (items[5].id != Items.STICK)
		  {
			  return null;
		  }
		}
		else if (items[2].id == Items.STICK)
		{
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
		}
		else
		{
		  return null;
		}

		if (id == Items.DIAMOND)
		{
			return new Item(Items.DIAMOND_HOE, 1.0f);
		}
		if (id == Items.GOLD_INGOT)
		{
			return new Item(Items.GOLD_HOE, 1.0f);
		}
		if (id == Items.IRON_INGOT)
		{
			return new Item(Items.IRON_HOE, 1.0f);
		}
		if (id == Blocks.COBBLESTONE)
		{
			return new Item(Items.STONE_HOE, 1.0f);
		}
		if (id == Blocks.PLANKS)
		{
			return new Item(Items.WOOD_HOE, 1.0f);
		}
		return null;
	  }
	}

}