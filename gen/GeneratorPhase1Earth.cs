






using System;

namespace jfcraft.gen
{
/// <summary>
/// Chunk Generator
/// 
/// @author vivandoshi
/// 

/// </summary>

using jfcraft.data;
using jfcraft.biome;
using jfcraft.feature;
using static jfcraft.data.Chunk;
using static jfcraft.data.Direction;
using static jfcraft.data.Biomes;
using static jfcraft.data.Static;

public class GeneratorPhase1Earth : GeneratorPhase1Base
{
private GeneratorChunk chunk = new GeneratorChunk();
private BiomeData data = new BiomeData();

public virtual void reset()
{
}

public virtual Chunk generate(int dim, int cx, int cz)
{
chunk.clear();
chunk.seed = Seed;
chunk.dim = dim;
chunk.cx = cx;
chunk.cz = cz;

data.setChunk(chunk);

generateBiomes();

fillStone();

if (!hasOcean())
{
	float features = noiseFloat(N_ELEV3, cx * 16, cz * 16) * 100.0f;

	if (features > 50f)
	{
	//new Fortress().build(chunk, data);  //TODO
	}
	else if (features < -50f)
	{
	(new MineShaft()).build(chunk, data);
	}
	else
	{
	(new Cave()).build(chunk, data);
	}
}

(new TopSoil()).build(chunk, data);

addDeposits();

return chunk.toChunk();
}

private long Seed
{
	get
	{
	float _r1 = noiseFloat(N_RANDOM1, chunk.cx, chunk.cz); //-1,1
	float _r2 = noiseFloat(N_RANDOM2, chunk.cx, chunk.cz); //-1,1
	int _i1 = Float.floatToRawIntBits(_r1);
	int _i2 = Float.floatToRawIntBits(_r2);
	long seed = _i1;
	seed <<= 32;
	seed |= _i2;
	return seed;
	}
}

public virtual void getIDs()
{
}

//clamp 0.0f - 1.0f
private float clamp(float val, float min, float max)
{
if (val <= min)
{
	return 0;
}
if (val >= max)
{
	return 1;
}
return (val - min) / (max - min);
}

private void generateBiomes()
{
	int p = 0;
	for (int z = 0; z < 16; z++)
	{
		for (int x = 0; x < 16; x++)
		{
			int wx = chunk.cx * 16 + x;
			int wz = chunk.cz * 16 + z;
			float temp = noiseFloat(N_TEMP, wx, wz) * 50.0f + 50.0f; //0 - 100
			float rain = noiseFloat(N_RAIN, wx, wz) * 50.0f + 50.0f; //0 - 100
			float elev;

			//determine biome type (Biome....)
			sbyte biome = -1;
			if (temp < 16.0)
			{
				biome = TUNDRA;
			}
			else if (temp < 32.0)
			{
				biome = TAIGA;
			}
			else
			{
				if (rain > 66.0)
				{
					if (temp > 80.0)
					{
						biome = JUNGLE;
					}
					else if (temp > 50.0)
					{
						biome = SWAMP;
					}
					else
					{
						biome = DARK_FOREST;
					}
				}
				else if (rain < 33.0)
				{
					biome = temp < 80.0 ? PLAINS : DESERT;
				}
				else
				{
					biome = FOREST;
				}
			}

			/// <summary>
			/// Plains map defined the base elevation. </summary>
			float plains = abs(noiseFloat(N_ELEV1, wx, wz) * 3.0f);

			float swamps = 0;

			if (biome == SWAMP)
			{
				/// <summary>
				/// If biome == SWAMP than the elevation is lowered to create swamps. </summary>
				float scale = 1.0f * clamp(rain, 66.0f, 71.0f) * clamp(temp, 50.0f, 55.0f);
				swamps = abs(noiseFloat(N_ELEV4, wx, wz) * 3.0f) * scale;
			}

			/// <summary>
			/// Hills map.  Creates small hills in elevation.
			/// Range : -15 to +15
			/// Hills : +10 to +15
			/// No change : -15 to 10
			/// </summary>
			float hills = noiseFloat(N_ELEV2, wx, wz) * 15.0f;

			/// <summary>
			/// Extreme range defines mountains and oceans.
			/// Range : -75 to +75
			/// Mountains : +25 to +75
			/// No change : -25 to +25
			/// Oceans : -75 to -25
			/// </summary>
			float extreme = noiseFloat(N_ELEV3, wx, wz) * 75.0f;

			/// <summary>
			/// When rivers map intersects with extreme map it creates a river.
			///  The river map does NOT extend into ranges that cause mountains or oceans.
			///  Range : -20 to 20
			/// </summary>
			float rivers = noiseFloat(N_ELEV6, wx, wz) * 20.0f;

			elev = (SEALEVEL + plains - swamps);
			if (extreme <= -25.0f)
			{
				extreme += 25.0f;
				elev += extreme;
				biome = OCEAN;
			}
			else if (extreme >= 25.0f)
			{
				extreme -= 25.0f;
				elev += extreme;
			}

			if (hills > 5.0f)
			{
				hills -= 5.0f;
				elev += hills;
			}

			float riverElev = abs(extreme - rivers);
			if (riverElev <= 5f)
			{
				riverElev = 5f - riverElev; //inverse level
				elev -= riverElev * 0.7f;
			}
		}
	}
}




