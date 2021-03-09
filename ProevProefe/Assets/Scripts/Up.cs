using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    Rigidbody RB;

    [SerializeField]
    private PlayerController PC;
    [SerializeField]
    private int wait = 1;

    // Start is called before the first frame update
    void Start()
    {
        PC.OnSwipeUp += doJump;
        RB = GetComponent<Rigidbody>();
    }

    public void doJump()
    {
        StartCoroutine(Jump());
    }

    IEnumerator Jump()
    {

        RB.constraints = RigidbodyConstraints.FreezePositionY;
        RB.detectCollisions = false;

        yield return new WaitForSeconds(wait);

        RB.constraints = RigidbodyConstraints.None;
        RB.detectCollisions = true;

        Debug.Log("gesuas");

        //ResetInput();
    }
}
