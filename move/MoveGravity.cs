namespace jfcraft.move
{
	/// <summary>
	/// Moves an entity with just gravity.
	///  This is a client-side only class (use in ctick())
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.entity;
	using jfcraft.data;

	public class MoveGravity : MoveBase
	{
	  public virtual void move(EntityBase entity)
	  {
		Chunk chunk1 = entity.Chunk;
		entity.move(false, false, false, -1, EntityBase.AVOID_NONE);
		Chunk chunk2 = entity.Chunk;
		if (chunk1 != chunk2)
		{
		  chunk1.delEntity(entity);
		  chunk2.addEntity(entity);
		}
	  }
	}

}