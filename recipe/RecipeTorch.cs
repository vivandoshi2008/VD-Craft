namespace jfcraft.recipe
{
	/// <summary>
	/// Makes torch.
	/// 
	/// @author vivandoshi
	/// 
	/// Created : 12/21/2020
	/// </summary>

	using jfcraft.item;
	using jfcraft.data;

	public class RecipeTorch : Recipe
	{
	  public RecipeTorch() : base(1,2)
	  {
	  }

	  public override Item make(Item[] items)
	  {
		if (items[0].id != Items.COAL)
		{
			return null;
		}
		if (items[1].id != Items.STICK)
		{
			return null;
		}
		return new Item(Blocks.TORCH, (sbyte)0, (sbyte)4);
	  }
	}

}