






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Base class for all mobile entities.
	///  Mobs : Players, villagers, monsters, etc.
	///  Special items : Chest, Sign, Book on enchanting table,
	///    World Item, Moving Block
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce.gl;

	using jfcraft.block;
	using jfcraft.client;
	using jfcraft.move;
	using jfcraft.data;
	using jfcraft.item;
	using jfcraft.opengl;
	using static jfcraft.data.Direction;

//	import static javaforce.gl.GL.*;

	public abstract class EntityBase : EntityHitTest, RenderSource, SerialClass
	{
	  public XYZ pos = new XYZ(); //position
	  public XYZ ang = new XYZ(); //angle
	  public XYZ vel = new XYZ(); //velocity

	//  public boolean debug = false;

	  //the position represent the entities center position at the bottom (feet)
	  // centered on x and z, but bottom on y of their cube
	  public int dim; //dimension
	  public int id; //Entity type : PLAYER, ZOMBIE, etc.
	  public int uid; //unique id (in game only) (not saved to disk)
	  public int age;
	  public int teleportTimer;
	  public int cid; //id within chunk (saved to disk)
	  public int flags; //generic flags (usage depends on derived entities)
	  public int part; //part to render (applies to only Shield right now)

	  public float width, width2, height, height2, depth, depth2;
	  public float legLength; //for when in vehicle
	  public float eyeHeight, jumpVelocity, reach;
	  public float walkSpeed, runSpeed, sneakSpeed, swimSpeed, fastSwimSpeed;
	  public float yDrag, xzDrag;
	  public bool inWater, inLava; //whole body
	  public bool inLadder, inVines, inWeb;
	  public bool underWater, underLava; //camera view
	  public bool creative;
	  public float floatRad;
	  public float jumpPos, jumpStart; //for debug only I think (max height of last jump)
	  public float attackDmg, attackRange;
	  public bool wasInLiquid;
	  private class Lock
	  {
	  }
	  private Lock @lock;
	  public bool offline; //player only
	  public int attackCount, attackDelay;
	  public bool isBlock;
	  public bool instanceInited;
	  public int sound;
	  public int maxAge;
	  public CreatureBase target;
//JAVA TO 
		
		CONVERTER NOTE: Fields cannot have the same name as methods of the current type:
	  public bool onGround_Conflict, onWater;
	  public int mode; //IDLE, WALK, RUN, SNEAK, BOWCHARGE, etc.
	  public float scale; //scale entity
	  public bool isStatic; //one static instance for all instances
	  public bool dirty, needCopyBuffers;
	  public int[] path;
//JAVA TO 
		
		CONVERTER NOTE: Fields cannot have the same name as methods of the current type:
	  public MoveBase move_Conflict;

	  public float angX; //default position

	  public static Random r = new Random();
	  public static GLMatrix mat = new GLMatrix(); //for rendering only (client side render only)

	  public World world;

	  public virtual void init(World world)
	  {
		//init values
		this.world = world;
		@lock = new Lock();
		maxAge = -1;
		if (!isStatic)
		{
		  dirty = true;
		  needCopyBuffers = true;
		}
		scale = 1.0f;
	  }

	  public virtual void initStatic()
	  {
	  }
	  public virtual void initStaticGL()
	  {
	  }
	  public virtual void initInstance()
	  {
		instanceInited = true;
	  }
	  public virtual float Scale
	  {
		  set
		  {
			this.scale = value;
		  }
	  }
	  public virtual MoveBase Move
	  {
		  set
		  {
			this.move_Conflict = value;
		  }
	  }

	  public abstract string Name {get;}

	  public virtual GLModel loadModel(string fn)
	  {
		return Assets.getModel(fn).model;
	  }

	  /// <summary>
	  /// Tests all blocks. </summary>
	  private bool hitTest(float dx, float dy, float dz)
	  {
		float px = pos.x + dx - width2;
		float py = pos.y + dy;
		float pz = pos.z + dz - depth2;

		float tx = pos.x + dx;
		float ty = pos.y + dy + height2;
		float tz = pos.z + dz;

		int ix = Static.ceil(width);
		int iy = Static.ceil(height);
		int iz = Static.ceil(depth);

		Coords coords = Coords.alloc();
		bool hit = false;
		for (int x = 0;x <= ix;x++)
		{
		  for (int y = 0;y <= iy;y++)
		  {
			for (int z = 0;z <= iz;z++)
			{
			  float cx = px;
			  if (x > width)
			  {
				  cx += width;
			  }
			  else
			  {
				  cx += x;
			  }
			  float cy = py;


//End of the allowed output for the Free Edition of Java to 
						Converter.




