using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int movementSpeed;
    public Vector3 xzMovement;
    public float moveHorizontal;
    public float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
    }

    void GetMovementInput()
    {
        if(Input.GetKey("up"))
        {
            Debug.Log("W");
        }
        if (Input.GetKey("a"))
        {
            Debug.Log("a");
        }
        if (Input.GetKey("s"))
        {
            Debug.Log("s");
        }
        if (Input.GetKey("d"))
        {
            Debug.Log("d");
        }
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 xzMovement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.position += xzMovement * Time.deltaTime * movementSpeed;
    }

}
