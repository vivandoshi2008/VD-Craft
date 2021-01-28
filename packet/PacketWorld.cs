namespace jfcraft.packet
{
	/// <summary>
	/// Packet with World
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;

	public class PacketWorld : Packet
	{
	  public World world;

	  public PacketWorld()
	  {
	  }

	  public PacketWorld(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketWorld(sbyte cmd, World world) : base(cmd)
	  {
		this.world = world;
	  }

	  //process on client side
	  public virtual void process(Client client)
	  {
		client.world = world;
		client.world.init();
		client.world.chunks = new Chunks(world);
		if (!client.clientTransport.Local)
		{
		  client.world.assignIDs();
		  Static.dims.init();
		  Static.dims.initEnvironments();
		}
		if (client.world.genSpawnAreaDone)
		{
		  client.spawnAreaDonePercent = 100;
		}
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		world.write(buffer, file);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		world = new World(false);
		world.read(buffer, file);
		return true;
	  }
	}

}