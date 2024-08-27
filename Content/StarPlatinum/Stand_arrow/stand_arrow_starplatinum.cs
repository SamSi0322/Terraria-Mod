using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using System;

namespace JoJoStand.Content.StarPlatinum.Stand_arrow
{
    public class stand_arrow_starplatinum : ModItem
    {
         private DateTime lastUseTime;

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 50;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = new SoundStyle($"{nameof(JoJoStand)}/Content/StarPlatinum/Stand_arrow/stand_arrow_starplatinumSound") {
				Volume = 0.9f,
				PitchVariance = 0.2f,
				MaxInstances = 3,
			};
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.consumable = false;
        }
        
         public override bool CanUseItem(Player player)
        {
            TimeSpan cooldown = TimeSpan.FromMinutes(2); // 设置冷却时间为2分钟
            if (DateTime.Now - lastUseTime < cooldown)
            {
                // 冷却时间还没结束，阻止使用
                Main.NewText("You need to wait before using this item again!", 255, 0, 0);
                return false; // 阻止使用物品
            }
            return true; // 允许使用物品
        }

        public override bool? UseItem(Player player)
        {
            // 更新最后一次使用时间
            lastUseTime = DateTime.Now;

            // 给予Buff
            player.AddBuff(ModContent.BuffType<Buff.FreezeTimeBuff>(), 1200);
            player.AddBuff(ModContent.BuffType<Buff.StarPlatinumBuff>(), 3600);

            return true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
    }
}
