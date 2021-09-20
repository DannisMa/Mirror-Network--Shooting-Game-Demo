using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public GameObject magicEffect;
    public GameObject body;
    
    int atk;
    // Start is called before the first frame update
    void Start()
    {
        atk = 15;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            other.gameObject.GetComponent<Player>().TakeDamage(atk);
        }
        else if(other.tag == "Monster"){
            other.gameObject.GetComponent<Monster>().TakeDamage(atk);
        }
        if(other.tag == "Player" || other.tag == "Monster"){
            GameObject mge = Instantiate(magicEffect , this.transform.position , this.transform.rotation);
            body.SetActive(false);
            mge.transform.SetParent(this.gameObject.transform);
            Destroy(this.gameObject,2);
        }

    }
}
