using System;
using Single.MahjongDataType;
using UnityEngine;

namespace Single
{
    public static class MahjongConstants
    {
        public const int WallCount = 4;
        public const int WallTilesCount = 34;
        public const int TotalTilesCount = WallCount * WallTilesCount;
        public const int TileKinds = 34;
        public const int SuitCount = 4;
        public const int CompleteHandTilesCount = 13;
        public const int FullHandTilesCount = 14;
        public const float Gap = 0.0005f;
        public const float TileWidth = 0.026667f;
        public const float TileThickness = 0.016f;
        public const float TileHeight = 0.0393334f;
        public const float UiGap = 20;
        public static readonly Quaternion FacePlayer = Quaternion.Euler(270, 0, -90);
        public static readonly Quaternion FaceUp = Quaternion.Euler(-90, 0, -90);
        // UI Settings
        public const int YakuItemColumns = 2;
        public const int FullItemCountPerColumn = 4;
        // Yaku ranks
        public const int Mangan = 2000;
        public const int Haneman = 3000;
        public const int Baiman = 4000;
        public const int Sanbaiman = 6000;
        public const int Yakuman = 8000;

        public static int RepeatIndex(int index, int length)
        {
            while (index >= length) index -= length;
            while (index < 0) index += length;
            return index;
        }

        public static string GetTileName(Tile tile)
        {
            int index = tile.IsRed ? 0 : tile.Rank;
            return index + tile.Suit.ToString().ToLower();
        }

        public static MeldInstanceType GetMeldDirection(int currentPlayerIndex, int discardPlayerIndex,
            bool isKong = false)
        {
            if (RepeatIndex(currentPlayerIndex + 1, WallCount) == discardPlayerIndex) 
                return !isKong ? MeldInstanceType.Right : MeldInstanceType.RightKong;
            if (RepeatIndex(currentPlayerIndex - 1, WallCount) == discardPlayerIndex) 
                return !isKong ? MeldInstanceType.Left : MeldInstanceType.LeftKong;
            return !isKong ? MeldInstanceType.Opposite : MeldInstanceType.OppositeKong;
        }
    }

    [Flags]
    public enum InTurnOperation
    {
        Discard = 1 << 0,
        Richi = 1 << 1,
        Tsumo = 1 << 2,
        Kong = 1 << 3,
    }

    [Flags]
    public enum OutTurnOperation
    {
        Skip = 1 << 0,
        Chow = 1 << 1,
        Pong = 1 << 2,
        Kong = 1 << 3,
        Rong = 1 << 4,
    }
}