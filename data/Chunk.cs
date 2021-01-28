






using System;
using System.Collections.Generic;

namespace jfcraft.data
{
	/// <summary>
	/// Chunk : holds blocks, items and entities for a 16x256x16 area.
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>


	using javaforce;
	using javaforce.gl;

	using jfcraft.block;
	using jfcraft.data;
	using jfcraft.entity;
	using jfcraft.opengl;

	public class Chunk : SerialClass, SerialCreator
	{
	  public int dim, cx, cz;
	  //Blocks order : Y Z X
	  //char is 16bits unsigned which allows full usage
	  private char[][] blocks = new char[256][]; //type:16
	  private sbyte[][] bits = new sbyte[256][]; //dir:4 var:4
	  private char[][] blocks2 = new char[256][]; //type:16
	  private sbyte[][] bits2 = new sbyte[256][]; //dir:4 var:4
	  private sbyte[][] lights = new sbyte[256][]; //blk_light:4 sun_light:4
	  //blocks2 is for WATER, LAVA, SNOW, etc. (extra plane)

	  public long seed;
	//  public boolean readOnly;
	  public bool needPhase2, needPhase3;
	  public bool needLights; //generator phases
	  //flags
	  public bool dirty; //server:need to write to disk client:need to relight->build->copy
	  public bool needRelight;
	  public bool ready;
	  public bool inRange, isAllEmpty;

	  public int readOnly1, readOnly2; //read only range (-1 to disable)

	  //biome data
	  public sbyte[] biome = new sbyte[16 * 16];
	  public float[] temp = new float[16 * 16];
	  public float[] rain = new float[16 * 16];
	  public float[] elev = new float[16 * 16]; //elevation
	  public float[] depth = new float[16 * 16]; //used in end world

	  public List<EntityBase> entities = new List<EntityBase>();
	  public List<Tick> ticks = new List<Tick>(); //server-side only
	  public List<ExtraBase> extras = new List<ExtraBase>();

	  public object envData; //environment data

	  //end of serializable data

	  public const int BLOCK_LIGHT_MASK = 0xf0;
	  public const int SUN_LIGHT_MASK = 0x0f;

	  //size of each chunk
	  public const int X = 16;
	  public const int Y = 256;
	  public const int Z = 16;

	  public Chunk N, E, S, W; //links : north, east, south, west
	  private class Lock
	  {
	  }
	  public Lock @lock = new Lock();
	  public RenderDest dest;
	  public GLMatrix mat;
	  public int adjCount; //# of adj chunks to render (0-6)
	  public List<ExtraCrack> cracks = new List<ExtraCrack>();

	  //render dest buffers
	  public const int DEST_NORMAL = 0; //stitched block
	  public const int DEST_ALPHA = 1; //stitched block (ALPHA)
	  public const int DEST_TEXT = 2; //ASCII text
	  public const int DEST_COUNT = 3; //DEST_NORMAL + DEST_ALPHA + DEST_TEXT

	  public World world;
	  public Chunks chunks;

	  /// <summary>
	  /// Old Chunk read from file/network. </summary>
	  public Chunk(World world)
	  {
		this.world = world;
		if (world != null)
		{
		  chunks = world.chunks;
		}
	  }

	  /// <summary>
	  /// New Chunk created on server side only </summary>
	  public Chunk(int dim, int cx, int cz)
	  {
		this.chunks = chunks;
		this.world = Static.server.world;
		chunks = world.chunks;
		this.dim = dim;
		this.cx = cx;
		this.cz = cz;
		needPhase2 = true;
		needPhase3 = true;
		needLights = true;
		dirty = true;
	  }

	  /// <summary>
	  /// Create client side objects. </summary>
	  public virtual void createObjects()
	  {
		dest = new RenderDest(DEST_COUNT);
		mat = new GLMatrix();
		mat.setIdentity();
		mat.setTranslate(cx * 16.0f, 0, cz * 16.0f);
	  }

	  public virtual void copyBuffers()
	  {
	//    System.out.println("copyBuffers:" + cx + "," + cz);
		for (int a = 0;a < DEST_COUNT;a++)
		{
		  if (!dest.exists(a))
		  {
			  continue;
		  }
		  dest.getBuffers(a).copyBuffers();
		}
		ready = true;
	  }

	  public virtual void render(RenderBuffers obj)
	  {
		obj.bindBuffers();
		obj.render();
	  }

	  /// <summary>
	  /// Determines if lighting if different around a block. </summary>
	  private bool doesLightingDiffer(int x, int y, int z)
	  {
		int ll = -1, la = -1, lb = -1, ln = -1, le = -1, ls = -1, lw = -1; //light levels around block
		BlockBase base1, base2;
		if (y < 255)
		{
		  base1 = Static.blocks.blocks[getBlock(x,y + 1,z)];
		  base2 = Static.blocks.blocks[getBlock2(x,y + 1,z)];
		  if (!base1.isOpaque && !base2.isOpaque)
		  {
			la = getLights(x, y + 1, z);
			if (ll != -1 && ll != la)
			{
			  return true;
			}
			ll = la;
		  }
		}
		if (y > 0)
		{
		  base1 = Static.blocks.blocks[getBlock(x,y - 1,z)];
		  base2 = Static.blocks.blocks[getBlock2(x,y - 1,z)];
		  if (!base1.isOpaque && !base2.isOpaque)
		  {
			lb = getLights(x, y - 1, z);
			if (ll != -1 && ll != lb)
			{
			  return true;
			}
			ll = lb;
		  }
		}
		base1 = Static.blocks.blocks[getBlock(x,y,z - 1)];







