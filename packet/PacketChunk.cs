namespace jfcraft.packet
{
	/// <summary>
	/// Packet with Chunk
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.client;
	using jfcraft.entity;
	using jfcraft.data;

	public class PacketChunk : Packet
	{
	  public Chunk chunk;

	  public PacketChunk()
	  {
	  }

	  public PacketChunk(sbyte cmd) : base(cmd)
	  {
	  }

	  public PacketChunk(sbyte cmd, Chunk chunk) : base(cmd)
	  {
		this.chunk = chunk;
	  }

	  //process on client side
	  public override void process(Client client)
	  {
		EntityBase[] e = chunk.Entities;
		int pid = client.UID;
		for (int a = 0;a < e.Length;a++)
		{
		  if (e[a].uid == pid)
		  {
			chunk.delEntity(e[a]);
		  }
		}
		client.world.chunks.addChunk(chunk);
		client.removeChunkPending(chunk.cx, chunk.cz);
	  }

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		chunk.write(buffer, file);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		chunk = new Chunk(Static.client.world);
		chunk.read(buffer, file);
		return true;
	  }
	}

}