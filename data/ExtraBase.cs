namespace jfcraft.data
{
	/// <summary>
	/// Used to store extra info for a block.
	/// 
	/// @author vivandoshi
	/// </summary>

	public abstract class ExtraBase : SerialClass
	{
	  public sbyte id;
	  public short x, y, z;

	  public abstract string Name {get;}

	  /// <summary>
	  /// Override in derived extras. </summary>
	  public virtual void update(ExtraBase update)
	  {
	  }

	  public virtual void convertIDs(char[] blockIDs, char[] itemIDs)
	  {
	  }

	  private const sbyte ver = 0;

	  public virtual bool write(SerialBuffer buffer, bool file)
	  {
		buffer.writeByte(ver);
		buffer.writeByte(id);
		buffer.writeShort(x);
		buffer.writeShort(y);
		buffer.writeShort(z);
		return true;
	  }

	  public virtual bool read(SerialBuffer buffer, bool file)
	  {
		sbyte ver = buffer.readByte();
		id = buffer.readByte();
		x = buffer.readShort();
		y = buffer.readShort();
		z = buffer.readShort();
		return true;
	  }

	  public override string ToString()
	  {
		return "Extra:type=" + id + "@" + x + "," + y + "," + z;
	  }
	}

}