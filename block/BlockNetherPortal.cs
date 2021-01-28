namespace jfcraft.block
{
	/// <summary>
	/// Nether portal block.
	/// 
	/// @author vivandoshi
	/// </summary>

	using Blocks = jfcraft.data.Blocks;
	using Dims = jfcraft.data.Dims;

	public class BlockNetherPortal : BlockPortal
	{
	  public BlockNetherPortal(string id, string[] names, string[] images) : base(id, names, images)
	  {
	  }

	  public override int Dimension
	  {
		  get
		  {
			return Dims.NETHER;
		  }
	  }

	  public override char FrameBlock
	  {
		  get
		  {
			return Blocks.OBSIDIAN;
		  }
	  }

	  public override char PortalBlock
	  {
		  get
		  {
			return Blocks.NETHER_PORTAL;
		  }
	  }
	}

}