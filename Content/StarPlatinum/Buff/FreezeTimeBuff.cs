using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace JoJoStand.Content.StarPlatinum.Buff
{
    public class FreezeTimeBuff : ModBuff
    {
        private Dictionary<int, int> originalDamage = new Dictionary<int, int>();
        private Dictionary<int, Vector2> originalVelocity = new Dictionary<int, Vector2>();
        private List<(NPC, int)> pendingDamage = new List<(NPC, int)>();
        public bool IsStarPlatinum = false;

        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.immune = true; // 角色无敌
            player.immuneTime = 2; // 保持无敌时间

            if (player.buffTime[buffIndex] > 1) // 当Buff有效时
            {

                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly)
                    {
                        if (!originalVelocity.ContainsKey(npc.whoAmI))
                        {
                            originalVelocity[npc.whoAmI] = npc.velocity;
                            originalDamage[npc.whoAmI] = npc.damage;
                        }

                        npc.velocity = Vector2.Zero; // 暂停运动
                        npc.damage = 0; // 暂停攻击
                    }
                }

                foreach (Projectile projectile in Main.projectile)
                {
                    if (projectile.active && !projectile.friendly)
                    {
                        projectile.Kill(); // 移除敌对投射物
                    }
                    else if (projectile.active && projectile.friendly && projectile.owner == Main.myPlayer)
                    {
                        foreach (NPC npc in Main.npc)
                        {
                            if (npc.active && !npc.friendly && projectile.Hitbox.Intersects(npc.Hitbox))
                            {
                                pendingDamage.Add((npc, 2 * projectile.damage)); // 记录待处理的伤害
                                projectile.Kill(); // 移除投射物
                            }
                        }
                    }
                }
            }
            else // 当Buff即将结束时
            {
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && originalVelocity.ContainsKey(npc.whoAmI))
                    {
                        npc.velocity = originalVelocity[npc.whoAmI]; // 恢复原始速度
                        npc.damage = originalDamage[npc.whoAmI]; // 恢复原始伤害

                        // 强制刷新NPC的AI，确保他们能够继续攻击和移动
                        npc.netUpdate = true;
                    }
                }

                // 结算所有待处理的伤害
                foreach (var damageInfo in pendingDamage)
                {
                    if (damageInfo.Item1.active)
                    {
                        // 创建一个HitInfo对象来传递给StrikeNPC
                        NPC.HitInfo hitInfo = new NPC.HitInfo
                        {
                            Damage = damageInfo.Item2,
                            Knockback = 0f,
                            HitDirection = 0
                        };
                        damageInfo.Item1.StrikeNPC(hitInfo);
                    }
                }

                // 清除缓存
                originalVelocity.Clear();
                originalDamage.Clear();
                pendingDamage.Clear();
            }
        }
    }
}
