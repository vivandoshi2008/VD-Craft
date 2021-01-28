namespace jfcraft.recipe
{
	/// <summary>
	/// Makes carpet
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.data;
	using jfcraft.item;

	public class RecipeCarpet : Recipe
	{
	  public RecipeCarpet() : base(2,1)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id != Blocks.WOOL)
		{
			return null;
		}
		if (items[1].id != Blocks.WOOL)
		{
			return null;
		}
		if (items[0].var != items[1].var)
		{
			return null;
		}
		return new Item(Blocks.CARPET, items[0].var, (sbyte)3);
	  }
	}

}