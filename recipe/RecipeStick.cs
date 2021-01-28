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

	public class RecipeStick : Recipe
	{
	  public RecipeStick() : base(1,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		for (int a = 0;a < 2;a++)
		{
		  if (items[a].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		}
		return new Item(Items.STICK, (sbyte)0, (sbyte)4);
	  }
	}

}