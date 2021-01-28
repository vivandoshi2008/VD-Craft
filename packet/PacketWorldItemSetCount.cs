namespace jfcraft.packet
{
	/// <summary>
	/// Packet (WorldItem Set Count)
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;
	using jfcraft.entity;
	using jfcraft.item;

	public class PacketWorldItemSetCount : Packet
	{
	  public int i1;
	  public sbyte b1;

	  public PacketWorldItemSetCount()
	  {
	  }

	  public PacketWorldItemSetCount(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketWorldItemSetCount(sbyte cmd, int uid, sbyte count) : base(cmd)
	  {
		this.i1 = uid;
		this.b1 = count;
	  }

	  //process on client side
	  public virtual void process(Client client)
	  {
		int uid = i1;
		WorldItem e = (WorldItem)client.world.getEntity(uid);
		if (e == null)
		{
		  Static.log("Entity not found:" + uid);
		  return;
		}
		Static.log("worlditem.count=" + b1);
		e.item.count = b1;
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		buffer.writeInt(i1);
		buffer.writeByte(b1);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		i1 = buffer.readInt();
		b1 = buffer.readByte();
		return true;
	  }
	}

}