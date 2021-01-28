namespace jfcraft.data
{
	/// <summary>
	/// Chest items
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.item;

	public class ExtraChest : ExtraContainer
	{
	  public ExtraChest()
	  {
		this.id = Extras.CHEST;
	  }

	  public ExtraChest(int x, int y, int z, int cnt)
	  {
		this.id = Extras.CHEST;
		this.x = (short)x;
		this.y = (short)y;
		this.z = (short)z;
		items = new Item[cnt];
		for (int a = 0;a < cnt;a++)
		{
		  items[a] = new Item();
		}
	  }

	  public override string Name
	  {
		  get
		  {
			return "chest";
		  }
	  }

	  private const sbyte ver = 0;

	  public override bool write(SerialBuffer buffer, bool file)
	  {
		base.write(buffer, file);
		buffer.writeByte(ver);
		return true;
	  }

	  public override bool read(SerialBuffer buffer, bool file)
	  {
		base.read(buffer, file);
		sbyte ver = buffer.readByte();
		return true;
	  }
	}

}