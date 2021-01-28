






using System.Collections.Generic;

namespace jfcraft.block
{
	/// <summary>
	/// Gates
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

	public class BlockGate : BlockBase
	{
	  private static GLModel model_closed, model_open;

	  public BlockGate(string id, string[] names, string[] images) : base(id, names, images)
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
		model_closed = Assets.getModel("gate").model;
		model_open = Assets.getModel("gate_open").model;
	  }

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		RenderBuffers buf = dest.getBuffers(buffersIdx);
		bool opened = false;
		if (data.chunk != null)
		{
		  ExtraRedstone er = (ExtraRedstone)data.chunk.getExtra((int)data.x, (int)data.y, (int)data.z, Extras.REDSTONE);
		  if (er == null)
		  {
			Static.log("BlockGate.buildBuffers():Error:Can not find extra data");
			return;
		  }
		  opened = er.active;
		}
		SubTexture st = getTexture(data);
		GLObject obj;

		if (opened)
		{
		  //opened
		  obj = model_open.getObject("GATE");
		}
		else
		{
		  //lower
		  obj = model_closed.getObject("GATE");
		}

		buildBuffers(obj, buf, data, st);
	  }
	  public override List<Box> getBoxes(Coords c, BlockHitTest_Type type)
	  {
		ExtraRedstone er = (ExtraRedstone)c.chunk.getExtra(c.gx, c.gy, c.gz, Extras.REDSTONE);
		if (er == null)
		{
		  Static.log("BlockGate.getBoxes():Error:Can not find Redstone data");
		  return base.getBoxes(c, type); //avoid NPE
		}
		List<Box> list = new List<Box>();
		if (type == BlockHitTest_Type.ENTITY && er.active)
		{
			return list; //gate open
		}
		int bits = c.chunk.getBits(c.gx, c.gy, c.gz);
		int dir = Chunk.getDir(bits);
		switch (dir)
		{
		  case N:
		  case S:
			list.Add(new Box(0, 0, 7, 16,16, 9));
			break;
		  case E:
		  case W:
			list.Add(new Box(7, 0, 0, 9,16,16));
			break;
		}
		return list;
	  }
	  public override bool place(Client client, Coords c)
	  {
		if (c.dir_xz < N || c.dir_xz > W)
		{
		  Static.log("Gate:Can not place:xzdir invalid");
		  return false;
		}
		int bits = Chunk.makeBits(c.dir_xz,c.var);
		if (!c.chunk.setBlockIfEmpty(c.gx,c.gy,c.gz,id,bits))
		{
			return false;
		}
		ExtraRedstone er = new ExtraRedstone(c.gx, c.gy, c.gz);
		c.chunk.addExtra(er);
		Static.server.broadcastExtra(c.chunk.dim, c.x, c.y, c.z, er, true);
		Static.server.broadcastSetBlock(c.chunk.dim,c.x,c.y,c.z,id,bits);
		return true;
	  }
	  public override void activate(Client client, Coords c)
	  {
	//    Static.log("gate activate:" + c);
		ExtraRedstone er = (ExtraRedstone)c.chunk.getExtra(c.gx, c.gy, c.gz, Extras.REDSTONE);
		if (er == null)
		{
		  return;
		}
		if (er.active)
		{
		  return; //already active
		}
		er.active = true;
		//switch dir if needed
		if (client != null)
		{
		  int bits = c.chunk.getBits(c.gx, c.gy, c.gz);
		  int dir = Chunk.getDir(bits);
		  int var = Chunk.getVar(bits);
		  Coords p = new Coords();
		  client.player.getDir(p);
		  p.otherSide();
		  int pdir = p.dir_xz;
		  int newdir = dir;
		  if (dir == N && pdir == S)
		  {
			newdir = S;
		  }
		  else if (dir == S && pdir == N)
		  {
			newdir = N;
		  }
		  else if (dir == E && pdir == W)
		  {
			newdir = W;
		  }
		  else if (dir == W && pdir == E)
		  {
			newdir = E;
		  }
		  //need to switch dir so door opens away from player
		  if (newdir != dir)
		  {
			bits = Chunk.makeBits(newdir, var);
			c.chunk.setBlock(c.gx, c.gy, c.gz, id, bits);
			Static.server.broadcastSetBlock(c.chunk.dim, c.x, c.y, c.z, id, bits);
		  }
		}
		Static.server.broadcastExtra(c.chunk.dim,c.x,c.y,c.z,er,true);
		Static.server.broadcastSound(c.chunk.dim, c.x, c.y, c.z, Sounds.SOUND_DOOR, 1);
	  }







