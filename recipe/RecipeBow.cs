namespace jfcraft.recipe
{
	/// <summary>
	/// Makes bow.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : Sept 23, 2014
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeBow : Recipe
	{
	  public RecipeBow() : base(3,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id == Blocks.AIR)
		{
	//      if (items[0].id != Blocks.AIR) return null;
		  if (items[1].id != Items.STICK)
		  {
			  return null;
		  }
		  if (items[2].id != Items.STRING)
		  {
			  return null;
		  }

		  if (items[3].id != Items.STICK)
		  {
			  return null;
		  }
		  if (items[4].id != Blocks.AIR)
		  {
			  return null;
		  }
		  if (items[5].id != Items.STRING)
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
		  if (items[8].id != Items.STRING)
		  {
			  return null;
		  }
		}
		else
		{
		  if (items[0].id != Items.STRING)
		  {
			  return null;
		  }
		  if (items[1].id != Items.STICK)
		  {
			  return null;
		  }
		  if (items[2].id != Blocks.AIR)
		  {
			  return null;
		  }

		  if (items[3].id != Items.STRING)
		  {
			  return null;
		  }
		  if (items[4].id != Blocks.AIR)
		  {
			  return null;
		  }
		  if (items[5].id != Items.STICK)
		  {
			  return null;
		  }

		  if (items[6].id != Items.STRING)
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
		}

		return new Item(Items.BOW);
	  }
	}

}