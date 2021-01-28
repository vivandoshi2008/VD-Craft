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

	public class PacketWorldRequest : Packet
	{

	  public PacketWorldRequest()
	  {
	  }

	  public PacketWorldRequest(sbyte cmd) : base(cmd)
	  {
	  }

	  //process on server side
	  public virtual void process(Server server, Client client)
	  {
		client.serverTransport.sendWorld(server.world);
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