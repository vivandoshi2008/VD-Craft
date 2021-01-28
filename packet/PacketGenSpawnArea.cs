namespace jfcraft.packet
{
	/// <summary>
	/// Packet with 1 Int
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;

	public class PacketGenSpawnArea : Packet
	{
	  public int i1;

	  public PacketGenSpawnArea()
	  {
	  }

	  public PacketGenSpawnArea(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketGenSpawnArea(sbyte cmd, int i1) : base(cmd)
	  {
		this.i1 = i1;
	  }

	  //process on client side
	  public virtual void process(Client client)
	  {
		client.spawnAreaDonePercent = i1;
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