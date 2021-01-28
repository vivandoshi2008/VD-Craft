namespace jfcraft.recipe
{
	/// <summary>
	/// Makes cake
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeCake : Recipe
	{
	  public RecipeCake() : base(3,3)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id != Items.BUCKET_MILK)
		{
			return null;
		}
		if (items[1].id != Items.BUCKET_MILK)
		{
			return null;
		}
		if (items[2].id != Items.BUCKET_MILK)
		{
			return null;
		}

		if (items[3].id != Items.SUGAR)
		{
			return null;
		}
		if (items[4].id != Items.EGG)
		{
			return null;
		}
		if (items[5].id != Items.SUGAR)
		{
			return null;
		}

		if (items[6].id != Items.WHEAT_ITEM)
		{
			return null;
		}
		if (items[7].id != Items.WHEAT_ITEM)
		{
			return null;
		}
		if (items[8].id != Items.WHEAT_ITEM)
		{
			return null;
		}

		return new Item(Items.CAKE);
	  }
	}

}