namespace jfcraft.recipe
{
	/// <summary>
	/// Makes fence
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeFence : Recipe
	{
	  public RecipeFence() : base(3,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		sbyte var;
		if (items[1].id != Items.STICK)
		{
			return null;
		}
		if (items[4].id != Items.STICK)
		{
			return null;
		}

		var = items[0].var;

		if (items[0].id != Blocks.PLANKS)
		{
			return null;
		}
	//    if (items[0].var != var) return null;

		if (items[2].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[2].var != var)
		{
			return null;
		}

		if (items[3].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[3].var != var)
		{
			return null;
		}

		if (items[5].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[5].var != var)
		{
			return null;
		}

		return new Item(Blocks.FENCE, (sbyte)var);
	  }
	}

}