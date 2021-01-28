namespace jfcraft.recipe
{
	/// <summary>
	/// Makes block (coal, iron, gold, diamond, etc.)
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.data;
	using jfcraft.item;

	public class RecipeBlock2x2 : Recipe
	{
	  public RecipeBlock2x2() : base(2,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].var != 0)
		{
			return null;
		}
		char id = items[0].id;
		for (int a = 1;a < 4;a++)
		{
		  if (items[a].id != id)
		  {
			  return null;
		  }
		  if (items[a].var != 0)
		  {
			  return null;
		  }
		}
		if (id == Items.QUARTZ)
		{
			return new Item(Blocks.QUARTZ_BLOCK);
		}
		if (id == Items.CLAY_BALL)
		{
			return new Item(Blocks.CLAY);
		}
		return null;
	  }
	}

}