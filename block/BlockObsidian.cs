namespace jfcraft.block
{
	using jfcraft.client;
	using jfcraft.data;
	using jfcraft.item;

	/// <summary>
	/// Block Obsidian
	/// 
	/// @author vivandoshi
	/// </summary>

	public class BlockObsidian : BlockOpaque
	{
	  public BlockObsidian(string id, string[] names, string[] images) : base(id, names, images)
	  {
	  }

	  public override bool useTool(Client client, Coords c)
	  {
		Item item = client.player.items[client.player.activeSlot];
		if (item.id == Items.FLINT_STEEL)
		{
		  if (Portal.makePortal(c, id, Blocks.NETHER_PORTAL))
		  {
			  return true;
		  }
		  Static.log("makePortal:failed");
		}
		return base.useTool(client, c);
	  }
	}

}