namespace jfcraft.recipe
{
	/// <summary>
	/// Makes shears
	/// 
	/// @author vivandoshi
	/// 
	/// Created : Sept 23, 2014
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeShears : Recipe
	{
	  public RecipeShears() : base(2,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id == Blocks.AIR)
		{
	//      if (items[0].id != Blocks.AIR) return null;
		  if (items[1].id != Items.IRON_INGOT)
		  {
			  return null;
		  }

		  if (items[2].id != Items.IRON_INGOT)
		  {
			  return null;
		  }
		  if (items[3].id != Blocks.AIR)
		  {
			  return null;
		  }

		}
		else
		{
		  if (items[0].id != Items.IRON_INGOT)
		  {
			  return null;
		  }
		  if (items[1].id != Blocks.AIR)
		  {
			  return null;
		  }

		  if (items[2].id != Blocks.AIR)
		  {
			  return null;
		  }
		  if (items[3].id != Items.IRON_INGOT)
		  {
			  return null;
		  }
		}

		return new Item(Items.SHEARS, 1.0f);
	  }
	}

}