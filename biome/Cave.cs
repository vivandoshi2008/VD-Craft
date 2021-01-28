package jfcraft.feature;
using java.awt.geom.Star;
using java.awt.Star;
using javaforce.gl.Star;
using javaforce.Star;
using jfcraft.data.Star;
using static;
jfcraft.data.Static.Star;
using static;
jfcraft.data.Direction.Star;
public class Cave : Eraser
{

    private static JFImage imgXZ = new JFImage(16, 16);

    private static JFImage imgY = new JFImage(16, 256);

    private int dir;

    private int dir1;

    private int dir2;

    private int path;

    private int level;

    private int nx;

    private int ny;

    private int nz;

    private int ex;

    private int ey;

    private int ez;

    private int sx;

    private int sy;

    private int sz;

    private int wx;

    private int wy;

    private int wz;

    private int nsy;

    private int wey;

    private int nwy;

    private int ney;

    private int swy;

    private int sey;

    // mid-point elevations
    private bool eop;
}
privatebool[] connected = new bool[4];
Unknown

    private void setupCaves()
{
    int _wx = ((chunk.cx * 16)
                + level);
    int _wz = ((chunk.cz * 16)
                + level);
    sx = (Static.noiseInt(N_RANDOM1, 8, _wx, _wz) + 4);
    sz = 15;
    sy = Static.noiseInt(N_RANDOM3, 16, _wx, _wz);
    sy = (sy + levelBase[level]);
    ex = 15;
    ez = (Static.noiseInt(N_RANDOM5, 8, _wx, _wz) + 4);
    ey = Static.noiseInt(N_RANDOM6, 16, _wx, _wz);
    ey = (ey + levelBase[level]);
    bool connect = false;
    switch (Static.noiseInt(N_RANDOM7, 3, _wx, _wz))
    {
        case 0:
            dir = NW;
            dir2 = SE;
            connect = false;
            break;
        case 1:
            dir = NS;
            dir2 = WE;
            connect = (Static.noiseInt(N_RANDOM8, 2, _wx, _wz) == 0);
            break;
        case 2:
            dir = NE;
            dir2 = SW;
            connect = false;
            break;
    }
    _wz -= 16;
    nx = (Static.noiseInt(N_RANDOM1, 8, _wx, _wz) + 4);
    nz = -1;
    ny = Static.noiseInt(N_RANDOM3, 16, _wx, _wz);
    ny = (ny + levelBase[level]);
    _wz += 16;
    _wx -= 16;
    wx = -1;
    wz = (Static.noiseInt(N_RANDOM5, 8, _wx, _wz) + 4);
    wy = Static.noiseInt(N_RANDOM6, 16, _wx, _wz);
    wy = (wy + levelBase[level]);
    _wx += 16;
    // calc mid-point y
    if (connect)
    {
        nsy = ((ny + sy)
                    / 2);
        wey = ((wy + ey)
                    / 2);
        nwy = ((ny + wy)
                    / 2);
        ney = ((ny + ey)
                    / 2);
        swy = ((sy + wy)
                    / 2);
        sey = ((sy + ey)
                    / 2);
    }
    else
    {
        nsy = levelBase[level];
        wey = levelBase[level];
        nwy = levelBase[level];
        ney = levelBase[level];
        swy = levelBase[level];
        sey = levelBase[level];
        // avoid connections
        switch (dir1)
        {
            case NW:
                swy += 12;
                break;
            case NS:
                wey += 12;
                break;
            case NE:
                swy += 12;
                break;
        }
    }

    connected[level] = connect;
    if ((level > 1))
    {
        if ((connect && connected[(level - 1)]))
        {
            // connect to lower level
            (new CaveElevator() + build(chunk, data, (levelBase[level] - (16 - (4 - 15))), levelBase[level]));
        }

    }

    nsy = (nsy
                + (Static.noiseInt(N_RANDOM1, 3, _wx, _wz) - 1));
    wey = (wey
                + (Static.noiseInt(N_RANDOM2, 3, _wx, _wz) - 1));
    nwy = (nwy
                + (Static.noiseInt(N_RANDOM3, 3, _wx, _wz) - 1));
    ney = (ney
                + (Static.noiseInt(N_RANDOM4, 3, _wx, _wz) - 1));
    swy = (swy
                + (Static.noiseInt(N_RANDOM5, 3, _wx, _wz) - 1));
    sey = (sey
                + (Static.noiseInt(N_RANDOM6, 3, _wx, _wz) - 1));
    setSize(8);
    setPos(nx, ny, nz);
    setCenter(4, 0, 4);
    // center bottom
    setFill(Blocks.LAVA, 10);
    // fill with LAVA when y <= 10
    buildPath();
    buildProfiles();
    path = 1;
    eop = false;
}

private void buildProfiles()
{
    int wx = (chunk.cx * 16);
    int wz = (chunk.cz * 16);
    for (int side = 0; (side < 4); side++)
    {
        float e = 2;
        float f = 0.5;
        for (int pos = 2; (pos < 4); pos++)
        {
            e = (e
                        + (Static.abs(Static.noiseFloat(N_RANDOM2, (wx + side), (wz + pos))) * f));
            f += 1.5;
            if ((e >= 6))
            {
                e = 6;
            }

            profiles[side][pos] = e;
            profiles[side][(7 - pos)] = e;
        }

    }

}

private void buildShape()
{
    int wx = (chunk.cx * 16);
    int wz = (chunk.cz * 16);
    int px = (wx + getX());
    int pz = (wz + getZ());
    resetShape();
    for (int z = 2; (z < 6); z++)
    {
        for (int x = 2; (x < 6); x++)
        {
            int dA = ((int)((Static.min(profiles[0][z], profiles[1][x]) + Static.abs((Static.noiseFloat(N_RANDOM2, (px + x), (pz + z)) * 0.5)))));
            int dB = ((int)((Static.min(profiles[2][z], profiles[3][x]) + Static.abs((Static.noiseFloat(N_RANDOM3, (px + x), (pz + z)) * 0.5)))));
            if ((dA < 0))
            {
                dA = 0;
            }

            if ((dA > 4))
            {
                dA = 4;
            }

            if ((dB < 0))
            {
                dB = 0;
            }

            if ((dB > 4))
            {
                dB = 4;
            }

            for (int yA = 1; (yA <= dA); yA++)
            {
                setShape(x, (4 - yA), z);
            }

            for (int yB = 1; (yB <= dB); yB++)
            {
                setShape(x, (3 + yB), z);
            }

        }

    }

}

private static int black = 0;

private static int white = 16777215;

private static int red = 16711680;

private void buildPath()
{
    // draw bezier curves
    imgXZ.fill(0, 0, 16, 16, white);
    imgXZ.getGraphics2D().setColor(Color.black);
    imgY.fill(0, 0, 16, 256, white);
    imgY.getGraphics2D().setColor(Color.black);
    switch (dir)
    {
        case NS:
            // N->S
            imgXZ.getGraphics2D().draw(new CubicCurve2D.Float(nx, nz, 8, 8, 8, 8, sx, sz));
            imgY.getGraphics2D().draw(new CubicCurve2D.Float(0, ny, 8, nsy, 8, nsy, 15, sy));
            break;
        case NW:
            // N->W
            imgXZ.getGraphics2D().draw(new CubicCurve2D.Float(nx, nz, 8, 8, 8, 8, wx, wz));
            imgY.getGraphics2D().draw(new CubicCurve2D.Float(0, ny, 8, nwy, 8, nwy, 15, wy));
            break;
        case NE:
            // N->E
            imgXZ.getGraphics2D().draw(new CubicCurve2D.Float(nx, nz, 8, 8, 8, 8, ex, ez));
            imgY.getGraphics2D().draw(new CubicCurve2D.Float(0, ny, 8, ney, 8, ney, 15, ey));
            break;
        case WE:
            // W->E
            imgXZ.getGraphics2D().draw(new CubicCurve2D.Float(wx, wz, 8, 8, 8, 8, ex, ez));
            imgY.getGraphics2D().draw(new CubicCurve2D.Float(0, wy, 8, wey, 8, wey, 15, ey));
            break;
        case SW:
            // S->W
            imgXZ.getGraphics2D().draw(new CubicCurve2D.Float(sx, sz, 8, 8, 8, 8, wx, wz));
            imgY.getGraphics2D().draw(new CubicCurve2D.Float(0, sy, 8, swy, 8, swy, 15, wy));
            break;
        case SE:
            // S->E
            imgXZ.getGraphics2D().draw(new CubicCurve2D.Float(sx, sz, 8, 8, 8, 8, ex, ez));
            imgY.getGraphics2D().draw(new CubicCurve2D.Float(0, sy, 8, sey, 8, sey, 15, ey));
            break;
    }
    // imgXZ.putPixel(nx, nz, red);  //off-image
    imgY.putPixel(0, ny, red);
}

public bool setup()
{
    level = 1;
    setupCaves();
    return true;
}

public void move()
{
    // move using image (bezier curved path)
    int x = getX();
    int y = getY();
    int z = getZ();
    bool moved = false;
    int xz = 0;
outY:
    for (xz = 0; (xz < 16); xz++)
    {
        for (int dy = -1; (dy <= 1); dy++)
        {
            int new_y = (y + dy);
            if (((new_y < 0)
                        || (new_y > 255)))
            {
                // TODO: Warning!!! continue If
            }

            if ((imgY.getPixel(xz, (y + dy)) == black))
            {
                // xz value ignored
                y = new_y;
                imgY.putPixel(xz, y, red);
                moved = true;
                break;
                outY;
            }

        }

    }

outXZ:
    for (int dx = -1; (dx <= 1); dx++)
    {
        for (int dz = -1; (dz <= 1); dz++)
        {
            int new_x = (x + dx);
            int new_z = (z + dz);
            if (((new_x < 0)
                        || (new_x > 15)))
            {
                // TODO: Warning!!! continue If
            }

            if (((new_z < 0)
                        || (new_z > 15)))
            {
                // TODO: Warning!!! continue If
            }

            if ((imgXZ.getPixel(new_x, new_z) == black))
            {
                x = new_x;
                z = new_z;
                imgXZ.putPixel(x, z, red);
                moved = true;
                break;
                outXZ;
            }

        }

    }

    setPos(x, y, z);
    eop = !moved;
}

public bool endPath()
{
    return eop;
}

public bool nextPath()
{
    if ((path == 2))
    {
        level++;
        if ((level > 3))
        {
            return false;
        }

        setupCaves();
        return true;
    }
    else
    {
        dir = dir2;
        switch (dir)
        {
            case SE:
                setPos(sx, sy, sz);
                break;
            case WE:
                setPos(wx, wy, wz);
                break;
            case SW:
                setPos(sx, sy, sz);
                break;
        }
        buildPath();
        eop = false;
        path++;
        return true;
    }

}

public void preErase()
{
    buildShape();
}

public void postErase()
{

}