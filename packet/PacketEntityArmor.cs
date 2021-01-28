namespace jfcraft.packet
{
	/// <summary>
	/// Packet (Entity Armor Change)
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;
	using jfcraft.entity;
	using jfcraft.item;

	public class PacketEntityArmor : Packet
	{
	  public int i1;
	  public sbyte b1;
	  public Item item;

	  public PacketEntityArmor()
	  {
	  }

	  public PacketEntityArmor(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketEntityArmor(sbyte cmd, int uid, Item item, sbyte idx) : base(cmd)
	  {
		this.i1 = uid;
		this.item = item;
		this.b1 = idx;
	  }

	  //process on client side
	  public virtual void process(Client client)
	  {
		int uid = i1;
		HumaniodBase e = (HumaniodBase)client.world.getEntity(uid);
		if (e == null)
		{
		  Static.log("Entity not found:" + uid);
		  return;
		}
		e.armors[b1] = item;
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		buffer.writeInt(i1);
		item.write(buffer, file);
		buffer.writeByte(b1);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		i1 = buffer.readInt();
		item = new Item();
		item.read(buffer, file);
		b1 = buffer.readByte();
		return true;
	  }
	}

}