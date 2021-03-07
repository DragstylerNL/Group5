using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPool : MonoBehaviour
{
    public List<GameObject> blockList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> activeBlockList = new List<GameObject>();
    [SerializeField]
    private int offset = 0;
    public int minimalThreshhold = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activeBlockList[0].transform.position.z < minimalThreshhold && activeBlockList.Count != 0)
        {
            
            PlaceRandomBlock();
            DeactivateBlock();
            
        }
    }
    public void PlaceRandomBlock()
    {

        int objectnumber = (int) Mathf.Floor(Random.Range(0,blockList.Count));
        
        if (blockList[objectnumber].activeSelf != true)
        {
            
            blockList[objectnumber].transform.position = activeBlockList[activeBlockList.Count - 1].transform.position + new Vector3(0,0,offset);
            blockList[objectnumber].SetActive(true);
            activeBlockList.Add(blockList[objectnumber]);
        }
        else
        {
            PlaceRandomBlock();
            return;
        }


    }
    public void DeactivateBlock()
    {
        
            activeBlockList[0].SetActive(false);
            activeBlockList.Remove(activeBlockList[0]);
        
    }
}
