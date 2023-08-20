using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace SpiritMod.Items.BossLoot.AvianDrops
{
	public class Trophy2Tile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;

			Terraria.ID.TileID.Sets.FramesOnKillWall[Type] = true;
			Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);

			DustType = 7;
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Ancient Avian Trophy");
			AddMapEntry(new Color(120, 85, 60), name);
		}
	}
}