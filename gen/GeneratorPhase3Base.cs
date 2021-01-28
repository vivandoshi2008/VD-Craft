namespace jfcraft.gen
{
	/// <summary>
	/// Base for all phase 3 generators.
	/// 
	/// @author vivandoshi
	/// </summary>

	using Chunk = jfcraft.data.Chunk;

	public interface GeneratorPhase3Base
	{
	  void getIDs();
	  void generate(Chunk chunk);
	  void reset();
	}

}