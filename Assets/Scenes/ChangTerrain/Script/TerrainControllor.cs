using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainControllor : MonoBehaviour
{
    Terrain theTerrain;
    int hmWidth; // 地圖寬度
    int hmHeight; // 地圖長度

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        theTerrain = Terrain.activeTerrain;
        hmWidth = theTerrain.terrainData.heightmapResolution;
        hmHeight = theTerrain.terrainData.heightmapResolution;

    }


}
