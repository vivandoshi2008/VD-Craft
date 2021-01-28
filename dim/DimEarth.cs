using System;

namespace jfcraft.dim
{
	/// <summary>
	/// Dimension : Earth.
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.data;
	using EntityBase = jfcraft.entity.EntityBase;
	using jfcraft.light;
	using jfcraft.gen;
	using jfcraft.env;

	public class DimEarth : DimBase
	{
	  private EntityBase[] mobs;

	  public override string Name
	  {
		  get
		  {
			return "earth";
		  }
	  }

	  public override void init()
	  {
		base.init();
		mobs = Static.entities.listSpawn(id);
	  }

	  private GeneratorPhase1Base phase1 = new GeneratorPhase1Earth();

	  public override GeneratorPhase1Base GeneratorPhase1
	  {
		  get
		  {
			return phase1;
		  }
	  }

	  private GeneratorPhase2Base phase2 = new GeneratorPhase2Earth();

	  public override GeneratorPhase2Base GeneratorPhase2
	  {
		  get
		  {
			return phase2;
		  }
	  }

	  private GeneratorPhase3Base phase3 = new GeneratorPhase3Earth();

	  public override GeneratorPhase3Base GeneratorPhase3
	  {
		  get
		  {
			return phase3;
		  }
	  }

	  private LightingBase light_client = new LightingEarth();
	  private LightingBase light_server = new LightingEarth();

	  public override LightingBase LightingServer
	  {
		  get
		  {
			return light_server;
		  }
	  }
	  public override LightingBase LightingClient
	  {
		  get
		  {
			return light_client;
		  }
	  }

	  private EnvironmentBase env = new EnvironmentEarth();

	  public override EnvironmentBase Environment
	  {
		  get
		  {
			return env;
		  }
	  }

	  private Random r = new Random();

	  public override void spawnMonsters(Chunk chunk)
	  {
		if (chunk.dim != Dims.EARTH)
		{
			return;
		}
		int idx = r.Next(mobs.Length);
		EntityBase eb = mobs[idx];
		if (r.nextFloat() * 100.0f > eb.SpawnRate)
		{
		  return;
		}
		EntityBase e = eb.spawn(chunk);
		if (e == null)
		{
		  return;
		}
		e.uid = Static.server.world.generateUID();
		Static.log("spawn " + e.Name + " @dim= " + chunk.dim + ":x=" + e.pos.x + ",z=" + e.pos.z + ":uid=" + e.uid);
		chunk.addEntity(e);
		Static.server.world.addEntity(e);
		Static.server.broadcastEntitySpawn(e);
	  }
	}

}