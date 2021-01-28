namespace jfcraft.opengl
{
	/// <summary>
	/// An array of RenderBuffers
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce.gl;

	public class RenderDest
	{
	  private RenderBuffers[] buffers;

	  public int preferedIdx;

	  public RenderDest(int cnt)
	  {
		buffers = new RenderBuffers[cnt];
	  }

	  public virtual int count()
	  {
		return buffers.Length;
	  }

	  public virtual RenderBuffers getBuffers(int idx)
	  {
		if (buffers[idx] == null)
		{
		  buffers[idx] = new RenderBuffers();
		}
		return buffers[idx];
	  }

	  public virtual bool exists(int idx)
	  {
		if (idx >= buffers.Length)
		{
			return false;
		}
		return buffers[idx] != null;
	  }

	  public virtual bool allEmpty()
	  {
		for (int a = 0;a < buffers.Length;a++)
		{
		  if (buffers[a] != null)
		  {
			if (!buffers[a].ArrayEmpty)
			{
				return false;
			}
		  }
		}
		return true;
	  }

	  public virtual void resetAll()
	  {
		for (int a = 0;a < buffers.Length;a++)
		{
		  if (buffers[a] != null)
		  {
			buffers[a].reset();
		  }
		}
	  }

	  public virtual void copyBuffers()
	  {
		for (int a = 0;a < buffers.Length;a++)
		{
		  if (buffers[a] != null)
		  {
			buffers[a].copyBuffers();
		  }
		}
	  }
	}

}