






using System.Collections.Generic;

namespace jfcraft.block
{
	/// 
	/// <summary>
	/// @author vivandoshi
	/// 
	/// </summary>

	using Client = jfcraft.client.Client;
	using static jfcraft.data.Direction;

	using jfcraft.opengl;

	public class BlockStairs : BlockBase
	{
	  public static int VAR_UPPER = 8;
	  public BlockStairs(string id, string[] names, string[] images) : base(id, names, images)
	  {
		isComplex = true;
		isSolid = false;
		isDir = true;
		isDirXZ = true;
	  }
	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		RenderBuffers buf = dest.getBuffers(buffersIdx);
		bool[] q = null;
		if (data.var[X] == VAR_UPPER)
		{
		  switch (data.dir[X])
		  {
			default:
			  Static.log("BlockStairs with invalid dir:" + data.dir[X]);
			  //no break
				goto case N;
			case N:
			  q = new bool[] {true, true, true, true, true, true, false, false};
			  break;
			case E:
			  q = new bool[] {true, true, false, true, true, true, false, true};
			  break;
			case S:
			  q = new bool[] {true, true, false, false, true, true, true, true};
			  break;
			case W:
			  q = new bool[] {true, true, true, false, true, true, true, false};
			  break;
			case NE:
			  q = new bool[] {true, true, true, true, true, true, false, true};
			  break;
			case NW:
			  q = new bool[] {true, true, true, true, true, true, true, false};
			  break;
			case SE:
			  q = new bool[] {true, true, false, true, true, true, true, true};
			  break;
			case SW:
			  q = new bool[] {true, true, true, false, true, true, true, true};
			  break;
			case NE2:
			  q = new bool[] {true, true, false, true, true, true, false, false};
			  break;
			case NW2:
			  q = new bool[] {true, true, true, false, true, false, false, false};
			  break;
			case SE2:
			  q = new bool[] {true, true, false, false, true, true, false, true};
			  break;
			case SW2:
			  q = new bool[] {true, true, false, false, true, true, true, false};
			  break;
		  }
		}
		else
		{
		  switch (data.dir[X])
		  {
			default:
			  Static.log("BlockStairs with invalid dir:" + (data.dir[X]));
			  //no break
				goto case N;
			case N:
			  q = new bool[] {true, true, true, true, false, false, true, true};
			  break;
			case E:
			  q = new bool[] {false, true, true, true, false, true, true, true};
			  break;
			case S:
			  q = new bool[] {false, false, true, true, true, true, true, true};
			  break;
			case W:
			  q = new bool[] {true, false, true, true, true, false, true, true};
			  break;
			case NE:
			  q = new bool[] {true, true, true, true, false, true, true, true};
			  break;
			case NW:
			  q = new bool[] {true, true, true, true, true, false, true, true};
			  break;
			case SE:
			  q = new bool[] {false, true, true, true, true, true, true, true};
			  break;
			case SW:
			  q = new bool[] {true, false, true, true, true, true, true, true};
			  break;
			case NE2:
			  q = new bool[] {false, true, true, true, false, false, true, true};
			  break;
			case NW2:
			  q = new bool[] {true, false, true, true, false, false, true, true};
			  break;
			case SE2:
			  q = new bool[] {false, false, true, true, false, true, true, true};
			  break;
			case SW2:
			  q = new bool[] {false, false, true, true, true, false, true, true};
			  break;
		  }
		}
		data.isDir = false; //do not allow rotation
		data.dir[X] = N; //do not allow rotation
		SubTexture st = getTexture(data)







