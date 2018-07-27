using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStorage : MonoBehaviour {

    public TileCollection tC;
    public ScriptableTile[] Tiles;

    public void Start()
    {
        Tiles = tC.sT;
    }
}
