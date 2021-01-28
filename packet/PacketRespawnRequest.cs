namespace jfcraft.packet
{
	/// <summary>
	/// Packet with no data
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.client;
	using jfcraft.data;
	using Server = jfcraft.server.Server;

	public class PacketRespawnRequest : Packet
	{
	  public PacketRespawnRequest()
	  {
	  }

	  public PacketRespawnRequest(sbyte cmd) : base(cmd)
	  {
	  }

	  //process on server side
	  public virtual void process(Server server, Client client)
	  {
		if (client.player.health != 0)
		{
		  Static.log("Attempt to respawn but not dead!");
		  return;
		}
		client.player.dim = 0;
		client.player.pos.x = server.world.spawn.x;
		client.player.pos.y = server.world.spawn.y;
		client.player.pos.z = server.world.spawn.z;
		client.player.adjustSpawnPosition();
		client.player.health = 20;
		client.player.hunger = 20;
		client.player.saturation = 20;
		client.player.exhaustion = 0;
		Chunk chunk = client.player.Chunk;
		if (chunk == null)
		{
		  int cx = Static.floor(client.player.pos.x / 16f);
		  int cz = Static.floor(client.player.pos.z / 16f);
		  chunk = server.world.chunks.getChunk2(client.player.dim, cx, cz, true, true, true);
		}
		chunk.addEntity(client.player);
		server.world.addEntity(client.player);
		server.broadcastEntitySpawn(client.player);
		client.serverTransport.respawn(client.player.pos.x, client.player.pos.y, client.player.pos.z);
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		return true;
	  }
	}

}