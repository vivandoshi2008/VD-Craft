namespace jfcraft.recipe
{
	using Item = jfcraft.item.Item;
	using jfcraft.data;

	/// <summary>
	/// Makes planks from wood.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;

	public class RecipePlanks : Recipe
	{
	  public RecipePlanks() : base(1,1)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id == Blocks.WOOD)
		{
			return new Item(Blocks.PLANKS, items[0].var, (sbyte)4);
		}
		return null;
	  }
	}

}