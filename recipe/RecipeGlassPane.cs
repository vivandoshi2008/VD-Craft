namespace jfcraft.recipe
{
	/// <summary>
	/// Makes glass pane
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeGlassPane : Recipe
	{
	  public RecipeGlassPane() : base(3,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		for (int a = 0;a < 6;a++)
		{
		  if (items[a].id != Blocks.GLASSBLOCK)
		  {
			  return null;
		  }
		}

		return new Item(Blocks.GLASS_PANE);
	  }
	}

}