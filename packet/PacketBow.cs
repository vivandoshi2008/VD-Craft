namespace jfcraft.packet
{
	/// <summary>
	/// Packet with 1 int
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;
	using jfcraft.entity;

	public class PacketBow : Packet
	{
	  public int i1;

	  public PacketBow()
	  {
	  }

	  public PacketBow(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketBow(sbyte cmd, int i1) : base(cmd)
	  {
		this.i1 = i1;
	  }

	  //process on client side
	  public virtual void process(Client client)
	  {
		client.player.bowPower = i1;
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		buffer.writeInt(i1);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		i1 = buffer.readInt();
		return true;
	  }
	}

}