namespace jfcraft.recipe
{
	/// <summary>
	/// Makes shield.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : Aug 20, 2018
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeShield : Recipe
	{
	  public RecipeShield() : base(3,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[1].id != Items.IRON_INGOT)
		{
			return null;
		}
		if (items[2].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[3].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[4].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[5].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[6].id != Blocks.AIR)
		{
			return null;
		}
		if (items[7].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[8].id != Blocks.AIR)
		{
			return null;
		}
		return new Item(Items.SHIELD, 1.0f);
	  }
	}

}