






using System.Collections.Generic;

namespace jfcraft.block
{
	/// <summary>
	/// Sign
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce.gl;

//	import static jfcraft.block.BlockBase.boxListEmpty;

	using jfcraft.data;
	using jfcraft.client;
	using jfcraft.opengl;
	using static jfcraft.data.Direction;
	using WorldItem = jfcraft.entity.WorldItem;
	using Item = jfcraft.item.Item;

	public class BlockSign : BlockBase
	{
	  private static GLModel model;
	  private static List<Box> lb = new List<Box>();
	  private static List<Box> ln = new List<Box>();
	  private static List<Box> le = new List<Box>();
	  private static List<Box> ls = new List<Box>();
	  private static List<Box> lw = new List<Box>();
	  public BlockSign(string name, string[] names, string[] images) : base(name, names, images)
	  {
		isOpaque = false;
		isAlpha = false;
		isComplex = true;
		isSolid = false;
		isDirFace = true;
		isDirXZ = true; //only if dir != B (needed so Faces.rotate() rotates properly)
		dropBlock = "SIGN_ITEM";
		cantGive = true; //must give item
		isSupported = true;
		resetBoxes(BlockHitTest_Type.ENTITY);
		if (model == null)
		{
		  model = Assets.getModel("sign").model;
		  lb.Add(new Box(4, 0, 4, 12,16,12));
		  ln.Add(new Box(0, 3, 0, 16,14, 2));
		  le.Add(new Box(14, 3, 0, 16,14,16));
		  ls.Add(new Box(0, 3,14, 16,14,16));
		  lw.Add(new Box(0, 3, 0, 2,14,16));
		}
	  }

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		if (data.chunk == null)
		{
		  Static.log("BlockSign.buildBuffer() as item???");
		  return;
		}
		ExtraSign er = (ExtraSign)data.chunk.getExtra((int)data.x, (int)data.y, (int)data.z, Extras.SIGN);
		if (er == null)
		{
		  Static.log("BlockSign.buildBuffer() : can not find extra data");
		  er = new ExtraSign();
		}
		RenderBuffers buf = dest.getBuffers(buffersIdx);
		int dir = data.dir[X];
		if (dir == B)
		{
		  data.yrotate = true;
		  data.rotate = er.dir;
		  buildBuffers(model.getObject("SIGN"), buf, data, textures[0]);
		  buildBuffers(model.getObject("POST"), buf, data, textures[0]);
		  data.translate_pre = new float[] {0, 0.25f, Static._1_16 + Static._1_32};
		  addText(dest, er.txt, data);
		}
		else
		{
		  float y = -0.25f;
		  switch (dir)
		  {
			case N:
			  data.translate_pst = new float[] {0, y, -Static._1_16 * 7f};
			  break;
			case E:
			  data.translate_pst = new float[] {Static._1_16 * 7f, y, 0};
			  break;
			case S:
			  data.translate_pst = new float[] {0, y, Static._1_16 * 7f};
			  break;
			case W:
			  data.translate_pst = new float[] {-Static._1_16 * 7f, y, 0};
			  break;
		  }
		  buildBuffers(model.getObject("SIGN"), buf, data, textures[0]);
		  data.translate_pst[1] = 0;
		  switch (dir)
		  {
			case N:
			  data.translate_pst[2] += Static._1_16 + Static._1_32;
			  break;
			case E:
			  data.translate_pst[0] -= Static._1_16 + Static._1_32;
			  break;
			case S:
			  data.translate_pst[2] -= Static._1_16 + Static._1_32;
			  break;
			case W:
			  data.translate_pst[0] += Static._1_16 + Static._1_32;
			  break;
		  }
		  addText(dest, er.txt, data);
		}
		data.resetRotate();
	  }

	  public override bool place(Client client, Coords c)
	  {
		if (!canPlace(c))
		{
			return false;
		}
		int dir = 0;
		dir = c.dir;
		if (dir == A)
		{
			return false;
		}
		int var = 0;
		int bits = Chunk.makeBits(dir, var);
		ExtraSign extra = new ExtraSign(c.gx,c.gy,c.gz);
		if (dir == B)
		{
		  extra.dir = client.player.ang.y;
		}
		c.chunk.addExtra(extra);
		Static.server.broadcastExtra(c.chunk.dim, c.x, c.y, c.z, extra, false);
		c.chunk.setBlock(c.gx,c.gy,c.gz,id,bits);
		Static.server.broadcastSetBlock(c.chunk.dim,c.x,c.y,c.z,id,bits);
		client.sign = extra;







