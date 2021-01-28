namespace jfcraft.recipe
{
	/// <summary>
	/// Makes bread from 3 wheat.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.data;
	using jfcraft.item;

	public class RecipeBread : Recipe
	{
	  public RecipeBread() : base(3,1)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		for (int a = 0;a < 3;a++)
		{
		  if (items[a].id != Items.WHEAT_ITEM)
		  {
			  return null;
		  }
		}
		return new Item(Items.BREAD);
	  }
	}

}