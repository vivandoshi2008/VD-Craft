






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Entity base for all creature types (Player, monsters, animals, etc.)
	/// 
	/// Plan to add path finding, etc. in here.
	/// 
	/// @author vivandoshi
	/// </summary>

	using Packet = jfcraft.packet.Packet;
	using javaforce.gl;

	using jfcraft.block;
	using jfcraft.data;
	using jfcraft.packet;
	using jfcraft.item;
	using static jfcraft.data.Direction;

	public abstract class CreatureBase : EntityBase
	{
	  public float health; //20=full
	  public float ar; //armor rating (20=max)
	  public float air; //20=full
	  public float hunger; //20 = full
	  public float saturation; //20 = full
	  public float exhaustion; //when >= 4.0 : -1 from saturation or food
	  public int blockCount; //raising shield counter
	  public bool blocking; //blocking with a shield

	  public VehicleBase vehicle;
	  public int vcid, vuid; //vehicle id (vcid=in chunk on disk ,vuid=in game)

	  private object @lock = new object();

	  public virtual void hit()
	  {
		runCount = 7;
	  }

	  public virtual void takeDmg(float amt, CreatureBase from)
	  {
		lock (@lock)
		{
		  if (health == 0)
		  {
			Static.log("already dead");
			despawn();
			return;
		  }
		  if (!Settings.current.pvp)
		  {
			if (id == 0 && from.id == 0)
			{
				return; //PvP disabled
			}
		  }
		  //TODO : reduce amt by armor rating
		  exhaustion += 0.3f;
		  hit();
		  if (amt >= health)
		  {
			health = 0;
			//entity is dead
			Static.log("Entity killed:" + this);
			despawn();
			Item[] items = drop();
			Chunk chunk = Chunk;
		  }
		  else
		  {
			health -= amt;
			target = from; //switch target (if aggresive)
			if (from != null)
			{
			  //do knockback
			  GLMatrix mat = new GLMatrix(); //TODO : make this static??? (minor)
			  float ang = from.ang.y + 180.0f;
			  if (ang > 180.0f)
			  {
				  ang -= 360.0f;
			  }
			  mat.addRotate(ang, 0, 1, 0);
			  GLVector3 vec = new GLVector3();
			  vec.v[0] = 0;
			  vec.v[1] = 0;
			  vec.v[2] = 1;
			  mat.mult(vec);
			  vel.x = vec.v[0] * walkSpeed / 20f;
			  vel.y = jumpVelocity / 3.0f;
			  vel.z = vec.v[2] * walkSpeed / 20f;
			  if (id == Entities.PLAYER)
			  {
				Player player = (Player)this;
				player.client.serverTransport.addUpdate(new PacketKnockBack(Packets.KNOCKBACK, vel.x, vel.y,vel.z));
			  }
			}
		  }
	//      if (id == Entities.PLAYER) {
			Static.server.broadcastEntityHealth(this);
	//      }
		}
	  }


