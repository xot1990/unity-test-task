using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileCustom
{
    public Vector3 worldPosition;
    public AbstractUnit placedUnit;
    public bool isRock;
    public Vector2Int tileNumber;
    public bool isPlayerHere;
}


