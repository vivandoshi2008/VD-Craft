






using System;

namespace jfcraft.gen
{
	/// <summary>
	/// Chunk generator phase 3 : add Biome Features
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce;
	using javaforce.gl;

	using jfcraft.data;
	using jfcraft.biome;
	using jfcraft.block;
	using jfcraft.entity;
	using jfcraft.feature;
	using TreeBase = jfcraft.tree.TreeBase;
	using static jfcraft.data.Direction;
	using static jfcraft.data.Biomes;
	using static jfcraft.block.BlockStep;

	public class GeneratorPhase3Earth : GeneratorPhase3Base
	{
		private Chunk chunk;
		private BiomeData data = new BiomeData();

		public virtual void getIDs()
		{
		}

		public virtual void reset()
		{
		}

		public virtual void generate(Chunk chunk)
		{
			this.chunk = chunk;

			chunk.needPhase3 = false;
			chunk.dirty = true;

			if (Static.server.world.options.doSteps)
			{
				smoothSteps();
			}

			addBiomeFeatures();
		}

		private void setBlock(int x, int y, int z, char id, int dir, int var)
		{
			if (y < 1)
			{
				return; //do not change bedrock
			}
			if (y > 255)
			{
				return;
			}
			Chunk c = chunk;
			while (x < 0)
			{
				c = c.W;
				x += 16;
			}
			while (x > 15)
			{
				c = c.E;
				x -= 16;
			}
			while (z < 0)
			{
				c = c.N;
				z += 16;
			}
			while (z > 15)
			{
				c = c.S;
				z -= 16;
			}
			//    if (c.getBlockType(x, y, z).id != Blocks.AIR) return;  //only replace air
			c.setBlock(x, y, z, id, Chunk.makeBits(dir, var));
		}
		private char getID(int x, int y, int z)
		{
			return chunk.getBlock(x, y, z);
		}
		private char getID2(int x, int y, int z)
		{
			return chunk.getBlock2(x, y, z);
		}
		private BlockBase getBlock(int x, int y, int z)
		{
			if (y < 0)
			{
				return null;
			}
			if (y > 255)
			{
				return null;
			}
			Chunk c = chunk;
			while (x < 0)
			{
				c = c.W;
				x += 16;
			}
			while (x > 15)
			{
				c = c.E;
				x -= 16;
			}
			while (z < 0)
			{
				c = c.N;
				z += 16;
			}
			while (z > 15)
			{
				c = c.S;
				z -= 16;
			}
			return Static.blocks.blocks[c.getBlock(x, y, z)];
		}

		public virtual void setBlock(int x, int y, int z, char id, int bits)
		{
			chunk.setBlock(x, y, z, id, bits);
		}

		private void addStepLower(int x, int y, int z, char sid)
		{
			bool n = getBlock(x, y, z - 1).isSolid;
			bool e = getBlock(x + 1, y, z).isSolid;
			bool s = getBlock(x, y, z + 1).isSolid;
			bool w = getBlock(x - 1, y, z).isSolid;
			char id = Static.blocks.blocks[sid].stepID;
			if (id == (char)0)
			{
				return;
			}
			int bits = 0;
			if (n)
			{
				bits |= QLNE | QLNW;
			}
			if (e)
			{
				bits |= QLNE | QLSE;
			}
			if (s)
			{
				bits |= QLSE | QLSW;
			}
			if (w)
			{
				bits |= QLNW | QLSW;
			}
			if (bits == 0)
			{
				return;
			}
			setBlock(x, y, z, id, bits);
		}

		private void addStepUpper(int x, int y, int z, char sid)
		{
			bool n = getBlock(x, y, z - 1).isSolid;
			bool e = getBlock(x + 1, y, z).isSolid;
			bool s = getBlock(x, y, z + 1).isSolid;
			bool w = getBlock(x - 1, y, z).isSolid;
			char id = Static.blocks.blocks[sid].stepID;
			if (id == (char)0)
			{
				return;
			}
			int bits = 0;
			if (n)
			{
				bits |= QUNE | QUNW;
			}
		}
	}
}




