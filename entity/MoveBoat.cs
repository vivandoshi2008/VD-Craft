namespace jfcraft.move
{
	/// <summary>
	/// Moves a boat.
	/// 
	/// @author vivandoshi
	/// </summary>

	using jfcraft.data;
	using jfcraft.entity;
	using static jfcraft.entity.EntityBase;

	public class MoveBoat : MoveBase
	{
	  public virtual void move(EntityBase entity)
	  {
		Boat boat = (Boat)entity;
		boat.updateFlags(0,0,0);
		if (boat.occupant != null)
		{
		  float speed = 0;
		  if (boat.onWater)
		  {
			if (boat.run)
			{
			  speed = boat.fastWaterSpeed;
			}
			else
			{
			  speed = boat.waterSpeed;
			}
		  }
		  else
		  {
			speed = boat.landSpeed;
		  }
		  if (boat.up || boat.dn)
		  {
			boat.occupant.calcVectors(speed / 20.0f, move_vectors);
			float xv = 0, zv = 0;
			if (boat.up)
			{
			  xv += move_vectors.forward.v[0];
			  zv += move_vectors.forward.v[2];
			}
			if (boat.dn)
			{
			  xv += -move_vectors.forward.v[0];
			  zv += -move_vectors.forward.v[2];
			}
			if (xv != 0)
			{
				boat.XVel = xv;
			}
			if (zv != 0)
			{
				boat.ZVel = zv;
			}
			boat.ang.y = boat.occupant.ang.y;
		  }
		}
		bool moved = boat.move(false, true, false, -1, AVOID_NONE);
		if (moved)
		{
		  Static.server.broadcastEntityMove(boat, false);
		}
		if (boat.occupant != null)
		{
		  Chunk chunk1 = boat.occupant.Chunk;
		  boat.occupant.pos.x = boat.pos.x;
		  boat.occupant.pos.y = boat.pos.y - boat.occupant.legLength;
		  boat.occupant.pos.z = boat.pos.z;
		  Static.server.broadcastEntityMove(boat.occupant, true);
		  Chunk chunk2 = boat.occupant.Chunk;
		  if (chunk2 != chunk1)
		  {
			chunk1.delEntity(boat.occupant);
			chunk2.addEntity(boat.occupant);
		  }
		  if (boat.sneak)
		  {
			boat.occupant.vehicle = null;
			Static.server.broadcastRiding(boat, boat.occupant, false);
			boat.occupant = null;
		  }
		}
	  }
	}

}