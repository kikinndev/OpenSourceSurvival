using System.Numerics;

namespace Main;

public class TileMap
{
    public Dictionary<Vector2, Tile> worldTiles = new Dictionary<Vector2, Tile>();
    public Dictionary<Vector2, Tile> objectTiles = new Dictionary<Vector2, Tile>();

    int width;
    int height;

    public TileMap(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void GenerateWorld()
    {
        worldTiles.Clear();
        objectTiles.Clear();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector2 gridPos = new Vector2(x, y);
                Vector2 worldPos = MathUtils.GridToWorld(gridPos);

                worldTiles[gridPos] = new Tile(TileId.Grass, worldPos);
            }
        }
    }

    public bool IsSolidAtWorldPos(Vector2 worldPos)
    {
        Vector2 gridPos = MathUtils.WorldToGrid(worldPos);

        if (objectTiles.ContainsKey(gridPos))
        {
            return TileDatabase.tileData[objectTiles[gridPos].id].isSolid;
        }

        if (worldTiles.ContainsKey(gridPos))
        {
            return TileDatabase.tileData[worldTiles[gridPos].id].isSolid;
        }

        return true;
    }

    public void Draw()
    {
        foreach (Tile tile in worldTiles.Values)
        {
            tile.Draw();
        }

        foreach (Tile tile in objectTiles.Values)
        {
            tile.Draw();
        }
    }

    public void Unload()
    {
        worldTiles.Clear();
        objectTiles.Clear();
    }
}