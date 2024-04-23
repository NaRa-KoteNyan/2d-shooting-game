using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerExit2D(Collider2D c)
    {
        if(c.gameObject.tag == "Enemy")
        {
            Destroy(c.gameObject);
        }
        else if(c.gameObject.tag == "PlayerBullet")
        {
            Destroy(c.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
