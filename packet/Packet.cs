namespace jfcraft.packet
{
	/// <summary>
	/// Base class for requests and replies.
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.client;
	using jfcraft.data;
	using jfcraft.server;

	public class Packet : SerialClass
	{
	  public sbyte cmd; //command

	  public Packet(sbyte cmd)
	  {
		this.cmd = cmd;
	  }

	  public static Packet packet = new Packet();

	  public Packet()
	  {
	  }

	  //process on client side
	  public virtual void process(Client client)
	  {
		Static.logTrace("Error:Packet.process() called (client side)");
	  }

	  //process on server side
	  public virtual void process(Server server, Client client)
	  {
		Static.logTrace("Error:Packet.process() called (server side)");
	  }

	  public virtual bool write(SerialBuffer buffer, bool file)
	  {
		buffer.writeByte(cmd);
		return true;
	  }

	  public virtual bool read(SerialBuffer buffer, bool file)
	  {
		cmd = buffer.readByte();
		return true;
	  }
	}

}