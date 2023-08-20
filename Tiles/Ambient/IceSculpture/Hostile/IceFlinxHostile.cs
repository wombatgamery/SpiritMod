using Microsoft.Xna.Framework;
using SpiritMod.Items.Placeable.Tiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SpiritMod.Tiles.Ambient.IceSculpture.Hostile
{
	public class IceFlinxHostile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Frozen Snow Flinx");
			DustType = DustID.SnowBlock;
			AddMapEntry(new Color(200, 200, 200), name);
		}

		public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = 2;

		public override void KillMultiTile(int i, int j, int frameX, int frameY) => SoundEngine.PlaySound(SoundID.Item27, new Vector2(i, j) * 16);

		public override void NearbyEffects(int i, int j, bool closer)
		{
			Player player = Main.LocalPlayer;
			if (closer) {
				int distance1 = (int)Vector2.Distance(new Vector2(i * 16, j * 16), player.Center);
				if (distance1 < 56) {
					SoundEngine.PlaySound(SoundID.Item27);
					int n = NPC.NewNPC(new Terraria.DataStructures.EntitySource_TileUpdate(i, j), i * 16, j * 16, NPCID.SnowFlinx, 0, 0, 0, 0, 0, Main.myPlayer);
					Main.npc[n].GivenName = "Icy Snow Flinx";
					Main.npc[n].lifeMax = Main.npc[n].lifeMax * 2;
					Main.npc[n].life = Main.npc[n].lifeMax;
					Main.npc[n].damage = (int)(Main.npc[n].damage * 1.5f);
					Main.npc[n].knockBackResist = 0.8f;
                    Main.npc[n].netUpdate = true;
					WorldGen.KillTile(i, j);
				}
			}
		}
	}
}