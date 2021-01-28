namespace jfcraft.move
{
	/// <summary>
	/// Moves a non-aggresive animal.
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.data;
	using jfcraft.entity;
	using static jfcraft.entity.EntityBase;

	public class MoveCreature : MoveBase
	{
	  public virtual void move(EntityBase entity)
	  {
		CreatureBase animal = (CreatureBase)entity;
		bool moved;
		bool wasmoving = entity.mode != MODE_IDLE;
		//random walking
		if (Static.debugRotate)
		{
		  //test rotate in a spot
		  entity.ang.y += 1.0f;
		  if (entity.ang.y > 180f)
		  {
			  entity.ang.y = -180f;
		  }
		  entity.ang.x += 1.0f;
		  if (entity.ang.x > 45.0f)
		  {
			  entity.ang.x = -45.0f;
		  }
		  entity.mode = MODE_WALK;
		  moved = true;
		}
		else
		{
		  animal.randomWalking();
		  moved = animal.moveEntity();
		}
		if (moved || wasmoving)
		{
			Static.server.broadcastEntityMove(entity, false);
		}
	  }
	}

}