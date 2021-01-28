






namespace jfcraft.data
{
	/// <summary>
	/// Extra Item Container (base class for ExtraChest, Hopper, Furnace, etc.)
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.item;
	using Server = jfcraft.server.Server;

	public class ExtraContainer : ExtraBase
	{
	  public Item[] items;

	  private const sbyte ver = 0;

	  public ExtraContainer()
	  {
	  }

	  public ExtraContainer(int cnt)
	  {
		items = new Item[cnt];
		for (int a = 0;a < cnt;a++)
		{
		  items[a] = new Item();
		}
	  }

	  public override string Name
	  {
		  get
		  {
			return "container";
		  }
	  }

	  public override void update(ExtraBase update)
	  {
		ExtraContainer container = (ExtraContainer)update;
		this.items = container.items;
	  }

	  public virtual void changed()
	  {
	  }

	  public override void convertIDs(char[] blockIDs, char[] itemIDs)
	  {
		for (int a = 0;a < items.Length;a++)
		{
		  Item item = items[a];
		  char id = item.id;
		  if (Static.isBlock(id))
		  {
			id = blockIDs[id];
		  }
		  else
		  {
			id = (char)(itemIDs[id - Items.FIRST_ID] + Items.FIRST_ID);
		  }
		  item.id = id;
		}
	  }

	  public virtual void get(Server server, Client client, sbyte idx, sbyte count)
	  {
		sbyte cc = client.container.items[idx].count;
		if (count > cc)
		{
		  count = cc;
		}
		if (count == 0)
		{
		  Static.log("nothing to pickup");
		  return;
		}
		client.hand = new Item();
		client.hand.copy(client.container.items[idx], count);
		if (count == cc)
		{
		  client.container.items[idx].clear();
		}
		else
		{
		  client.container.items[idx].count = (sbyte)(cc - count);
		}
		server.broadcastSetContainerItem(idx, client.container);
		client.serverTransport.Hand = client.hand;
		if (client.chunk != null)
		{
		  client.chunk.dirty = true;
		}
		changed();
	  }

	  public virtual void put(Server server, Client client, sbyte idx, sbyte count)
	  {
		if (count <= 0 || count > 64)
		{
		  Static.log("invalid count");
		  return;
		}
		if (client.hand == null)
		{
		  Static.log(":but hand is empty");
		  return;
		}
		if (count > client.hand.count)
		{
		  Static.log(":count > hand.count");
		  return;
		}
		ItemBase itembase = Static.items.items[client.hand.id];
		if (itembase.isDamaged)
		{
		  if (client.container.items[idx].count != 0)
		  {
			  Static.log(":not empty");
		  }
		  client.container.items[idx] = client.hand;
		  server.broadcastSetContainerItem(idx, client.container);
		  client.hand = null;
		}
		else
		{
		  int max = Static.items.items[client.hand.id].maxStack;
		  int cc = client.container.items[idx].count;
		  if (cc > 0)
		  {
			if (!client.container.items[idx].Equals(client.hand))
			{
				Static.log("items not same");
			}
			if (cc + count > max)
			{
			  count = (sbyte)(max - cc);
			  if (count == 0)
			  {
				  return; //inv slot full (not an error)
			  }
			}
			client.container.items[idx].count += count;
		  }
		  else
		  {
			if (count > max)
			{
			  count = (sbyte)max;
			}
			client.container.items[idx].copy(client.hand, count);
		  }
		  server.broadcastSetContainerItem(idx, client.container);
		  client.hand.count -= count;
		  if (client.hand.count == 0)
		  {
			client.hand = null;
		  }
		}
		client.serverTransport.Hand = client.hand;
		if (client.chunk != null)
		{
		  client.chunk.dirty = true;
		}
		changed();
	  }

	  public virtual void exchange(Server server, Client client, sbyte idx)
	  {
		if (client.hand == null)
		{
		  Static.log(":but hand empty");
		  return;
		}
		if (client.container.items[idx].count == 0)
		{
		  Static.log("but item empty");
		  return;
		}
		Item tmp = client.hand;
		client.hand = client.player.items[idx];
		client.container.items[idx] = tmp;
		server.broadcastSetContainerItem(idx, client.container);
		client.serverTransport.Hand = client.hand;
		if (client.chunk != null)
		{


//End of the allowed output for the Free Edition of Java to 
				
				
				Converter.




