using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    Rigidbody RB;

    [SerializeField]
    private PlayerController PC;
    [SerializeField]
    private int wait = 2;
    [SerializeField]
    private int jumpHeight = 650;

    public bool NI = false;

    // Start is called before the first frame update
    void Start()
    {
        PC.OnSwipeUp += doJump;
        RB = GetComponent<Rigidbody>();
    }

    public void doJump()
    {
        if (NI) return;
        StartCoroutine(Jump());
        
    }

    IEnumerator Jump()
    {
        RB.velocity = new Vector3(RB.velocity.x, RB.velocity.y + jumpHeight*Time.deltaTime, RB.velocity.z);
        NI = true;

        yield return new WaitForSeconds(wait);

        NI = false;
        Debug.Log("gesuas");
    }
}
