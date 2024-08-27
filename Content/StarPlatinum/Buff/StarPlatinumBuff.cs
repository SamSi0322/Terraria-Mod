using Terraria;
using Terraria.ModLoader;

namespace JoJoStand.Content.StarPlatinum.Buff
{
    public class StarPlatinumBuff : ModBuff
    {
        private Item[] originalArmor = new Item[4];
        private bool armorSwitched = false;
        public bool IsStarPlatinum = false;

        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (!armorSwitched)
            {
                // 保存原始装备
                for (int i = 0; i < 4; i++)
                {
                    originalArmor[i] = player.armor[i].Clone();
                }

                // 切换到星辰套装
                player.armor[0].SetDefaults(3381); // 头盔
                player.armor[1].SetDefaults(3382); // 胸甲
                player.armor[2].SetDefaults(3383); // 腿甲

                armorSwitched = true;
            }

            if (player.buffTime[buffIndex] > 1) // 当Buff有效时
            {
            }
            else // 当Buff即将结束时
            {
                for (int i = 0; i < 4; i++)
            {
                player.armor[i].SetDefaults(originalArmor[i].type);
            }
            }
        }
    }
}
