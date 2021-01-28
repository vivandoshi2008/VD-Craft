






using System.Collections.Generic;

namespace jfcraft.data
{
	/// <summary>
	/// Recipe registry
	/// 
	/// @author vivandoshi
	/// 
	/// </summary>

	using jfcraft.item;
	using jfcraft.recipe;

	public class Recipes
	{
	  public List<Recipe> receipes = new List<Recipe>();

	  public virtual void registerRecipe(Recipe r)
	  {
		receipes.Add(r);
	  }

	  public virtual void registerDefault()
	  {
		registerRecipe(new RecipeBread());
		registerRecipe(new RecipePlanks());
		registerRecipe(new RecipeCraftTable());
		registerRecipe(new RecipeFurnace());
		registerRecipe(new RecipeStick());
		registerRecipe(new RecipeTorch());
		registerRecipe(new RecipePickAxe());
		registerRecipe(new RecipeAxe());
		registerRecipe(new RecipeShovel());
		registerRecipe(new RecipeSword());
		registerRecipe(new RecipeHoe());
		registerRecipe(new RecipeFlintAndSteel());
		registerRecipe(new RecipeBow());
		registerRecipe(new RecipeArrow());
		registerRecipe(new RecipeBowl());
		registerRecipe(new RecipeMushroomStew());
		registerRecipe(new RecipeHelmet());
		registerRecipe(new RecipeBoots());
		registerRecipe(new RecipeChestArmor());
		registerRecipe(new RecipePants());
		registerRecipe(new RecipePainting());
		registerRecipe(new RecipeSign());
		registerRecipe(new RecipeDoor());
		registerRecipe(new RecipeBucket());
		registerRecipe(new RecipeMinecart());
		registerRecipe(new RecipeSaddle());
		registerRecipe(new RecipeBoat());
		registerRecipe(new RecipeBook());
		registerRecipe(new RecipeCompass());
		registerRecipe(new RecipeFishingRod());
		registerRecipe(new RecipeCake());
		registerRecipe(new RecipeBed());
		registerRecipe(new RecipeCookie());
		registerRecipe(new RecipeBoneMeal());
		registerRecipe(new RecipeShears());
		registerRecipe(new RecipeBrewingStand());
		registerRecipe(new RecipeCauldron());
		registerRecipe(new RecipeItemFrame());
		registerRecipe(new RecipePot());
		registerRecipe(new RecipePumpkinPie());
		registerRecipe(new RecipePumpkinSeeds());
		registerRecipe(new RecipePumpkinLit());
		registerRecipe(new RecipeLead());
		registerRecipe(new RecipeSugar());
		registerRecipe(new RecipePaper());
		registerRecipe(new RecipeChest());
		registerRecipe(new RecipePiston());
		registerRecipe(new RecipePistonSticky());
		registerRecipe(new RecipeStairs());
		registerRecipe(new RecipeBrickBlock());
		registerRecipe(new RecipeTNT());
		registerRecipe(new RecipeBookshelf());
		registerRecipe(new RecipeLadder());
		registerRecipe(new RecipeRail());
		registerRecipe(new RecipeLever());
		registerRecipe(new RecipePressurePlate());
		registerRecipe(new RecipeRedstoneTorch());
		registerRecipe(new RecipeButton());
		registerRecipe(new RecipeFence());
		registerRecipe(new RecipeGate());
		registerRecipe(new RecipeBars());
		registerRecipe(new RecipeGlassPane());
		registerRecipe(new RecipeWall());
		registerRecipe(new RecipeHopper());
		registerRecipe(new RecipeCarpet());
		registerRecipe(new RecipePoweredRail());
		registerRecipe(new RecipeDetectorRail());
		registerRecipe(new RecipeDispenser());
		registerRecipe(new RecipeDropper());
		registerRecipe(new RecipeMinecartChest());
		registerRecipe(new RecipeMinecartFurnace());
		registerRecipe(new RecipeMinecartHopper());
		registerRecipe(new RecipeMinecartTNT());
		registerRecipe(new RecipeEnderChest());
		registerRecipe(new RecipeTripHook());
		registerRecipe(new RecipeBottle());
		registerRecipe(new RecipeEnderEye());
		registerRecipe(new RecipeBlock3x3());
		registerRecipe(new RecipeBlock2x2());
		registerRecipe(new RecipeExpand());
		registerRecipe(new RecipeSolarPanel());
		registerRecipe(new RecipeRedstoneComparator());
		registerRecipe(new RecipeRedstoneRepeater());
		registerRecipe(new RecipeDyes());
		registerRecipe(new RecipeShield());
	  }

	  public virtual Item make3x3(Item[] items)
	  {
		for (int a = 0;a < 9;a++)
		{
		  if (items[a].count == 0)
		  {
			  items[a].id = (char)0;
		  }
		}
		Item item;
		if ((items[0].id == (char)0) && items[1].id == (char)0 && items[2].id == (char)0)
		{
		  //top row empty







