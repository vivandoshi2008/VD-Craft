namespace jfcraft.recipe
{
	/// <summary>
	/// Makes crafting table from 4 planks.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.data;
	using jfcraft.item;

	public class RecipeCraftTable : Recipe
	{
	  public RecipeCraftTable() : base(2,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		for (int a = 0;a < 4;a++)
		{
		  if (items[a].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		}
		return new Item(Blocks.CRAFTTABLE);
	  }
	}

}