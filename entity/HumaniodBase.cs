






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Base class for all Humaniod entities that can equip armor and carry items.
	/// Basically anything with the same shape as Player.
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.data;
	using jfcraft.client;
	using jfcraft.item;
	using jfcraft.block;
	using jfcraft.opengl;
	using jfcraft.packet;
	using static jfcraft.data.Direction;

	public abstract class HumaniodBase : CreatureBase
	{
	  public Item[] items;
	  public int activeSlot; //0-8
	  public Item[] armors;

	  public const sbyte items_active_slots = 9; //0-8
	  public const sbyte items_inventory = 3 * 9; //9-35
	  public const sbyte shield_idx = 4 * 9; //36

	  private static GLModel body;
	  private static RenderDest body_dest;
	  private static string[] body_parts = new string[] {"HEAD", "BODY", "L_ARM", "R_ARM", "L_LEG", "R_LEG"};
	  private const int part_head = 0;
	  private const int part_body = 1;
	  private const int part_left_arm = 2;
	  private const int part_right_arm = 3;
	  private const int part_left_leg = 4;
	  private const int part_right_leg = 5;

	  public bool disable_cull_face = false;

	  public override void initStatic()
	  {
		base.initStatic();
		body = loadModel("armor");
		body_dest = new RenderDest(body_parts.Length);
	  }

	  public override RenderDest Dest
	  {
		  get
		  {
			return body_dest;
		  }
	  }

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		for (int a = 0;a < body_parts.Length;a++)
		{
		  RenderBuffers buf = body_dest.getBuffers(a);
		  GLObject obj = body.getObject(body_parts[a]);
		  if (obj == null)
		  {
			Console.WriteLine("Warning:Couldn't find part:" + body_parts[a]);
		  }
		  buf.addVertex(obj.vpl.toArray());
		  buf.addPoly(obj.vil.toArray());
		  int cnt = obj.vpl.size();
		  for (int b = 0;b < cnt;b++)
		  {
			buf.addDefault();
		  }
		  buf.org = obj.org;
		  buf.type = obj.type;
		  buf.calcCenter();
		}
	  }

	  public virtual Item RightItem
	  {
		  get
		  {
			return items[activeSlot];
		  }
	  }

	  public virtual Item LeftItem
	  {
		  get
		  {
			if (items == null || items.Length <= shield_idx)
			{
				return null;
			}
			return items[shield_idx];
		  }
	  }

	  public override void render()
	  {
		if (disable_cull_face)
		{
			glDisable(GL_CULL_FACE);
		}
		RenderDest dest = Dest;
		int cnt = dest.count();
		for (int a = 0;a < cnt;a++)
		{
		  RenderBuffers buf = dest.getBuffers(a);
		  setMatrixModel(a, buf);
		  buf.bindBuffers();
		  buf.render();
		}
		if (disable_cull_face)
		{
			glEnable(GL_CULL_FACE);
		}
		renderArmor();
		renderItemInHand(RightItem, 1.0f, false);
		renderItemInHand(LeftItem, 1.0f, true);
	  }