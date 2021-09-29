using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXRay : MonoBehaviour
{
    public Terrain terrain;
    TerrainControllor tc;

    // Start is called before the first frame update
    void Start()
    {
        tc = terrain.GetComponent<TerrainControllor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){ //建立牆面
            //print(Input.mousePosition);
            //print(Camera.main.ViewportToWorldPoint(Input.mousePosition));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);   // 從滑鼠位置傳送射線
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.name);
                print ("Point: "+hit.point.x+","+hit.point.y+","+hit.point.z);
                //tc.BuildWall();
            }
        }
    }
}
