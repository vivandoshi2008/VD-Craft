namespace jfcraft.packet
{
	/// <summary>
	/// Packet with 1 Int + 1 Float
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.client;
	using jfcraft.data;
	using jfcraft.entity;

	public class PacketHealth : Packet
	{
	  public int i1;
	  public float f1;

	  public PacketHealth()
	  {
	  }

	  public PacketHealth(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketHealth(sbyte cmd, int i1, float f1) : base(cmd)
	  {
		this.i1 = i1;
		this.f1 = f1;
	  }

	  //process on client side
	  public override void process(Client client)
	  {
		int uid = i1;
		float health = f1;
		CreatureBase e;
		if (uid == client.UID)
		{
		  e = client.player;
		  if (health == 0)
		  {
			Static.video.Screen = Static.screens.screens[Client.DEAD];
		  }
		}
		else
		{
		  e = (CreatureBase)client.world.getEntity(uid);
		}
		if (e == null)
		{
			return;
		}
		e.health = health;
		if (e.cracks())
		{
		  e.buildBuffers(e.Dest, null);
		}
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		buffer.writeInt(i1);
		buffer.writeFloat(f1);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		i1 = buffer.readInt();
		f1 = buffer.readFloat();
		return true;
	  }
	}

}