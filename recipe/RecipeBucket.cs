namespace jfcraft.recipe
{
	/// <summary>
	/// Makes a bucket.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.data;
	using jfcraft.item;

	public class RecipeBucket : Recipe
	{
	  public RecipeBucket() : base(3,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id != Items.IRON_INGOT)
		{
			return null;
		}
		if (items[1].id != Blocks.AIR)
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
		if (items[4].id != Items.IRON_INGOT)
		{
			return null;
		}
		if (items[5].id != Blocks.AIR)
		{
			return null;
		}

		return new Item(Items.BUCKET);
	  }
	}

}