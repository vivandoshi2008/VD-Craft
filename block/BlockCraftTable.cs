namespace jfcraft.block
{
	/// <summary>
	/// Crafting table
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.client;
	using Chunk = jfcraft.data.Chunk;
	using Coords = jfcraft.data.Coords;

	public class BlockCraftTable : BlockOpaque
	{
	  public BlockCraftTable(string id, string[] names, string[] images) : base(id, names, images)
	  {
		isDir = true;
		isDirXZ = true;
		canUse = true;
	  }

	  public override void useBlock(Client client, Coords c)
	  {
		client.serverTransport.enterMenu(Client.CRAFTTABLE);
		client.menu = Client.CRAFTTABLE;
	  }
	}

}