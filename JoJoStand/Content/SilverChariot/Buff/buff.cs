// using Terraria;
// using Terraria.ModLoader;

// namespace JoJoStand.Content.StarPlatinum.Buff
// {
//     public class buff : ModBuff
//     {
//         public override void SetStaticDefaults()
//         {
//             DisplayName.SetDefault("Star Platinum");
//             Description.SetDefault("You have transformed into Star Platinum! Increased damage, defense, and speed. Ora!!!");
//             Main.buffNoTimeDisplay[Type] = false;
//             Main.debuff[Type] = false;
//         }

//         public override void Update(Player player, ref int buffIndex)
//         {
//             if (player.buffTime[buffIndex] <= 0 || player.statLife <= 0)
//             {
//                 player.ClearBuff(buffIndex);
//                 // Revert appearance when buff ends
//                 var standPlayer = player.GetModPlayer<StandPlayer>();
//                 if (standPlayer.originalLife > 0)
//                 {
//                     player.statLife = standPlayer.originalLife; // Restore original life
//                     player.head = standPlayer.originalHead;
//                     player.body = standPlayer.originalBody;
//                     player.legs = standPlayer.originalLegs;
//                 }
//                 return;
//             }

//             player.statDefense += 20;
//             player.meleeDamage += 1f;
//             player.moveSpeed += 0.5f;

//             // Apply appearance changes
//             // var modPlayer = player.GetModPlayer<StandPlayer>();
//             // if (player.head != ModContent.GetEquipSlot("StarPlatinumHead", EquipType.Head))
//             // {
//             //     modPlayer.originalLife = player.statLife; // Store original life
//             //     modPlayer.originalHead = player.head;
//             //     modPlayer.originalBody = player.body;
//             //     modPlayer.originalLegs = player.legs;

//             //     player.head = ModContent.GetEquipSlot("StarPlatinumHead", EquipType.Head);
//             //     player.body = ModContent.GetEquipSlot("StarPlatinumBody", EquipType.Body);
//             //     player.legs = ModContent.GetEquipSlot("StarPlatinumLegs", EquipType.Legs);
//             // }
//         }
//     }
// }
