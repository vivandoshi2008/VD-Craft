namespace jfcraft.gen
{
	/// <summary>
	/// Base for all phase 2 generators.
	/// 
	/// @author vivandoshi
	/// </summary>

	using Chunk = jfcraft.data.Chunk;

	public interface GeneratorPhase2Base
	{
	  void getIDs();
	  void generate(Chunk chunk);
	  void reset();
	}

}