namespace jfcraft.packet
{
	/// <summary>
	/// Packet with Entity
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;
	using jfcraft.entity;

	public class PacketSpawn : Packet
	{
	  public EntityBase entity;

	  public PacketSpawn()
	  {
	  }

	  public PacketSpawn(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketSpawn(sbyte cmd, EntityBase entity) : base(cmd)
	  {
		this.entity = entity;
	  }

	  //process on client side
	  public virtual void process(Client client)
	  {
		EntityBase e = entity;
		if (client.world.hasEntity(e.uid))
		{
			return;
		}
		e.init(Static.client.world);
		int cx = Static.floor(e.pos.x / 16.0f);
		int cz = Static.floor(e.pos.z / 16.0f);
		Chunk chunk = client.world.chunks.getChunk(e.dim, cx, cz);
		if (chunk != null)
		{
		  chunk.addEntity(e);
		}
		client.world.addEntity(e);
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		entity.write(buffer, file);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		entity = (EntityBase)Static.entities.create(buffer);
		if (entity == null)
		{
		  Static.log("Error:PacketSpawn:Entity not registered");
		  return false;
		}
		entity.read(buffer, file);
		return true;
	  }
	}

}