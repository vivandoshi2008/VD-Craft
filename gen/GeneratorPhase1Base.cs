namespace jfcraft.gen
{
	/// <summary>
	/// Base for all phase 1 generators.
	/// 
	/// @author vivandoshi
	/// </summary>

	using Chunk = jfcraft.data.Chunk;

	public interface GeneratorPhase1Base
	{
	  void getIDs();
	  Chunk generate(int dim, int cx, int cz);
	  void reset();
	}

}