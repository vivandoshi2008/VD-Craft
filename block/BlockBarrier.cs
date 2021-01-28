namespace jfcraft.block
{
	/// <summary>
	/// Barrier
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;
	using jfcraft.opengl;

	public class BlockBarrier : BlockBase
	{
	  public BlockBarrier(string name, string[] names, string[] images) : base(name, names, images)
	  {
		isSolid = false;
		Drop = "air";
	  }

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
	  }
	  public override void destroy(Client client, Coords c, bool doDrop)
	  {
	  }
	}

}