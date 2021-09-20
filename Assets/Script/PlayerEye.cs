using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEye : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player"){
            print(other.gameObject.GetComponent<Player>().GetHP());
        }
    }
}
