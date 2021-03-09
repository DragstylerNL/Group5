using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockProperties : MonoBehaviour
{   
    [SerializeField]
    private List<GameObject> _ChilderenList = new List<GameObject>();
    [SerializeField]
    private float platformSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }
    public void MovePlatform()
    {
      
        if (gameObject.activeSelf == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - platformSpeed);
        }
    }

}
