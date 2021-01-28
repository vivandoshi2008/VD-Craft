namespace jfcraft.recipe
{
	/// <summary>
	/// Makes a boat.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.data;
	using jfcraft.item;

	public class RecipeBoat : Recipe
	{
	  public RecipeBoat() : base(3,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[1].id != Blocks.AIR)
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

		return new Item(Items.BOAT);
	  }
	}

}