namespace jfcraft.recipe
{
	/// <summary>
	/// Makes fishing rod.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : Sept 23, 2014
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeFishingRod : Recipe
	{
	  public RecipeFishingRod() : base(3,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id == Blocks.AIR)
		{
	//      if (items[0].id != Blocks.AIR) return null;
		  if (items[1].id != Blocks.AIR)
		  {
			  return null;
		  }
		  if (items[2].id != Items.STICK)
		  {
			  return null;
		  }

		  if (items[3].id != Blocks.AIR)
		  {
			  return null;
		  }
		  if (items[4].id != Items.STICK)
		  {
			  return null;
		  }
		  if (items[5].id != Items.STRING)
		  {
			  return null;
		  }

		  if (items[6].id != Items.STICK)
		  {
			  return null;
		  }
		  if (items[7].id != Blocks.AIR)
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
		  if (items[0].id != Items.STICK)
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

		  if (items[3].id != Items.STRING)
		  {
			  return null;
		  }
		  if (items[4].id != Items.STICK)
		  {
			  return null;
		  }
		  if (items[5].id != Blocks.AIR)
		  {
			  return null;
		  }

		  if (items[6].id != Items.STRING)
		  {
			  return null;
		  }
		  if (items[7].id != Blocks.AIR)
		  {
			  return null;
		  }
		  if (items[8].id != Items.STICK)
		  {
			  return null;
		  }
		}

		return new Item(Items.FISHING_ROD, 1.0f);
	  }
	}

}