






using System;

namespace jfcraft.data
{
	/// 
	/// <summary>
	/// @author vivandoshi
	/// </summary>

	using javaforce;

	using jfcraft.packet;

	public class Packets : SerialCreator
	{
		public Packet[] packets = new Packet[128];

		private sbyte nextID = 0;

		public virtual void registerPacket(Packet p, string name)
		{
			if (nextID < 0)
			{
				JFAWT.showError("Error", "Too many packets registered!");
				Environment.Exit(1);
			}
			p.cmd = nextID++;
			packets[p.cmd] = p;
			setID(name, p.cmd);
		}

		public virtual void registerDefault()
		{
			Static.log("Packets.registerDefault()");
			registerPacket(new PacketLoginRequest(), "LOGIN_REQUEST"); //must be 1st packet registered
			registerPacket(new PacketLoginReply(), "LOGIN_REPLY");
			registerPacket(new PacketLogout(), "LOGOUT");
			registerPacket(new PacketPlayerRequest(), "PLAYER_REQUEST");
			registerPacket(new PacketPlayer(), "PLAYER_REPLY");
			registerPacket(new PacketWorldRequest(), "WORLD_REQUEST");
			registerPacket(new PacketWorld(), "WORLD_REPLY");
			registerPacket(new PacketChunkRequest(), "CHUNK_REQUEST");
			registerPacket(new PacketChunk(), "CHUNK_REPLY");
			registerPacket(new PacketTick(), "TICK");
			registerPacket(new PacketSetActiveSlot(), "SETACTIVESLOT");
			registerPacket(new PacketRespawnRequest(), "RESPAWN_REQUEST");
			registerPacket(new PacketRespawn(), "RESPAWN");
			registerPacket(new PacketMsg(), "MSG");
			registerPacket(new PacketOnline(), "ONLINE");
			registerPacket(new PacketSetMode(), "SETMODE");
			registerPacket(new PacketPos(), "POS");
			registerPacket(new PacketInvPut(), "INVPUT");
			registerPacket(new PacketInvGet(), "INVGET");
			registerPacket(new PacketInvExchange(), "INVEXCHANGE");
			registerPacket(new PacketArmorPut(), "ARMORPUT");
			registerPacket(new PacketArmorGet(), "ARMORGET");
			registerPacket(new PacketArmorExchange(), "ARMOREXCHANGE");
			registerPacket(new PacketCraftPut(), "CRAFTPUT");
			registerPacket(new PacketCraftGet(), "CRAFTGET");
			registerPacket(new PacketCraftExchange(), "CRAFTEXCHANGE");
			registerPacket(new PacketCraftOne(), "CRAFTONE");
			registerPacket(new PacketCraftAll(), "CRAFTALL");
			registerPacket(new PacketContainerPut(), "CONTAINERPUT");
			registerPacket(new PacketContainerGet(), "CONTAINERGET");
			registerPacket(new PacketContainerExchange(), "CONTAINEREXCHANGE");
			registerPacket(new PacketDrop(), "DROP");
			registerPacket(new PacketMenuEnter(), "MENUENTER");
			registerPacket(new PacketMenuLeave(), "MENULEAVE");
			registerPacket(new PacketMenuInv(), "MENUINV");
			registerPacket(new PacketOpenToLan(), "OPENTOLAN");
			registerPacket(new PacketToggleGameMode(), "TOGGLEGAMEMODE");
			registerPacket(new PacketSetBlock(), "SETBLOCK");
			registerPacket(new PacketClearBlock(), "CLEARBLOCK");
			registerPacket(new PacketSetInv(), "SETINV");
			registerPacket(new PacketSetHand(), "SETHAND");
			registerPacket(new PacketSetArmor(), "SETARMOR");
			registerPacket(new PacketSetCraft(), "SETCRAFT");
			registerPacket(new PacketSetCrafted(), "SETCRAFTED");
			registerPacket(new PacketSetContainer(), "SETCONTAINER");
			registerPacket(new PacketSetContainerItem(), "SETCONTAINERITEM");
			registerPacket(new PacketMove(), "MOVE");
			registerPacket(new PacketSpawn(), "SPAWN");
			registerPacket(new PacketDespawn(), "DESPAWN");
			registerPacket(new PacketHealth(), "HEALTH");
			registerPacket(new PacketTime(), "TIME");
			registerPacket(new PacketBedTime(), "BEDTIME");
			registerPacket(new PacketB2E(), "B2E");
			registerPacket(new PacketE2B(), "E2B");
			registerPacket(new PacketMoveBlock(), "MOVEBLOCK");
			registerPacket(new PacketSetExtra(), "SETEXTRA");
			registerPacket(new PacketDelExtra(), "DELEXTRA");
			registerPacket(new PacketSound(), "SOUND");
			registerPacket(new PacketSetFlags(), "SETFLAGS");
			registerPacket(new PacketKnockBack(), "KNOCKBACK");
			registerPacket(new PacketGenSpawnArea(), "GENSPAWNAREA");
			registerPacket(new PacketClearBlock2(), "CLEARBLOCK2");
			registerPacket(new PacketTeleport1(), "TELEPORT1");
			registerPacket(new PacketTeleport2(), "TELEPORT2");
			registerPacket(new PacketHunger(), "HUNGER");
			registerPacket(new PacketAir(), "AIR");
			registerPacket(new PacketRiding(), "RIDING");
			registerPacket(new PacketMoveBack(), "MOVEBACK");
			registerPacket(new PacketEnderChest(), "ENDERCHEST");
			registerPacket(new PacketSetSign(), "SETSIGN");
			registerPacket(new PacketUseVehicleInventory(), "USEVEHICLEINVENTORY");
			registerPacket(new PacketEntityArmor(), "ENTITY_ARMOR");
			registerPacket(new PacketWorldItemSetCount(), "WORLDITEM_SET_COUNT");
			registerPacket(new PacketShield(), "SHIELD");
			registerPacket(new PacketBow(), "BOW");
			registerPacket(new PacketSetInvDmg(), "SETINVDMG");
		}
	}
}







