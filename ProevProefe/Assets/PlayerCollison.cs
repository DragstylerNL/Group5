using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Obstruction")
        {
            Debug.Log("Life lost");
        }
    }
}
