namespace jfcraft.move
{
	/// <summary>
	/// Move an entity which just floats in the air.
	///  (moves in a fixed direction)
	///  This is for client-side only (use in ctick())
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.data;
	using jfcraft.entity;

	public class MoveFloat : MoveBase
	{
	  private float dx, dy, dz;
	  public MoveFloat(float x, float y, float z)
	  {
		dx = x;
		dy = y;
		dz = z;
	  }
	  public virtual void move(EntityBase entity)
	  {
		Chunk chunk1 = entity.Chunk;
		entity.pos.x += dx;
		entity.pos.y += dy;
		entity.pos.z += dz;
		Chunk chunk2 = entity.Chunk;
		if (chunk1 != chunk2)
		{
		  chunk1.delEntity(entity);
		  chunk2.addEntity(entity);
		}
	  }
	}

}