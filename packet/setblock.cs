package jfcraft.packet;


using jfcraft.client.Client;
using jfcraft.data.Star;


public class PacketSetBlock : Packet
{

    public int i1;

    public int i2;

    public int i3;

    public int i4;

    public int i5;

    public int i6;

    public PacketSetBlock()
    {

    }

    public PacketSetBlock(byte cmd) :
            base(cmd)
    {
        base.(cmd);
    }

    public PacketSetBlock(byte cmd, int i1, int i2, int i3, int i4, int i5, int i6) :
            base(cmd)
    {
        base.(cmd);
        this.i1 = this.i1;
        this.i2 = this.i2;
        this.i3 = this.i3;
        this.i4 = this.i4;
        this.i5 = this.i5;
        this.i6 = this.i6;
    }

    // process on client side
    public void process(Client client)
    {
        // i = cx,cz gx,gy,gz [id bits]
        int cx = this.i1;
        int cz = this.i2;
        int gx = this.i3;
        int gy = this.i4;
        int gz = this.i5;
        char id;
        16;
        int bits = (this.i6 & 65535);
        Chunk chunk = client.world.chunks.getChunk(client.player.dim, cx, cz);
        if ((chunk == null))
        {
            return;
        }

        chunk.setBlock(gx, gy, gz, id, bits);
        chunk.delCrack(gx, gy, gz);
    }

    public bool write(SerialBuffer buffer, bool file)
    {
        base.write(buffer, file);
        buffer.writeInt(this.i1);
        buffer.writeInt(this.i2);
        buffer.writeInt(this.i3);
        buffer.writeInt(this.i4);
        buffer.writeInt(this.i5);
        buffer.writeInt(this.i6);
        return true;
    }

    public bool read(SerialBuffer buffer, bool file)
    {
        base.read(buffer, file);
        this.i1 = buffer.readInt();
        this.i2 = buffer.readInt();
        this.i3 = buffer.readInt();
        this.i4 = buffer.readInt();
        this.i5 = buffer.readInt();
        this.i6 = buffer.readInt();
        return true;
    }
}