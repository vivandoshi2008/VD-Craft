






using System;

namespace jfcraft.block
{
	/// <summary>
	/// Furnace block
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce;

	using jfcraft.client;
	using jfcraft.data;
	using jfcraft.item;

	public class BlockFurnace : BlockOpaque
	{
	  public BlockFurnace(string id, string[] names, string[] images) : base(id,names,images)
	  {
		canUse = true;
		isDir = true;
		isDirXZ = true;
		reverseDir = true;
	  }
	  public override bool place(Client client, Coords c)
	  {
		ExtraFurnace furnace = new ExtraFurnace(c.gx, c.gy, c.gz);
		c.chunk.addExtra(furnace);
		c.chunk.addTick(c, false);
		return base.place(client, c);
	  }
	  private static Coords c = new Coords();
	  public override void tick(Chunk chunk, Tick tick)
	  {
		tick.toWorldCoords(chunk, c);
		ExtraFurnace furnace = (ExtraFurnace)chunk.getExtra(c.gx, c.gy, c.gz, Extras.FURNACE);
		if (furnace == null)
		{
		  Static.log("BlockFurnace.tick():Error:Can not find extra data");
		  return;
		}
	//    Static.log("Furnace.tick()");
		lock (furnace)
		{
		  try
		  {
			if (furnace.timer > 0)
			{
			  furnace.timer--;
			  char @in = furnace.items[ExtraFurnace.INPUT].id;
			  char @out = furnace.items[ExtraFurnace.OUTPUT].id;
			  if (furnace.timer == 0 && @in != (char)0)
			  {
				//done
				ItemBase inItem = Static.items.items[@in];
				if (inItem.canBake)
				{
				  Item baked = inItem.bake();
				  bool done = false;
				  if (baked != null)
				  {
					if (@out != (char)0)
					{
					  ItemBase outItem = Static.items.items[@out];
					  if (furnace.items[ExtraFurnace.OUTPUT].Equals(baked))
					  {
						if (furnace.items[ExtraFurnace.OUTPUT].count < outItem.maxStack)
						{
						  furnace.items[ExtraFurnace.OUTPUT].count++;
						  done = true;
						}
					  }
					}
					else
					{
					  furnace.items[ExtraFurnace.OUTPUT].copy(baked, (sbyte)1);
					  done = true;
					}
					if (done)
					{
					  furnace.items[ExtraFurnace.INPUT].count--;
					  if (furnace.items[ExtraFurnace.INPUT].count == 0)
					  {
						furnace.items[ExtraFurnace.INPUT].clear();
					  }
					}
				  }
				}
			  }
			}
			if (furnace.heat > 0)
			{
			  furnace.heat--;
			  if (furnace.heat == 0)
			  {
				furnace.timer = 0;
				furnace.heatMax = 0;
			  }
			}
			if (furnace.timer == 0)
			{
			  char @in = furnace.items[ExtraFurnace.INPUT].id;
			  char fuel = furnace.items[ExtraFurnace.FUEL].id;
			  char @out = furnace.items[ExtraFurnace.OUTPUT].id;
			  if (@in == (char)0 || (furnace.heat == 0 && fuel == (char)0))
			  {
				  throw new Exception("furnace:no input");
			  }
			  ItemBase inItem = Static.items.items[@in];
			  ItemBase outItem = null;
			  if (@out != (char)0)
			  {
				  outItem = Static.items.items[@out];
			  }
			  if (!inItem.canBake)
			  {
				  throw new Exception("furnace:input doesn't bake"); //should not happen
			  }
			  Item baked = inItem.bake();
			  if (baked == null)
			  {
				  throw new Exception("furnace:input has no baked item"); //should not happen
			  }
			  if ((furnace.items[ExtraFurnace.OUTPUT].count > 0) && (outItem != null) && (!furnace.items[ExtraFurnace.OUTPUT].Equals(baked)))
			  {
				Static.log("output=" + (int)outItem.id);
				Static.log("bake=" + (int)baked.id + "," + baked.var);
				throw new Exception("furnace:can not bake more");
			  }
			  if (furnace.heat == 0)
			  {
				ItemBase fuelItem = Static.items.items[fuel];
				if (!fuelItem.isFuel)
				{
					throw new Exception("furnace:fuel is not consumable"); //should not happen
				}
				//use fuel
				furnace.heat = fuelItem.heat;
				furnace.heatMax = furnace.heat;
				furnace.items[ExtraFurnace.FUEL].count--;
				if (furnace.items[ExtraFurnace.FUEL].count == 0)
				{
				  furnace.items[ExtraFurnace.FUEL].clear();
				}
			  }
			  furnace.timer = 200;
			}
		  }
		  catch (Exception)
		  {
			//exceptions are normal
	//        Static.log(e);
		  }
		}
		//broadcast only to those who are viewing this furnace
		Static.server.broadcastContainerChange(furnace, c.cx, c.cz);
	  }
	  public override void useBlock(Client client, Coords c)
	  {
		lock (client.@lock)
		{
		  client.container = (ExtraContainer)c.chunk.getExtra(c.gx, c.gy, c.gz, Extras.FURNACE);
		  if (client.container == null)
		  {
			Static.log("BlockFurace.useBlock():Error:Can not find extra data");
			return;
		  }
		  client.chunk = c.chunk;
		  client.menu = Client.FURNACE;
		  client.serverTransport.setContainer(c.cx, c.cz, client.container);
		  client.serverTransport.enterMenu(client.menu);
		}
	  }
	  public override void destroy(Client client, Coords c, bool doDrop)
	  {
		base.destroy(client, c, doDrop);
		c.chunk.delExtra(c, Extras.FURNACE);
	  }
	  public override Item[] drop(Coords c, int var)
	  {
		ExtraFurnace furnace = (ExtraFurnace)c.chunk.getExtra(c.gx, c.gy, c.gz, Extras.FURNACE);







