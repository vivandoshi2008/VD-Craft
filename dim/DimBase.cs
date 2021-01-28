namespace jfcraft.dim
{
	/// <summary>
	/// Dimension base.
	/// 
	/// Defines how to generate a dimension
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.light;
	using jfcraft.env;
	using jfcraft.gen;
	using jfcraft.data;

	public abstract class DimBase
	{
	  public int id;
	  public abstract string Name {get;}
	  public virtual void getIDs(World world)
	  {
	  }
	  public virtual void init()
	  {
		GeneratorPhase1.IDs;
		GeneratorPhase2.IDs;
		GeneratorPhase3.IDs;
	  }
	  public abstract GeneratorPhase1Base GeneratorPhase1 {get;}
	  public abstract GeneratorPhase2Base GeneratorPhase2 {get;}
	  public abstract GeneratorPhase3Base GeneratorPhase3 {get;}
	  public abstract LightingBase LightingServer {get;}
	  public abstract LightingBase LightingClient {get;}
	  public abstract EnvironmentBase Environment {get;}
	  public abstract void spawnMonsters(Chunk chunk);
	}

}