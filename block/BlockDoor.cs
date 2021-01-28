






using System.Collections.Generic;

namespace jfcraft.block
{
	/// <summary>
	/// Doors
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce.gl;

	using jfcraft.audio;
	using jfcraft.client;
	using jfcraft.data;
	using jfcraft.opengl;
	using static jfcraft.data.Direction;
	using static jfcraft.data.Blocks;

	public class BlockDoor : BlockBase
	{
	  private static GLModel model_upper, model_lower;

	  public BlockDoor(string id, string[] names, string[] images) : base(id, names, images)
	  {
		isOpaque = false;
		isAlpha = false;
		isComplex = true;
		isSolid = false;
		isRedstone = true;
		isVar = true;
		isDir = true;
		isDirXZ = true;
		canUse = true;
		model_upper = Assets.getModel("door_upper").model;
		model_lower = Assets.getModel("door_lower").model;
		varMask = 0x7; //remove VAR_UPPER
		cantGive = true; //give item instead
	  }

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		RenderBuffers buf = dest.getBuffers(buffersIdx);
		ExtraRedstone er = (ExtraRedstone)data.chunk.getExtra((int)data.x, (int)data.y, (int)data.z, Extras.REDSTONE);
		if (er == null)
		{
		  Static.log("BlockDoor.buildBuffers():Error:Can not find extra data");
		  return;
		}
		SubTexture st;
		GLObject obj;

		if ((data.var[X] & VAR_UPPER) == VAR_UPPER)
		{
		  //upper
		  st = textures[(data.var[X] & varMask) * 2];
		  obj = model_upper.getObject("DOOR_UPPER");
		}
		else
		{
		  //lower
		  st = textures[(data.var[X] & varMask) * 2 + 1];
		  obj = model_lower.getObject("DOOR_LOWER");
		}

		int dir = data.dir[X];
		if (er.active)
		{
		  switch (dir)
		  {
			case N:
				data.dir[X] = W;
				break;
			case E:
				data.dir[X] = S;
				break;
			case S:
				data.dir[X] = E;
				break;
			case W:
				data.dir[X] = N;
				break;
		  }
		}
		switch (data.dir[X])
		{
		  case E:
			  data.rotate = -90;
			  data.translate_pst = new float[] {0.8125f, 0, 0};
			  break;
		  case W:
			  data.rotate = -90;
			  data.translate_pst = new float[] {-0.8125f, 0, 0};
			  break;
		}
		buildBuffers(obj, buf, data, st);
		data.rotate = 90;
		data.translate_pst = null;
	  }
	  public override List<Box> getBoxes(Coords c, BlockHitTest_Type type)
	  {
		ExtraRedstone er = (ExtraRedstone)c.chunk.getExtra(c.gx, c.gy, c.gz, Extras.REDSTONE);
		if (er == null)
		{
		  Static.log("BlockDoor.getBoxes():Error:Can not find Redstone data");
		  return base.getBoxes(c, type); //avoid NPE
		}
		List<Box> list = new List<Box>();
		int bits = c.chunk.getBits(c.gx, c.gy, c.gz);
		int dir = Chunk.getDir(bits);
		if (er.active)
		{
		  switch (dir)
		  {
			case N:
				dir = W;
				break;
			case E:
				dir = S;
				break;
			case S:
				dir = E;
				break;
			case W:
				dir = N;
				break;
		  }
		}
		switch (dir)
		{
		  case N:
			  list.Add(new Box(0, 0, 0, 16,16, 3));
			  break;
		  case E:
			  list.Add(new Box(14, 0, 0, 16,16,16));
			  break;
		  case S:
			  list.Add(new Box(0, 0,14, 16,16,16));
			  break;
		  case W:
			  list.Add(new Box(0, 0, 0, 3,16,16));







