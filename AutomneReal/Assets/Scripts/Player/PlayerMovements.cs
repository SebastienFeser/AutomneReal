using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Rigidbody2D playerRigidbody2D;
    public bool mapMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mapMoving);
        if (!mapMoving)
        {
            playerRigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
        }
        else
        {
            playerRigidbody2D.velocity = new Vector2(0, 0);
        }

    }
}
