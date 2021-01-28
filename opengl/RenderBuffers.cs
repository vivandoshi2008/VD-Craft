






using System;
using System.Collections.Generic;

namespace jfcraft.opengl
{
	/// <summary>
	/// Render Buffers holds all vertex points, and polygons (usually triangles).
	/// All polygons share the same orientation (rotation, translation, scale).
	/// </summary>

	using javaforce;
	using javaforce.gl;

	//	import static javaforce.gl.GL.*;

	using jfcraft.data;
	using static jfcraft.data.Direction;

	public class RenderBuffers : ICloneable
	{
		private JFArrayFloat vpl; //vertex position list
		private JFArrayFloat uvl1; //texture coords list (normal)
		private JFArrayFloat uvl2; //texture coords list (overlay) (cracks)
		private JFArrayInt vil; //vertex index list
		private JFArrayFloat lcl; //light color list
		private JFArrayFloat sll; //sun light list
		private JFArrayFloat bll; //block light list

		public int type; //GL_TRIANGLES or GL_QUADS

		public virtual bool ArrayEmpty
		{
			get
			{
				return vil.size() == 0;
			}
		}
		public virtual bool BufferEmpty
		{
			get
			{
				return idxCnt == 0;
			}
		}

		public bool visible;
		public GLMatrix mat; //current rotation, translation, scale (not used by chunks)
		public GLVertex org; //origin (default = 0.0f,0.0f,0.0f) (pivot point) (loaded from file)
		public GLVertex center; //calc center point (to scale) (must call callCenter())
		public bool alloced = false;
		public int vpb, uvb1, uvb2, vib, lcb, slb, blb; //GL Buffers
		public int idxCnt;

		private static List<int[]> freeList = new List<int[]>();
		private static void addFreeList(int[] bufs)
		{
			lock (freeList)
			{
				freeList.Add(bufs);
			}
		}
		public static void freeBuffers()
		{
			lock (freeList)
			{
				while (freeList.Count > 0)
				{
					int[] ids = freeList.RemoveAt(0);
					//        Static.log("Free GL IDs:" + ids.length);
					glDeleteBuffers(ids.Length, ids);
				}
			}
		}

		private static float[] uvZero = new float[] { 0, 0 };

		public RenderBuffers()
		{
			vpl = new JFArrayFloat();
			uvl1 = new JFArrayFloat();
			uvl2 = new JFArrayFloat();
			vil = new JFArrayInt();
			lcl = new JFArrayFloat();
			sll = new JFArrayFloat();
			bll = new JFArrayFloat();
			visible = true;
			org = new GLVertex();
			mat = new GLMatrix();
			type = GL_QUADS; //default = QUADS
		}

		~RenderBuffers()
		{
			if (alloced)
			{
				addFreeList(new int[] { vpb, uvb1, uvb2, vib, lcb, slb, blb });
			}
		}

		public virtual bool Visible
		{
			set
			{
				visible = value;
			}
		}
		private GLMatrix tmp = new GLMatrix();
		public virtual void addRotate(float angle, float x, float y, float z, GLVertex org)
		{
			//rotates relative to org
			tmp.setAA(angle, x, y, z); //set rotation
			tmp.addTranslate(org.x, org.y, org.z); //set translation
			mat.mult4x4(tmp); //add it
							  //now undo translation
			tmp.setIdentity3x3(); //remove rotation
			tmp.reverseTranslate();
			mat.mult4x4(tmp);
		}
		public virtual void addTranslate(float x, float y, float z)
		{
			mat.addTranslate(x, y, z);
		}
		public virtual void addScale(float x, float y, float z)
		{
			mat.addScale(x, y, z);
		}
		public virtual void reset()
		{
			//    mat.setIdentity();  //could be rendering...
			vpl.clear();
			uvl1.clear();
			uvl2.clear();
			vil.clear();
			lcl.clear();
			sll.clear();
			bll.clear();
		}
		public virtual void addVertex(float[] xyz)
		{
			vpl.append(xyz);
		}
		public virtual void addVertex(float x, float y, float z)
		{
			vpl.append(x);
			vpl.append(y);
			vpl.append(z);
		}
		/// <summary>
		/// Add vertex with texture coords. </summary>
		public virtual void addVertex(float[] xyz, float[] uv)
		{
			vpl.append(xyz);
			uvl1.append(uv);
			int cnt = uv.Length / 2;
			for (int a = 0; a < cnt; a++)
			{
				uvl2.append(uvZero);
			}
		}
		/// <summary>
		/// Add vertex with texture coords and overlay texture coords. </summary>
		public virtual void addVertex(float[] xyz, float[] uv1, float[] uv2)
		{
			vpl.append(xyz);
			uvl1.append(uv1);
			uvl2.append(uv2);
		}
		public virtual void addVertex(float x, float y, float z, float u, float v)
		{
			vpl.append(x);
			vpl.append(y);
			vpl.append(z);
		}
	}
}







