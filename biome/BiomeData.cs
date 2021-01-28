namespace jfcraft.biome
{
	/// <summary>
	/// Biome Random Data
	/// </summary>

	using jfcraft.data;
	using jfcraft.gen;
	using static jfcraft.data.Static;

	public class BiomeData
	{
	  public int b1; //per block
	  public int b2; //per block
	  public int b3; //per block

	  public float bf1; //per block
	  public float bf2; //per block
	  public float bf3; //per block

	  public int c1; //per chunk
	  public int c2; //per chunk
	  public int c3; //per chunk

	  public float cf1; //per chunk
	  public float cf2; //per chunk
	  public float cf3; //per chunk

	  public float temp; //0-100
	  public float rain; //0-100

	  public int cx, cz;
	  public int wx, wz;

	  public virtual void setChunk(Chunk chunk)
	  {
		cx = chunk.cx;
		cz = chunk.cz;
		wx = chunk.cx * 16;
		wz = chunk.cz * 16;

		generateChunkValues();
	  }

	  public virtual void setChunk(GeneratorChunk chunk)
	  {
		cx = chunk.cx;
		cz = chunk.cz;
		wx = chunk.cx * 16;
		wz = chunk.cz * 16;

		generateChunkValues();
	  }

	  private void generateChunkValues()
	  {
		c1 = noiseInt(N_RANDOM1, int.MaxValue, cx, cz);
		c2 = noiseInt(N_RANDOM2, int.MaxValue, cx, cz);
		c3 = noiseInt(N_RANDOM3, int.MaxValue, cx, cz);

		cf1 = noiseFloat(N_RANDOM1, int.MaxValue, cx, cz);
		cf2 = noiseFloat(N_RANDOM2, int.MaxValue, cx, cz);
		cf3 = noiseFloat(N_RANDOM3, int.MaxValue, cx, cz);
	  }

	  public virtual void setBlock(int x, int z)
	  {
		b1 = noiseInt(N_RANDOM1, int.MaxValue, wx + x, wz + z);
		b2 = noiseInt(N_RANDOM2, int.MaxValue, wx + x, wz + z);
		b3 = noiseInt(N_RANDOM3, int.MaxValue, wx + x, wz + z);

		bf1 = noiseFloat(N_RANDOM1, int.MaxValue, wx + x, wz + z);
		bf2 = noiseFloat(N_RANDOM2, int.MaxValue, wx + x, wz + z);
		bf3 = noiseFloat(N_RANDOM3, int.MaxValue, wx + x, wz + z);
	  }
	}

}