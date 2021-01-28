namespace jfcraft.packet
{
	/// <summary>
	/// Packet with 3 Floats
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.client;
	using jfcraft.data;

	public class PacketRespawn : Packet
	{
	  public float f1, f2, f3;

	  public PacketRespawn()
	  {
	  }

	  public PacketRespawn(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketRespawn(sbyte cmd, float f1, float f2, float f3) : base(cmd)
	  {
		this.f1 = f1;
		this.f2 = f2;
		this.f3 = f3;
	  }

	  //process on client side
	  public override void process(Client client)
	  {
		Static.log("RESPAWN");
		lock (Static.renderLock)
		{
		  client.player.dim = 0;
		  client.player.pos.x = f1;
		  client.player.pos.y = f2;
		  client.player.pos.z = f3;
		  client.player.health = 20;
		  client.player.hunger = 20;
		  client.player.saturation = 20;
		  client.player.exhaustion = 0;
		}
		LoadingChunks menu = (LoadingChunks)Static.screens.screens[Client.LOADINGCHUNKS];
		menu.setup(client);
		Static.video.Screen = menu; //WARNING : sync on screenLock (must not lock on renderLock)
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		buffer.writeFloat(f1);
		buffer.writeFloat(f2);
		buffer.writeFloat(f3);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		f1 = buffer.readFloat();
		f2 = buffer.readFloat();
		f3 = buffer.readFloat();
		return true;
	  }
	}

}