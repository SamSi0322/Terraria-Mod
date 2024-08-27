using Terraria;
using Terraria.ModLoader;

namespace JoJoStand.Content.HierophantGreen.Buff
{
    public class HierophantGreenBuff : ModBuff
    {

        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true; 
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.immune = true; // 角色无敌
            player.immuneTime = 2; // Keeps the immunity time reset
        }
    }
}
