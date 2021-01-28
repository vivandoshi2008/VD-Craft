using System;

namespace jfcraft.block
{
	/// <summary>
	/// Block that represent empty space
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce;

	using jfcraft.data;
	using jfcraft.opengl;

	public class BlockAir : BlockBase
	{
	  public BlockAir(string name) : base(name, new string[] {"Air"}, new string[0])
	  {
		canReplace = true;
		isOpaque = false;
		isSolid = false;
		isComplex = true; //BlockLiquid.canFill() depends on this
		canSpawnOn = false;
		resetBoxes(BlockHitTest_Type.BOTH);
	  }
	  public override void addFace(RenderBuffers obj, RenderData data, SubTexture st)
	  {
		try
		{
		  Static.log("BlockAir:addFace():id=" + (int)id);
		}
		catch (Exception e)
		{
		  Static.log(e);
		}
	  }
	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		try
		{
		  Static.log("BlockAir:buildBuffers():id=" + (int)id);
		}
		catch (Exception e)
		{
		  Static.log(e);
		}
	  }
	}

}