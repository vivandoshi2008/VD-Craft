namespace jfcraft.recipe
{
	/// <summary>
	/// Makes cauldron
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeCauldron : Recipe
	{
	  public RecipeCauldron() : base(3,3)
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

		if (items[3].id != Items.IRON_INGOT)
		{
			return null;
		}
		if (items[4].id != Blocks.AIR)
		{
			return null;
		}
		if (items[5].id != Items.IRON_INGOT)
		{
			return null;
		}

		if (items[6].id != Items.IRON_INGOT)
		{
			return null;
		}
		if (items[7].id != Items.IRON_INGOT)
		{
			return null;
		}
		if (items[8].id != Items.IRON_INGOT)
		{
			return null;
		}

		return new Item(Items.CAULDRON);
	  }
	}

}