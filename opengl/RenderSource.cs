namespace jfcraft.opengl
{
	/// 
	/// <summary>
	/// @author vivandoshi
	/// 
	/// </summary>

	using javaforce.gl;

	public interface RenderSource
	{
	  void buildBuffers(RenderDest dest, RenderData data);
	  void bindTexture();
	  void render();
	}

}