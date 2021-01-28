using System;
using System.Text;

namespace jfcraft.data
{
	/// 
	/// <summary>
	/// @author vivandoshi
	/// </summary>

	public class Profiler
	{
	  private const int MAX = 16;
	  private long[] ts = new long[MAX];
	  private int cnt;
	  private string name;

	  public Profiler(string name)
	  {
		this.name = name;
	  }

	  public virtual void start()
	  {
		cnt = 0;
		next();
	  }

	  public virtual void next()
	  {
		ts[cnt++] = DateTimeHelper.CurrentUnixTimeMillis();
	  }

	  public virtual void print()
	  {
		StringBuilder sb = new StringBuilder();
		sb.Append(name);
		for (int a = 1;a < cnt;a++)
		{
		  long diff = ts[a] - ts[a - 1];
		  if (a > 1)
		  {
			  sb.Append(',');
		  }
		  sb.Append(Convert.ToString(diff));
		}
		Static.log(sb.ToString());
	  }
	}

}