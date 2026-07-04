using System.Resources;

namespace Main;

public enum TileId
{
    Grass,
    Table,
}

public static class TileIdExtensions
{
    public static string GetTexturePath(this TileId tileId)
    {
        return tileId switch
        {
            TileId.Grass => "Resources/Tiles/grass.png",
            TileId.Table => "Resources/Tiles/table.png",
            _ => "Resources/Tiles/missing.png"
        };
    }
}