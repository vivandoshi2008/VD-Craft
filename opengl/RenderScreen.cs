






using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace jfcraft.opengl
{
	/// <summary>
	/// Render scene base class
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce;
	using javaforce.gl;

	//	import static javaforce.gl.GL.*;

	using jfcraft.block;
	using jfcraft.client;
	using jfcraft.data;
	using jfcraft.item;
	using jfcraft.entity;
	using static jfcraft.data.Direction;

	public abstract class RenderScreen
	{
		public float gui_height = 512;
		public float gui_width = 512;

		public static Texture t_widgets;
		public static Texture t_icons;
		public static Texture t_text;
		public static Texture t_white; //single white pixel
		public static Texture t_white50; //single white pixel (50% alpha)
		private static Timer cursorTimer;

		// top/left=0,0 : bottom/right=1,1
		public static GLMatrix orthoItem = new GLMatrix();
		// show block at 3/4 view
		public static GLMatrix orthoBlock = new GLMatrix();
		// show two blocks
		public static GLMatrix orthoPlayer = new GLMatrix();

		public static int fontSize = 12;

		private static bool showCursor;

		private static RenderDest o_items;
		private static RenderBuffers o_box = new RenderBuffers();
		private static RenderData data = new RenderData();

		private static RenderBuffers[] o_chars;

		public static GLMatrix identity = new GLMatrix();

		public sbyte id;
		private TextField focus;
		public List<Button> buttons = new List<Button>();
		public List<CheckBox> checkboxes = new List<CheckBox>();
		public List<TextField> fields = new List<TextField>();
		public List<ScrollBar> scrolls = new List<ScrollBar>();

		public virtual Button getButton(int idx)
		{
			return buttons[idx];
		}

		public virtual TextField getField(int idx)
		{
			return fields[idx];
		}

		public virtual ScrollBar getScrollBar(int idx)
		{
			return scrolls[idx];
		}

		public static void initStaticGL()
		{
			//ortho(left, right, bottom, top, near, far)
			orthoItem.ortho(0, 1, 1, 0, 0, 1);
			orthoBlock.ortho(-0.15f, 1.60f, -0.50f, 1.35f, -2, 2); //trial and error
			orthoBlock.addRotate(35, 1, 0, 0);
			orthoBlock.addRotate(45, 0, 1, 0);
			orthoPlayer.ortho(-1, 1, 0, 2, -1, 1);
			o_chars = new RenderBuffers[256];
			for (int a = 0; a < o_chars.Length; a++)
			{
				o_chars[a] = new RenderBuffers();
				RenderBuffers buf = o_chars[a];
				float tx1 = (a % 16) / 16.0f;
				float ty1 = Static.floor(a / 16) / 16.0f;
				float tx2 = tx1 + Static._1_16;
				float ty2 = ty1 + Static._1_16;
				int i = buf.VertexCount;
				buf.addVertex(new float[] { 0, 0, 0 }, new float[] { tx1, ty1 });
				buf.addVertex(new float[] { 1, 0, 0 }, new float[] { tx2, ty1 });
				buf.addVertex(new float[] { 1, 1, 0 }, new float[] { tx2, ty2 });
				buf.addVertex(new float[] { 0, 1, 0 }, new float[] { tx1, ty2 });
				for (int b = 0; b < 4; b++)
				{
					buf.addDefault();
				}
				buf.addPoly(new int[] { i + 3, i + 2, i + 1, i + 0 });
				buf.copyBuffers();
			}
			o_box = new RenderBuffers();
			o_box.addVertex(new float[] { 0, 0, 0 }, new float[] { 0, 0 });
			o_box.addVertex(new float[] { 1, 0, 0 }, new float[] { 1, 0 });
			o_box.addVertex(new float[] { 1, 1, 0 }, new float[] { 1, 1 });
			o_box.addVertex(new float[] { 0, 1, 0 }, new float[] { 0, 1 });
			for (int b = 0; b < 4; b++)
			{
				o_box.addDefault();
			}
			o_box.addPoly(new int[] { 3, 2, 1, 0 });
			o_box.copyBuffers();
		}

		private int FieldIndex
		{
			get
			{
				if (focus == null)
				{
					return 0;
				}
				for (int a = 0; a < fields.Count; a++)
				{
					if (fields[a] == focus)
					{
						return a;
					}
				}
				return -1;
			}
		}

		public abstract void render(int width, int height);
		public virtual void process()
		{
		}
		public virtual void resize(int width, int height)
		{
		}
		public virtual void mousePressed(int x, int y, int but)
		{
			for (int a = 0; a < buttons.Count; a++)
			{
				Button button = buttons[a];
				if (x >= button.x1 && x <= button.x2 && y >= button.y1 && y <= button.y2)
				{
					focus = null;
					button.r.run();
					return;
				}
			}
			for (int a = 0; a < checkboxes.Count; a++)
			{
				CheckBox checkbox = checkboxes[a];
				if (x >= checkbox.x1 && x <= checkbox.x2 && y >= checkbox.y1 && y <= checkbox.y2)
				{
					focus = null;
					checkbox.Selected = !checkbox.Selected;
				}
			}
		}
	}
}







