namespace jfcraft.recipe
{
	/// <summary>
	/// Makes button
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeButton : Recipe
	{
	  public RecipeButton() : base(1,1)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id == Blocks.COBBLESTONE)
		{
			return new Item(Blocks.BUTTON, (sbyte)1);
		}
		if (items[0].id == Blocks.STONE)
		{
			return new Item(Blocks.BUTTON, (sbyte)1);
		}
		if (items[0].id == Blocks.PLANKS)
		{
			return new Item(Blocks.BUTTON);
		}
		return null;
	  }
	}

}