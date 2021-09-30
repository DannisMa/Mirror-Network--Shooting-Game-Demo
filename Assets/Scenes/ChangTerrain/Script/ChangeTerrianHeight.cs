using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTerrianHeight : MonoBehaviour {

	public Terrain theTerrain;
    int WidthTer;
    int HeightTer;

    //unity 預設的高度倍率，在terrain.setting.resolution裡面
    float muti = 600;

    void Start(){
        theTerrain = Terrain.activeTerrain;
        WidthTer = theTerrain.terrainData.heightmapResolution;
        HeightTer = theTerrain.terrainData.heightmapResolution;

        changeTerrain();
    }
    
    void changeTerrain(){
        //heights指的是在此terrian上的所有點的height數值，先初始擷取所有點
        print(WidthTer);
        float[,] heights = theTerrain.terrainData.GetHeights(0 , 0 , WidthTer , HeightTer);
        //Debug.Log(WidthTer);

        // heights = makeCircleHeights(heights , 100 , 100 , 50 , 10.0f / muti);
        // heights = makeCircleHeights(heights, 100, 100, 40, 0.0f / muti);
        heights = makeRectangleHeights(heights, 50, 95, 90 , 10 , 10.0f / muti);

        theTerrain.terrainData.SetHeights(0,0,heights);
    }

    float[,] makeCircleHeights(float[,] heights , int posX , int posZ , int radius , float setHeight){
        for(int z = posZ - radius; z < posZ + radius; z++){
            for(int x = posX - radius; x < posX + radius; x++){
                if(Mathf.Pow (posZ - z, 2) + Mathf.Pow (posX - x, 2) < Mathf.Pow(radius , 2)){
                    heights[x, z] = setHeight;
                }
            }
        }
        return heights;
    }

    float[,] makeRectangleHeights(float[,] heights, int startX, int startZ , int theLong , int width , float setHeight){
        print(startX+":"+startZ+":"+theLong+":"+width);
        for (int z = startZ; z < startZ + width; z++){
            for (int x = startX; x < startX + theLong; x++){
                heights[x, z] = setHeight;
            }
        }
        return heights;
    }

}
