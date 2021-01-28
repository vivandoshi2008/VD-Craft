namespace jfcraft.recipe
{
	/// <summary>
	/// Makes flint and steel
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeFlintAndSteel : Recipe
	{
	  public RecipeFlintAndSteel() : base(-1,-1)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		int flint = 0;
		int steel = 0;
		for (int a = 0;a < items.Length;a++)
		{
		  char id = items[a].id;
		  if (id == Items.IRON_INGOT)
		  {
			  steel++;
			  continue;
		  }
		  if (id == Items.FLINT)
		  {
			  flint++;
			  continue;
		  }
		  if (id == Blocks.AIR)
		  {
			  continue;
		  }
		  return null;
		}
		if (flint == 1 && steel == 1)
		{
			return new Item(Items.FLINT_STEEL, 1.0f);
		}
		return null;
	  }
	}

}