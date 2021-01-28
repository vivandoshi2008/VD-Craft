namespace jfcraft.move
{
	/// <summary>
	/// Moves an entity.
	/// 
	/// This will be the foundation for A.I. for animals, creatures, etc.
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.entity;

	public interface MoveBase
	{
	  void move(EntityBase entity);
	}

}