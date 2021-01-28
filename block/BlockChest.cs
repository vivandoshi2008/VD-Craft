using System;

namespace jfcraft.block
{
	/// <summary>
	/// Block Chest
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;
	using jfcraft.item;
	using jfcraft.entity;
	using jfcraft.opengl;

	public class BlockChest : BlockBase
	{
	  public BlockChest(string name) : base(name, new string[] {"Chest"}, new string[0])
	  {
		canReplace = false;
		isOpaque = false;
		canUse = true;
		renderAsEntity = true;
		isDir = true;
		isDirXZ = true;
		isComplex = true;
		isSolid = false;
	  }
	  public override void getIDs(World world)
	  {
		base.getIDs(world);
		entityID = Entities.CHEST;
	  }
	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		Coords c = new Coords();
		c.setPos(data.x + data.chunk.cx * 16, data.y, data.z + data.chunk.cz * 16);
		Chest chest = (Chest)data.chunk.findBlockEntity(Entities.CHEST, c);
		if (chest == null)
		{
		  return;
		}
		RenderData data2 = new RenderData();
		data2.crack = data.crack;
		chest.buildBuffers(chest.Dest, data2);
		chest.needCopyBuffers = true;
	  }
	  public override bool place(Client client, Coords c)
	  {
		World world = Static.server.world;
		Static.log("chest place");
		ExtraChest extra = new ExtraChest(c.gx, c.gy, c.gz, 3 * 9);
		c.chunk.addExtra(extra);
		Chest chest = new Chest();
		chest.init(world);
		chest.dim = c.chunk.dim;
		chest.pos.x = ((float)c.x) + 0.5f;
		chest.pos.y = ((float)c.y) + 0.5f;
		chest.pos.z = ((float)c.z) + 0.5f;
		chest.gx = c.gx;
		chest.gy = c.gy;
		chest.gz = c.gz;
		chest.ang.y = c.YAngle;
		chest.uid = world.generateUID();
		c.chunk.addEntity(chest);
		world.addEntity(chest);
		Static.server.broadcastEntitySpawn(chest);
		return base.place(client, c);
	  }
	  public override void useBlock(Client client, Coords c)
	  {
		lock (client.@lock)
		{
		  client.container = (ExtraContainer)c.chunk.getExtra(c.gx, c.gy, c.gz, Extras.CHEST);
		  if (client.container == null)
		  {
			Static.log("chest item not found");
			return;
		  }
		  client.chunk = c.chunk;
		  client.menu = Client.CHEST;
		  client.serverTransport.setContainer(c.cx, c.cz, client.container);
		  client.serverTransport.enterMenu(Client.CHEST);
		}
	  }
	  public override void destroy(Client client, Coords c, bool doDrop)
	  {
		//find and remove entity
		EntityBase e = c.chunk.findBlockEntity(Entities.CHEST, c);
		if (e != null)
		{
		  c.chunk.delEntity(e);
		  Static.server.world.delEntity(e.uid);
		  Static.server.broadcastEntityDespawn(e);
		}
		else
		{
		  Static.log("Error:BlockChest.destroy():Entity not found");
		}
		base.destroy(client, c, doDrop);
		c.chunk.delExtra(c, Extras.CHEST);
	  }
	  public override Item[] drop(Coords c, int var)
	  {
		ExtraChest chest = (ExtraChest)c.chunk.getExtra(c.gx, c.gy, c.gz, Extras.CHEST);
		if (chest == null)
		{
		  Static.log("BlockChest.drop():Error:Can not find extra data");
		  return new Item[] {new Item(Blocks.CHEST)};
		}
		Item[] drops = new Item[chest.items.Length + 1];
		Array.Copy(chest.items, 0, drops, 0, chest.items.Length);
		drops[chest.items.Length] = new Item(Blocks.CHEST);
		return drops;
	  }
	  public override SubTexture getDestroyTexture(int var)
	  {
		return Static.blocks.blocks[Blocks.PLANKS].textures[0];
	  }
	}

}