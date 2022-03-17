using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Map : MonoBehaviourService<Map>
{    
    public int sizeX;
    public int sizeY;

    public float sizeXoffset;

    public Vector3 _worldOffset;
    public TileCustom[,] _tiles;

    public GameObject testPref;

    protected override void OnCreateService()
    {
        
    }

    protected override void OnDestroyService()
    {
        
    }

    void Start()
    {
        MapInit();
        Debug.Log(GetTile(new Vector2Int(0, 8)).isRock);
    }

   
    void Update()
    {
        
    }

    private void MapInit()
    {        
        _tiles = new TileCustom[sizeX, sizeY];
        _tiles[0, 0] = new TileCustom() { worldPosition = new Vector3(0, 0, 0), };

        for (int i = 0; i < sizeX; i++)
        {
            for (int k = 0; k < sizeY; k++)
            {
                if (_tiles[i, k] != null)
                    continue;

                if (k == sizeY || k == 0 || i == sizeX || i == 0)
                {
                    _tiles[i, k] = new TileCustom()
                    {
                        worldPosition = _worldOffset * k + new Vector3(i + i * sizeXoffset, k) + _worldOffset * i,
                        isRock = false,
                        tileNumber = new Vector2Int(i,k)
                    };
                }
                else
                {
                    if (k % 2 != 0 && i % 2 != 0)
                        _tiles[i, k] = new TileCustom()
                        {
                            worldPosition = _worldOffset * k + new Vector3(i + i * sizeXoffset, k),
                            isRock = true,
                            tileNumber = new Vector2Int(i, k)
                        };
                    else _tiles[i, k] = new TileCustom()
                    {
                        worldPosition = _worldOffset * k + new Vector3(i + i * sizeXoffset, k),
                        isRock = false,
                        tileNumber = new Vector2Int(i, k)
                    };
                }
                
            }
        }

        foreach(var tile in _tiles)
        {
            if (tile.isRock)
                Instantiate(testPref, tile.worldPosition, Quaternion.identity);
        }
        
    }

   
    public Vector2Int WorldToMapPosition(Vector3 position)
    {
        Vector3 rawPosition = new Vector3(position.x - position.x * sizeXoffset - position.y * _worldOffset.x, position.y, position.z);
        return new Vector2Int(Mathf.RoundToInt(rawPosition.x), Mathf.RoundToInt(rawPosition.y));
    }

    public TileCustom GetTile(Vector2Int point)
    {
        return GetTile(point.x, point.y);
    }

    public TileCustom GetTile(int x, int y)
    {
        if (x < 0
            || x >= _tiles.GetLength(0)
            || y < 0
            || y >= _tiles.GetLength(1))
            return null;

        return _tiles[x, y];
    }
}
