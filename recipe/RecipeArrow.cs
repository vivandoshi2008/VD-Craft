namespace jfcraft.recipe
{
	/// <summary>
	/// Makes shovel.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeArrow : Recipe
	{
	  public RecipeArrow() : base(1,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id != Items.FLINT)
		{
			return null;
		}
		if (items[1].id != Items.STICK)
		{
			return null;
		}
		if (items[2].id != Items.FEATHER)
		{
			return null;
		}

		return new Item(Items.ARROW);
	  }
	}

}