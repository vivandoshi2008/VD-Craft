






using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jfcraft.data
{
	/// <summary>
	/// Cache chunks
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>


	using javaforce;
	using javaforce.gl;

	using jfcraft.data;
	using jfcraft.server;
	using jfcraft.entity;

	public class Chunks
	{
	  //cache of all chunks
	  private Dictionary<ChunkKey, Chunk> cache = new Dictionary<ChunkKey, Chunk>();
	  private class Lock
	  {
	  }
	  private Lock @lock = new Lock(); //lock access to cache

	  public World world;

	  public Chunks(World world)
	  {
		this.world = world;
	  }

	  //client/server side (may return null)
	  public virtual Chunk getChunk(int dim, int cx, int cz)
	  {
		ChunkKey key = ChunkKey.alloc(dim, cx, cz);
		Chunk chunk;
		lock (@lock)
		{
		  chunk = cache[key];
		}
		key.free();
		return chunk;
	  }

	  //server side only : gets loaded chunk, or loads from disk, or generates it
	  public virtual Chunk getChunk2(int dim, int cx, int cz, bool doPhase2, bool doPhase3, bool doLights)
	  {
		  lock (this)
		  {
			Chunk chunk = getChunk(dim,cx,cz);
		//    Static.log("getChunk2:" + cx + "," + cz + ":" + getAdj + ":" + cache.size());
			if (chunk == null)
			{
			  //load from disk
			  chunk = loadChunk(dim, cx, cz);
			  if (chunk == null)
			  {
				//if not on disk then generate from scratch
				chunk = Static.dims.dims[dim].GeneratorPhase1.generate(dim,cx,cz);
			  }
			  else
			  {
				if (Static.debugPurgeEntities && chunk.entities.Count > 0)
				{
				  chunk.entities.Clear();
				  chunk.dirty = true;
				}
			  }
			  addChunk(chunk);
			}
			if (doPhase2 && chunk.needPhase2)
			{
			  lock (@lock)
			  {
				chunk.getAdjChunks(false, false, false, 1);
				Static.dims.dims[dim].GeneratorPhase2.generate(chunk);
			  }
			}
			if (doPhase3 && chunk.needPhase3)
			{
			  lock (@lock)
			  {
				chunk.getAdjChunks(true, false, false, 1);
				Static.dims.dims[dim].GeneratorPhase3.generate(chunk);
			  }
			  chunk.buildShapes();
			}
			if (doLights && chunk.needLights)
			{
			  lock (@lock)
			  {
				chunk.getAdjChunks(true, true, false, 1);
				Static.dims.dims[dim].LightingServer.light(chunk);
				chunk.setDirty9();
			  }
			}
			return chunk;
		  }
	  }

	  /// <summary>
	  /// Loads surrounding chunks. </summary>
	  public virtual void loadSurroundingChunks(int dim, int cx, int cz)
	  {
		getChunk2(dim,cx + 1,cz + 1,true,true,true);
		getChunk2(dim,cx,cz + 1,true,true,true);
		getChunk2(dim,cx + 1,cz - 1,true,true,true);
		getChunk2(dim,cx,cz - 1,true,true,true);
		getChunk2(dim,cx - 1,cz + 1,true,true,true);
		getChunk2(dim,cx,cz + 1,true,true,true);
		getChunk2(dim,cx - 1,cz - 1,true,true,true);
		getChunk2(dim,cx,cz - 1,true,true,true);
	  }

	  public virtual bool hasChunk(int dim, int cx, int cz)
	  {
		ChunkKey key = ChunkKey.alloc(dim, cx, cz);
		bool contains;
		lock (@lock)
		{
		  contains = cache.ContainsKey(key);
		}
		key.free();
		return contains;
	  }

	  public virtual void addChunk(Chunk chunk)
	  {
		  lock (this)
		  {
			ChunkKey key = ChunkKey.alloc(chunk.dim, chunk.cx, chunk.cz);
		//    Static.log("addChunk:" + cid);
			lock (@lock)
			{
			  Chunk old = cache[key];
			  if (old != null)
			  {
				removeChunk(old);
			  }
			}
			if (world.isClient)
			{
				chunk.createObjects();
			}
			//add entities to cache and generate uid's if server
			EntityBase[] es = chunk.Entities;
			for (int a = 0;a < es.Length;a++)
			{
			  EntityBase e = es[a];
			  e.init(world);
			  if (world.isServer)
			  {
				if (e.id == Entities.PLAYER)
				{
				  //player saved to disk somehow???
				  chunk.entities.RemoveAt(a);
				  continue;
				}
				e.uid = world.generateUID();
				//ensure entity is in correct chunk
				int cx = Static.floor(e.pos.x / 16.0f);
				int cz = Static.floor(e.pos.z / 16.0f);
				if (chunk.cx != cx || chunk.cz != cz)
				{
				  Chunk chunk2 = getChunk2(chunk.dim, cx, cz, false, false, false);
				  Static.log("Warning:Entity moved to correct chunk:id=0x" + Convert.ToString(e.id, 16) + ",x=" + e.pos.x + ",z=" + e.pos.z + ",chunk.cx=" + chunk.cx + ",cz=" + chunk.cz);
				  chunk.delEntity(e);
				  chunk2.addEntity(e);
				}
			  }
			  world.addEntity(e);
			}
			//update links
			Chunk N = getChunk(chunk.dim, chunk.cx, chunk.cz - 1);
			if (N != null)
			{
			  N.S = chunk;
			  N.adjCount++;
			  if (world.isClient && N.adjCount == 8)
			  {
				if (N.needRelight)
				{
				  Static.client.chunkLighter.add(N, 0,0,0, 15,255,15);
				}


//End of the allowed output for the Free Edition of Java to 
						
						
						Converter.




