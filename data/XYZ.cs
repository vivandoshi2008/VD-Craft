namespace jfcraft.data
{
	/// <summary>
	/// 3 floats
	/// 
	/// @author vivandoshi
	/// </summary>

	public class XYZ
	{
	  public float x, y, z;
	  public XYZ()
	  {
	  }
	  public XYZ(float x, float y, float z)
	  {
		this.x = x;
		this.y = y;
		this.z = z;
	  }
	  public virtual void copy(XYZ @in)
	  {
		this.x = @in.x;
		this.y = @in.y;
		this.z = @in.z;
	  }
	  public virtual bool Zero
	  {
		  get
		  {
			return x == 0 && y == 0 && z == 0;
		  }
	  }
	  public override string ToString()
	  {
		return "{" + x + "," + y + "," + z + "}";
	  }
	}

}