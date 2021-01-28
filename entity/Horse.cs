






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Horse entity.
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce;
	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.audio;
	using jfcraft.client;
	using jfcraft.data;
	using jfcraft.item;
	using jfcraft.move;
	using jfcraft.opengl;

	public class Horse : VehicleBase
	{
	  public float walkAngle; //angle of legs/arms as walking
	  public float walkAngleDelta;
	  public static RenderDest dest;

	  public int type;
	  public int pattern;
	  public int tameCounter; //not saved to disk
	  public const int tameCounterMax = 20 * 15;
	  public ExtraHorse inventory;

	  private static GLModel model;

	  public int hearts;

	  public const int FLAG_TAMED = 1;
	  public const int FLAG_SADDLE = 2;
	  public const int FLAG_CHEST = 4;
	  public const int FLAG_ARMOR_IRON = 8;
	  public const int FLAG_ARMOR_GOLD = 16;
	  public const int FLAG_ARMOR_DIAMOND = 32;

	  public virtual bool Tamed
	  {
		  get
		  {
			return (flags & FLAG_TAMED) != 0;
		  }
		  set
		  {
			if (value)
			{
			  flags |= FLAG_TAMED;
			}
			else
			{
			  flags &= -1 - FLAG_TAMED;
			}
		  }
	  }


	  public virtual bool haveSaddle()
	  {
		return (flags & FLAG_SADDLE) != 0;
	  }

	  public virtual bool HaveSaddle
	  {
		  set
		  {
			if (value)
			{
			  flags |= FLAG_SADDLE;
			}
			else
			{
			  flags &= -1 - FLAG_SADDLE;
			}
		  }
	  }

	  public virtual bool haveChest()
	  {
		return (flags & FLAG_CHEST) != 0;
	  }

	  public virtual bool HaveChest
	  {
		  set
		  {
			if (value)
			{
			  flags |= FLAG_CHEST;
			}
			else
			{
			  flags &= -1 - FLAG_CHEST;
			}
		  }
	  }

	  public virtual bool haveArmor(int flag)
	  {
		return (flags & flag) != 0;
	  }

	  public const int TYPE_DONKEY = 0;
	  public const int TYPE_MULE = 1;
	  public const int TYPE_SKELETON = 2;
	  public const int TYPE_ZOMBIE = 3;
	  //pattern applies to following only
	  public const int TYPE_BLACK = 4;
	  public const int TYPE_BROWN = 5;
	  public const int TYPE_CHESTNUT = 6;
	  public const int TYPE_CREAMY = 7;
	  public const int TYPE_DARKBROWN = 8;
	  public const int TYPE_GRAY = 9;
	  public const int TYPE_WHITE = 10;

	  public const int PATTERN_NONE = 0;
	  public const int PATTERN_BLACKDOTS = 11;
	  public const int PATTERN_WHITE = 12;
	  public const int PATTERN_WHITEDOTS = 13;
	  public const int PATTERN_WHITEFIELD = 14;

	  public const int ARMOR_IRON = 15;
	  public const int ARMOR_GOLD = 16;
	  public const int ARMOR_DIAMOND = 17;

	  //render assets
	  public static Texture[] textures;
	  public static GLVertex[] org;

	  public static int initHealth = 10;

	  public Horse()
	  {
		id = Entities.HORSE;
	  }

	  public override RenderDest Dest
	  {
		  get
		  {
			return dest;
		  }
	  }

	  public override string Name
	  {
		  get
		  {
			return "horse";
		  }
	  }

	  public override void init(World world)
	  {
		base.init(world);
		isStatic = true;
		width = 0.6f;
		width2 = width / 2;
		height = 1.0f;
		height2 = height / 2;
		depth = 1.5f;
		depth2 = depth / 2;
		walkAngleDelta = 5.0f;
		angX = 45f;
		if (world.isServer)
		{




