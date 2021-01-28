






namespace jfcraft.block
{
	/// <summary>
	/// Water, Lava, etc.
	/// 
	/// dir = flowing direction
	/// var = inverse depth (0=full ... 15=near empty)
	/// 
	/// NOTE : if depth == full and dir == 0 then block is static
	/// NOTE : if depth == full and dir == 1 then block is flowing
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce;

	using jfcraft.data;
	using jfcraft.item;
	using jfcraft.opengl;
	using static jfcraft.data.Direction;

	public class BlockLiquid : BlockAlpha
	{
	  private static Face face = new Face();
	  private float flowRate; //1 for water, 3 for lava
	  private bool canRenew; //true for water, false for lava
	  public BlockLiquid(string id, string[] names, string[] images) : base(id,names,images)
	  {
		canReplace = true;
		canSelect = false;
		canSpawnOn = false;
		isBlocks2 = true;
		isSolid = false;
		isLiquid = true;
		absorbLight_Conflict = 1;
		resetBoxes(BlockHitTest_Type.BOTH); //no boxes
	  }
	  private float var2depth(int var)
	  {
		return (16 - var) / 16f;
	  }
	  private int depth2var(float depth)
	  {
		return 16 - (int)(depth * 16f);
	  }
	  private bool isStatic(Chunk chunk, int x, int y, int z)
	  {
		if (x < 0)
		{
			return isStatic(chunk.W,x + 16,y,z);
		}
		if (x > 15)
		{
			return isStatic(chunk.E,x - 16,y,z);
		}
		if (z < 0)
		{
			return isStatic(chunk.N,x,y,z + 16);
		}
		if (z > 15)
		{
			return isStatic(chunk.S,x,y,z - 16);
		}
		if (chunk.getBlock2(x,y,z) != id)
		{
			return false;
		}
		return chunk.getBits2(x, y, z) == 0; //dir == 0 && var == 0(full)
	  }
	  /// <summary>
	  /// Returns depth of liquid </summary>
	  private float getDepth(Chunk chunk, int x, int y, int z)
	  {
		if (x < 0)
		{
			return getDepth(chunk.W,x + 16,y,z);
		}
		if (x > 15)
		{
			return getDepth(chunk.E,x - 16,y,z);
		}
		if (z < 0)
		{
			return getDepth(chunk.N,x,y,z + 16);
		}
		if (z > 15)
		{
			return getDepth(chunk.S,x,y,z - 16);
		}
		char adj_id = chunk.getBlock2(x,y,z);
		if (adj_id != id)
		{
			return 0f;
		}
		return var2depth(Chunk.getVar(chunk.getBits2(x,y,z)));
	  }
	  private bool canFill(Chunk chunk, int x, int y, int z)
	  {
		BlockBase base1 = chunk.getBlockType1(x, y, z);
		char id2 = chunk.getBlock2(x, y, z);
		return base1.isComplex && id2 == (char)0;
	  }
	  private int getDir(Chunk chunk, int x, int y, int z)
	  {
		if (x < 0)
		{
			return getDir(chunk.W,x + 16,y,z);
		}
		if (x > 15)
		{
			return getDir(chunk.E,x - 16,y,z);
		}
		if (z < 0)
		{
			return getDir(chunk.N,x,y,z + 16);
		}
		if (z > 15)
		{
			return getDir(chunk.S,x,y,z - 16);
		}
		char adj_id = chunk.getBlock2(x,y,z);
		if (adj_id != id)
		{
			return 0;
		}
		return Chunk.getDir(chunk.getBits(x, y, z));
	  }
	  private int getDesiredDir(Chunk chunk, int x, int y, int z)
	  {
		float dn = getDepth(chunk,x,y,z - 1);
		float de = getDepth(chunk,x + 1,y,z);
		float ds = getDepth(chunk,x,y,z + 1);
		float dw = getDepth(chunk,x - 1,y,z);
		int dir = A;
		if (dn > ds)
		{
		  dir = S;
		  if (de > dw)
		  {
			dir = SW;
		  }
		  else if (dw > de)
		  {
			dir = SE;
		  }
		}
		else if (ds > dn)
		{
		  dir = N;
		  if (de > dw)
		  {
			dir = NW;
		  }
		  else if (dw > de)
		  {
			dir = NE;
		  }
		}
		else if (de > dw)
		{
		  dir = W;
		  if (dn > ds)
		  {
			dir = SW;
		  }
		  else if (ds > dn)
		  {
			dir = NW;
		  }
		}
		else if (dw > de)
		{
		  dir = E;
		  if (dn > ds)
		  {
			dir = SE;
		  }
		  else if (ds > dn)
		  {
			dir = NE;
		  }
		}
		return dir;
	  }
	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		data.doubleSided = true;
		RenderBuffers buf = dest.getBuffers(buffersIdx);
		SubTexture st = textures[0];







