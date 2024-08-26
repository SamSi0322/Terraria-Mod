using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJoStand.Content.HierophantGreen.Stand_arrow
{
    public class stand_arrow_hierophantgreen : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 50;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item4;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.consumable = false;
        }
        // public override bool CanUseItem(Player player)
        // {
        //     return !player.HasBuff(ModContent.BuffType<StarPlatinumBuff>());
        // }

        // public override bool UseItem(Player player)
        // {
        //     player.AddBuff(ModContent.BuffType<StarPlatinumBuff>(), 60 * 60); // 1 minute duration
        //     return true;
        // }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
        
    }
}
