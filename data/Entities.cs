






using System;
using System.Collections.Generic;

namespace jfcraft.data
{
	/// <summary>
	/// Registered Entities
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce;
	using javaforce.gl;

//	import static jfcraft.data.Extras.MAX_ID;

	using jfcraft.entity;
	using jfcraft.opengl;

	public class Entities : SerialCreator
	{
	  public const short MAX_ID = 8192;

	  //players
	  public static int PLAYER; //will be zero

	  //monsters
	  public static int ZOMBIE;
	  public static int SKELETON;
	  public static int ENDERMAN;
	  public static int ZOMBIE_PIGMAN;
	  public static int SLIME;

	  //animals (spawn with world generator)
	  public static int PIG;
	  public static int COW;
	  public static int SHEEP;
	  public static int HORSE;

	  //misc
	  public static int MOVINGBLOCK;
	  public static int WORLDITEM;

	  //items as entities
	  public static int END_PORTAL;
	  public static int ARROW;
	  public static int CHEST;
	  public static int BOAT;
	  public static int MINECART;
	  public static int PISTON;
	  public static int PISTON_STICKY;
	  public static int LEVER;
	  public static int ENDER_CHEST;
	  public static int SHIELD;

	  public static void getIDs(World world)
	  {
		PLAYER = world.getEntityID("player");
		ZOMBIE = world.getEntityID("ZOMBIE");
		SKELETON = world.getEntityID("SKELETON");
		ENDERMAN = world.getEntityID("ENDERMAN");
		ZOMBIE_PIGMAN = world.getEntityID("ZOMBIE_PIGMAN");
		SLIME = world.getEntityID("SLIME");
		PIG = world.getEntityID("PIG");
		COW = world.getEntityID("COW");
		SHEEP = world.getEntityID("SHEEP");
		HORSE = world.getEntityID("HORSE");
		MOVINGBLOCK = world.getEntityID("MOVINGBLOCK");
		WORLDITEM = world.getEntityID("WORLDITEM");
		END_PORTAL = world.getEntityID("END_PORTAL");
		ARROW = world.getEntityID("ARROW");
		CHEST = world.getEntityID("CHEST");
		BOAT = world.getEntityID("BOAT");
		MINECART = world.getEntityID("MINECART");
		PISTON = world.getEntityID("PISTON");
		PISTON_STICKY = world.getEntityID("PISTON_STICKY");
		LEVER = world.getEntityID("LEVER");
		ENDER_CHEST = world.getEntityID("ENDER_CHEST");
		SHIELD = world.getEntityID("SHIELD");
	  }

	  public int entityCount;
	  public EntityBase[] regEntities = new EntityBase[MAX_ID];
	  public EntityBase[] entities;

	  public virtual void registerEntity(EntityBase e)
	  {
		regEntities[entityCount++] = e;
	  }

	  public virtual void orderEntities()
	  {
		entities = new EntityBase[MAX_ID];
		for (int a = 0;a < MAX_ID;a++)
		{
		  EntityBase eb = regEntities[a];
		  if (eb == null)
		  {
			  continue;
		  }
		  entities[eb.id] = eb;
		}
	  }

	  public virtual void registerDefault()
	  {
		registerEntity(new Player());
		registerEntity(new Zombie());
		registerEntity(new Skeleton());
		registerEntity(new Enderman());
		registerEntity(new ZombiePigman());
		registerEntity(new Slime());
		registerEntity(new Chest());
		registerEntity(new EnderChest());
		registerEntity(new Piston());
		registerEntity((new Piston()).setSticky());
		registerEntity(new Lever());
		registerEntity(new MovingBlock());
		registerEntity(new WorldItem());
		registerEntity(new Pig());
		registerEntity(new Cow());
		registerEntity(new Horse());
		registerEntity(new Sheep());
		registerEntity(new EndPortal());
		registerEntity(new Arrow());
		registerEntity(new Boat());
		registerEntity(new Minecart());
		registerEntity(new Horse());
		registerEntity(new Shield());
	  }

	  public virtual void initStatic()
	  {
		Static.log("initStatic()");
		for (int a = 0;a < MAX_ID;a++)
		{
		  EntityBase e = regEntities[a];
		  if (e == null)
		  {
			  continue;
		  }
		  e.initStatic();
		}
	  }

	  public virtual void initStaticGL()
	  {
		Static.log("initStatic(gl)");
		RenderData data = new RenderData();


//End of the allowed output for the Free Edition of Java to 
			
			Converter.




