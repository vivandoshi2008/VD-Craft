






using System;

namespace jfcraft.entity
{
	/// <summary>
	/// Arrow entity
	/// 
	/// @author vivandoshi
	/// </summary>

	using javaforce.gl;

//	import static javaforce.gl.GL.*;

	using jfcraft.data;
	using jfcraft.item;
	using jfcraft.opengl;

	public class Arrow : EntityBase
	{
	  public CreatureBase owner;
	  public bool armed;

	  //render assets
	  public static RenderDest dest;
	  public static Texture texture;
	  protected internal static string textureName;
	  private static GLModel model;

	  public Arrow()
	  {
		id = Entities.ARROW;
	  }

	  public virtual Arrow setOwner(CreatureBase owner)
	  {
		this.owner = owner;
		return this;
	  }

	  public override string Name
	  {
		  get
		  {
			return "arrow";
		  }
	  }

	  public override RenderDest Dest
	  {
		  get
		  {
			return dest;
		  }
	  }

	  public override void init(World world)
	  {
		base.init(world);
		isStatic = true;
		width = 0.5f;
		width2 = width / 2f;
		height = 0.5f;
		height2 = height / 2f;
		depth = 0.5f;
		depth2 = depth / 2f;
		maxAge = 1 * 60 * 20; //1 min
		armed = true;
		yDrag = Static.dragSpeed;
		xzDrag = yDrag * 4.0f;
	  }

	  public override void initStatic()
	  {
		base.initStatic();
		dest = new RenderDest(parts.Length);
		textureName = "entity/arrow";
		model = loadModel("arrow");
	  }

	  public override void initStaticGL()
	  {
		base.initStaticGL();
		texture = Textures.getTexture(textureName, 0);
	  }

	  public override void initInstance()
	  {
		base.initInstance();
	  }

	  private static string[] parts = new string[] {"ARROW"};

	  public override void buildBuffers(RenderDest dest, RenderData data)
	  {
		//transfer data into dest
		for (int a = 0;a < parts.Length;a++)
		{
		  RenderBuffers buf = dest.getBuffers(a);
		  GLObject obj = model.getObject(parts[a]);
		  buf.addVertex(obj.vpl.toArray());
		  buf.addPoly(obj.vil.toArray());
		  int cnt = obj.vpl.size();
		  for (int b = 0;b < cnt;b++)
		  {
			buf.addDefault();
		  }
		  if (obj.maps.size() == 1)
		  {
			GLUVMap map = obj.maps.get(0);
			buf.addTextureCoords(map.uvl.toArray());
		  }
		  else
		  {
			GLUVMap map1 = obj.maps.get(0);
			GLUVMap map2 = obj.maps.get(1);
			buf.addTextureCoords(map1.uvl.toArray(), map2.uvl.toArray());
		  }
		  buf.org = obj.org;
		  buf.type = obj.type;
		}
	  }

	  public override void bindTexture()
	  {
		texture.bind();
	  }

	  public override void copyBuffers()
	  {
		dest.copyBuffers();
	  }

	  private void setMatrixModel()
	  {
		mat.setIdentity();
		mat.addRotate(-ang.y, 0, 1, 0);
		mat.addRotate(-ang.x, 1, 0, 0);
		mat.addTranslate(pos.x, pos.y, pos.z);
		glUniformMatrix4fv(Static.uniformMatrixModel, 1, GL_FALSE, mat.m); //model matrix
	  }

	  public override void render()
	  {
		setMatrixModel();
		for (int a = 0;a < dest.count();a++)
		{
		  RenderBuffers buf = dest.getBuffers(a);
		  buf.bindBuffers();
		  buf.render();
		}
		glUniformMatrix4fv(Static.uniformMatrixModel, 1, GL_FALSE, Static.identity.m); //model matrix
	  }

	  public override void tick()
	  {
		base.tick();
	//    Static.log("arrow tick:" + x + "," + y + "," + z + ":" + xVelocity + "," + yVelocity + "," + zVelocity);
		EntityBase[] list = Static.server.world.Entities;
		for (int a = 0;a < list.Length;a++)
		{
		  EntityBase e = list[a];
		  if (e.hitBox(pos.x, pos.y + height2, pos.z, width2, height2, depth2))
		  {
			if (e is CreatureBase)
			{
			  CreatureBase cb = (CreatureBase)e;
			  bool deflected = false;
			  if (cb.blocking)
			  {
				//check if shield is facing arrow (45 deg cover)
				float aa = ang.y;
				float ca = cb.ang.y;
				ca += 180.0f;
				if (ca > 360.0f)
				{
					ca -= 360.0f;
				}







