namespace jfcraft.packet
{
	/// <summary>
	/// Packet with Player
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;
	using jfcraft.entity;

	public class PacketPlayer : Packet
	{
	  public Player player;
	  public int uid;

	  public PacketPlayer()
	  {
	  }

	  public PacketPlayer(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketPlayer(sbyte cmd, Player player) : base(cmd)
	  {
		this.player = player;
	  }

	  //process on client side
	  public virtual void process(Client client)
	  {
		client.player = player;
		client.world.addEntity(player);
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		player.write(buffer, true); //must write everything
		buffer.writeInt(player.uid); //player.write(file) writes cid, not uid
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		player = new Player();
		player.init(Static.client.world);
		player.read(buffer, true); //must read everything
		player.uid = buffer.readInt();
		return true;
	  }
	}

}