namespace jfcraft.packet
{
	/// <summary>
	/// Packet with two Ints
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;
	using Server = jfcraft.server.Server;

	public class PacketChunkRequest : Packet
	{
	  public int cx, cz;
	  public bool load;

	  public PacketChunkRequest()
	  {
	  }

	  public PacketChunkRequest(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketChunkRequest(sbyte cmd, int cx, int cz, bool load) : base(cmd)
	  {
		this.cx = cx;
		this.cz = cz;
		this.load = load;
	  }

	  //process on server side
	  public virtual void process(Server server, Client client)
	  {
		if (load)
		{
		  server.chunkWorker.add(client.player.dim, cx, cz, client.serverTransport);
		  client.loadChunk(cx, cz);
		}
		else
		{
		  client.unloadChunk(cx, cz);
		}
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		buffer.writeInt(cx);
		buffer.writeInt(cz);
		buffer.writeBoolean(load);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		cx = buffer.readInt();
		cz = buffer.readInt();
		load = buffer.readBoolean();
		return true;
	  }
	}

}