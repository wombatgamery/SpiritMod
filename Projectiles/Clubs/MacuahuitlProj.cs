using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using SpiritMod.Dusts;

namespace SpiritMod.Projectiles.Clubs
{
	class MacuahuitlProj : ClubProj
	{
		public override void SafeSetStaticDefaults()
		{
			DisplayName.SetDefault("Macuahuitl");
			Main.projFrames[Projectile.type] = 2;
		}

		public override void Smash(Vector2 position)
		{
			for (int k = 0; k <= 120; k++)
				Dust.NewDustPerfect(Projectile.oldPosition + new Vector2(Projectile.width / 2, Projectile.height / 2), DustType<MacuahuitlDust>(), new Vector2(0, 1).RotatedByRandom(1) * Main.rand.NextFloat(-1, 1) * Projectile.ai[0] / 10f);
		}

		public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            player.GetArmorPenetration(DamageClass.Melee) += (int)(Projectile.ai[0] / 2);
        }

        public override void SafeDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            int size = 66;
            if (Projectile.ai[0] >= ChargeTime)
                Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, Main.player[Projectile.owner].Center - Main.screenPosition, new Rectangle(0, size * 2, size, size), Color.White * 0.9f, TrueRotation, Origin, Projectile.scale, Effects, 1);
        }

        public MacuahuitlProj() : base(70, new Point(66, 66), 19f){}
	}
}
