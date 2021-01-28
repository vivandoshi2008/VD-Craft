namespace jfcraft.recipe
{
	/// <summary>
	/// Makes stairs
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeStairs : Recipe
	{
	  public RecipeStairs() : base(3,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		sbyte var;
		if (items[0].id == Blocks.AIR)
		{
		  var = items[2].var;

	//      if (items[0].id != Blocks.AIR) return null;
		  if (items[1].id != Blocks.AIR)
		  {
			  return null;
		  }
		  if (items[2].id != Blocks.PLANKS)
		  {
			  return null;
		  }
	//      if (items[2].var != var) return null;

		  if (items[3].id != Blocks.AIR)
		  {
			  return null;
		  }
		  if (items[4].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		  if (items[4].var != var)
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

		  if (items[6].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		  if (items[6].var != var)
		  {
			  return null;
		  }
		  if (items[7].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		  if (items[7].var != var)
		  {
			  return null;
		  }
		  if (items[8].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		  if (items[8].var != var)
		  {
			  return null;
		  }
		}
		else
		{
		  var = items[0].var;

		  if (items[0].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		  if (items[0].var != var)
		  {
			  return null;
		  }
		  if (items[1].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		  if (items[2].id != Blocks.AIR)
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
		  if (items[4].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		  if (items[4].var != var)
		  {
			  return null;
		  }
		  if (items[5].id != Blocks.AIR)
		  {
			  return null;
		  }

		  if (items[6].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		  if (items[6].var != var)
		  {
			  return null;
		  }
		  if (items[7].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		  if (items[7].var != var)
		  {
			  return null;
		  }
		  if (items[8].id != Blocks.PLANKS)
		  {
			  return null;
		  }
		  if (items[8].var != var)
		  {
			  return null;
		  }
		}

		return new Item(Blocks.STAIRS_WOOD, (sbyte)var);
	  }
	}

}