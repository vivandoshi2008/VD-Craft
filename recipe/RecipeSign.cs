namespace jfcraft.recipe
{
	/// <summary>
	/// Makes sign
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeSign : Recipe
	{
	  public RecipeSign() : base(3,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[1].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[2].id != Blocks.PLANKS)
		{
			return null;
		}

		if (items[3].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[4].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[5].id != Blocks.PLANKS)
		{
			return null;
		}

		if (items[6].id != Blocks.AIR)
		{
			return null;
		}
		if (items[7].id != Items.STICK)
		{
			return null;
		}
		if (items[8].id != Blocks.AIR)
		{
			return null;
		}

		return new Item(Items.SIGN_ITEM, (sbyte)0, (sbyte)4);
	  }
	}

}