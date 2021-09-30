using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainControllor : MonoBehaviour
{
    Terrain theTerrain;
    int hmWidth;  // hight map的寬(應該是地圖的解析度啦)
    int hmHeight; // hight map的長
    int correctHMarrayX;
    int correctHMarrayY;

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


    /// <summary>
    /// 點選的世界座標 減去 地形的世界座標
    /// 再將結果除與地形的大小
    /// 再乘與高度圖解析度，得到正確的高度圖陣列位置
    /// </summary>
    void ConverPosition(Vector3 target_position){

        Vector3 temp_position = (target_position - this.gameObject.transform.position);

        Vector3 pos;
        pos.x = temp_position.x/theTerrain.terrainData.size.x; // 除地圖大小寬
        pos.y = temp_position.y/theTerrain.terrainData.size.y; // 除地圖大小高
        pos.z = temp_position.z/theTerrain.terrainData.size.z; // 除地圖大小長

        correctHMarrayX = (int) (pos.x * hmWidth); 
        correctHMarrayY = (int) (pos.z * hmHeight);
    }

    float[,] makeRectangleHeights(float[,] heights, int startX, int startZ , int theLong , int width , float setHeight){
        for (int z = startZ; z < startZ + width; z++){
            for (int x = startX; x < startX + theLong; x++){
                heights[x, z] = setHeight;
            }
        }
        return heights;
    }
    
    public void RiseTerrain(Vector3 target_position){
        ConverPosition(target_position);
        //print(correctHMarrayY+":"+correctHMarrayX);
        //print(hmWidth);
        float[,] heights = theTerrain.terrainData.GetHeights(0,0,hmWidth,hmHeight);
        
        heights = makeRectangleHeights(heights,correctHMarrayY,correctHMarrayX,10,10,10.0f / 600);
        theTerrain.terrainData.SetHeights(0, 0, heights);
        //print("END");
    }


}
