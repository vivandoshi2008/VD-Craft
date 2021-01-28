namespace jfcraft.recipe
{
	/// <summary>
	/// Makes furnace
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.data;
	using jfcraft.item;

	public class RecipeFurnace : Recipe
	{
	  public RecipeFurnace() : base(3,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		for (int a = 0;a < 9;a++)
		{
		  if (a == 4)
		  {
			if (items[a].id != Blocks.AIR)
			{
				return null;
			}
		  }
		  else
		  {
			if (items[a].id != Blocks.COBBLESTONE)
			{
				return null;
			}
		  }
		}
		return new Item(Blocks.FURNACE);
	  }
	}

}