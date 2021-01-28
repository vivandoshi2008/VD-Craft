namespace jfcraft.recipe
{
	/// <summary>
	/// Makes gate
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeGate : Recipe
	{
	  public RecipeGate() : base(3,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		sbyte var;
		if (items[0].id != Items.STICK)
		{
			return null;
		}
		if (items[2].id != Items.STICK)
		{
			return null;
		}
		if (items[3].id != Items.STICK)
		{
			return null;
		}
		if (items[5].id != Items.STICK)
		{
			return null;
		}

		var = items[1].var;

		if (items[1].id != Blocks.PLANKS)
		{
			return null;
		}
	//    if (items[1].var != var) return null;

		if (items[4].id != Blocks.PLANKS)
		{
			return null;
		}
		if (items[4].var != var)
		{
			return null;
		}

		return new Item(Blocks.GATE, (sbyte)var);
	  }
	}

}