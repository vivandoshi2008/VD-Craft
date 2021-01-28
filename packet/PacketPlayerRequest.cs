namespace jfcraft.packet
{
	/// <summary>
	/// Packet with no data
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;
	using Server = jfcraft.server.Server;

	public class PacketPlayerRequest : Packet
	{

	  public PacketPlayerRequest()
	  {
	  }

	  public PacketPlayerRequest(sbyte cmd) : base(cmd)
	  {
	  }

	  //process on server side
	  public virtual void process(Server server, Client client)
	  {
		if (client.player != null)
		{
			return;
		}
		client.player = server.loadPlayer(client.name);
		if (client.player == null)
		{
		  client.player = server.createPlayer(client.name);
		  server.spawnPlayer(client.player);
		}
		client.player.offline = true;
		client.player.uid = server.world.generateUID();
		client.player.client = client;
		Static.log("player uid=" + client.player.uid);
		int cx = Static.floor(client.player.pos.x / 16.0f);
		int cz = Static.floor(client.player.pos.z / 16.0f);
		Chunk chunk = server.world.chunks.getChunk2(client.player.dim, cx,cz,true, true, true);
		chunk.addEntity(client.player);
		server.world.addEntity(client.player);
		client.serverTransport.sendPlayer(client);
		server.broadcastEntitySpawn(client.player);
	  }
	}

}