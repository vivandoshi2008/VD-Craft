using System;

namespace jfcraft.packet
{
	/// <summary>
	/// Packet with 6 Floats and 2 Ints
	/// 
	/// @author vivandoshi
	/// </summary>

	using Client = jfcraft.client.Client;
	using jfcraft.data;
	using Server = jfcraft.server.Server;
	using jfcraft.entity;
	using jfcraft.item;
	using jfcraft.audio;
	using jfcraft.block;

	public class PacketPos : Packet
	{
		public float f1, f2, f3, f4, f5, f6;
		public int i1, i2;

		public PacketPos()
		{
		}

		public PacketPos(sbyte cmd) : base(cmd)
		{
		}

		public PacketPos(sbyte cmd, float f1, float f2, float f3, float f4, float f5, float f6, int i1, int i2) : base(cmd)
		{
			this.f1 = f1;
			this.f2 = f2;
			this.f3 = f3;
			this.f4 = f4;
			this.f5 = f5;
			this.f6 = f6;
			this.i1 = i1;
			this.i2 = i2;
		}

		//process on server side
		public virtual void process(Server server, Client client)
		{
			if (client.player.offline)
			{
				return; //player in limbo
			}
			int bits = i1;
			bool up = (bits & Player.MOVE_UP) != 0;
			bool dn = (bits & Player.MOVE_DN) != 0;
			bool lt = (bits & Player.MOVE_LT) != 0;
			bool rt = (bits & Player.MOVE_RT) != 0;
			bool moving = up || dn || lt || rt;
			bool jump = (bits & Player.JUMP) != 0;
			bool sneak = (bits & Player.SNEAK) != 0;
			bool run = (bits & Player.RUN) != 0;
			bool b1 = (bits & Player.LT_BUTTON) != 0;
			bool b2 = (bits & Player.RT_BUTTON) != 0;
			bool fup = (bits & Player.FLY_UP) != 0;
			bool fdn = (bits & Player.FLY_DN) != 0;
			bool used = false;
			client.player.ang.x = f4;
			client.player.ang.y = f5;
			client.player.ang.z = f6;
			Chunk chunk1 = client.player.Chunk;
			if (client.player.vehicle == null)
			{
				client.player.move(up, dn, lt, rt, jump, sneak, run, b1, b2, fup, fdn);
				float dx = Math.Abs(client.player.pos.x - f1);
				float dy = Math.Abs(client.player.pos.y - f2);
				float dz = Math.Abs(client.player.pos.z - f3);
				if (dx > 1f || dy > 1f || dz > 1f)
				{
					Static.log("Error:client moved too far? " + dx + "," + dy + "," + dz);
					Static.log("C=" + f1 + "," + f2 + "," + f3);
					Static.log("S=" + client.player.pos.x + "," + client.player.pos.y + "," + client.player.pos.z);
					PacketMoveBack update = new PacketMoveBack(Packets.MOVEBACK, client.player.pos.x, client.player.pos.y, client.player.pos.z);
					client.serverTransport.addUpdate(update);
					client.cheat++;
					if (false && client.cheat > 20)
					{
						client.serverTransport.close();
						server.removeClient(client);
						Static.log("Removing Player because cheat > 20");
						return;
					}
				}
				else
				{
					if (dx > 0.1f || dy > 0.1f || dz > 0.1f)
					{
						Static.log("Warning:client moved too far? " + dx + "," + dy + "," + dz);
						Static.log("C=" + f1 + "," + f2 + "," + f3);
						Static.log("S=" + client.player.pos.x + "," + client.player.pos.y + "," + client.player.pos.z);
					}
					client.cheat = 0;
					client.player.pos.x = f1;
					client.player.pos.y = f2;
					client.player.pos.z = f3;
				}
			}
			else
			{
				VehicleBase veh = client.player.vehicle;
				if (veh != null)
				{
					veh.up = up;
					veh.dn = dn;
					veh.lt = lt;
					veh.rt = rt;
					veh.run = run;
					veh.sneak = sneak;
					veh.jump = jump;
				}
			}
			if (client.player.underWater)
			{
				if (client.underwaterCounter < 2 * 20)
				{
					client.underwaterCounter++;
				}
				else
				{
					client.underwaterCounter = 0;
					if (client.player.air > 0)
					{
						client.player.air--;
						client.serverTransport.sendAir(client.player);
					}
					else
					{
						client.player.takeDmg(2.0f, null); //drowning
					}
				}
			}
			else
			{
				client.underwaterCounter = 0;
				if (client.player.air != 20)
				{
					client.player.air = 20;
					client.serverTransport.sendAir(client.player);
				}
			}
			if (chunk1 == null)
			{
				Static.log("Error:chunk1 == null");
				return;
			}
			Chunk chunk2 = client.player.Chunk;
		}
	}
}
