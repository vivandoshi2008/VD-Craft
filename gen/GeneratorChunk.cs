






using System;

namespace jfcraft.gen
{
	/// <summary>
	/// GeneratorChunk
	/// 
	/// Used in phase 1 of chunk generation.
	/// 
	/// Optimized for fast fills.
	/// 
	/// </summary>


	using jfcraft.data;

	public class GeneratorChunk
	{
		private char[] blocks = new char[16 * 256 * 16];
		private sbyte[] bits = new sbyte[16 * 256 * 16];
		private char[] blocks2 = new char[16 * 256 * 16];
		private sbyte[] bits2 = new sbyte[16 * 256 * 16];

		public sbyte[] biome = new sbyte[16 * 16];
		public float[] temp = new float[16 * 16];
		public float[] rain = new float[16 * 16];
		public float[] elev = new float[16 * 16];
		public float[] depth = new float[16 * 16];

		public bool[] river = new bool[16 * 16];

		public int dim, cx, cz;
		public long seed;

		public virtual void clear()
		{
			Arrays.Fill(blocks, (char)0);
			Arrays.Fill(bits, (sbyte)0);
			Arrays.Fill(blocks2, (char)0);
			Arrays.Fill(bits2, (sbyte)0);
			Arrays.Fill(biome, (sbyte)0);
			Arrays.Fill(temp, 0f);
			Arrays.Fill(rain, 0f);
			Arrays.Fill(elev, 0f);
			Arrays.Fill(depth, 0f);
			Arrays.Fill(river, false);
		}

		public virtual void setBlock(int x, int y, int z, char id, int _bits)
		{
			if (x < 0)
			{
				return;
			}
			if (x > 15)
			{
				return;
			}
			if (y < 0)
			{
				return;
			}
			if (y > 255)
			{
				return;
			}
			if (z < 0)
			{
				return;
			}
			if (z > 15)
			{
				return;
			}
			blocks[y * 256 + z * 16 + x] = id;
			bits[y * 256 + z * 16 + x] = (sbyte)_bits;
		}

		public virtual void setBlock2(int x, int y, int z, char id, int _bits)
		{
			if (x < 0)
			{
				return;
			}
			if (x > 15)
			{
				return;
			}
			if (y < 0)
			{
				return;
			}
			if (y > 255)
			{
				return;
			}
			if (z < 0)
			{
				return;
			}
			if (z > 15)
			{
				return;
			}
			blocks2[y * 256 + z * 16 + x] = id;
			bits2[y * 256 + z * 16 + x] = (sbyte)_bits;
		}

		public virtual void clearBlock(int x, int y, int z)
		{
			if (x < 0)
			{
				return;
			}
			if (x > 15)
			{
				return;
			}
			if (y < 0)
			{
				return;
			}
			if (y > 255)
			{
				return;
			}
			if (z < 0)
			{
				return;
			}
			if (z > 15)
			{
				return;
			}
			blocks[y * 256 + z * 16 + x] = (char)0;
			bits[y * 256 + z * 16 + x] = 0;
		}

		public virtual void clearBlock2(int x, int y, int z)
		{
			if (x < 0)
			{
				return;
			}
			if (x > 15)
			{
				return;
			}
			if (y < 0)
			{
				return;
			}
			if (y > 255)
			{
				return;
			}
			if (z < 0)
			{
				return;
			}
			if (z > 15)
			{
				return;
			}
			blocks2[y * 256 + z * 16 + x] = (char)0;
			bits2[y * 256 + z * 16 + x] = 0;
		}

		public virtual char getBlock(int x, int y, int z)
		{
			if (x < 0)
			{
				return (char)0;
			}
			if (x > 15)
			{
				return (char)0;
			}
			if (y < 0)
			{
				return (char)0;
			}
			if (y > 255)
			{
				return (char)0;
			}
			if (z < 0)
			{
				return (char)0;
			}
			if (z > 15)
			{
				return (char)0;
			}
		}
	}
}




