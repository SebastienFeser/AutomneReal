using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Rigidbody2D playerRigidbody2D;
    [SerializeField] GameObject playerSprite;
    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] AudioClip footstep1;
    [SerializeField] AudioClip footstep2;
    public bool mapMoving = false;
    enum PlayerLooking
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }

    PlayerLooking playerLooking;
    // Start is called before the first frame update
    void Start()
    {
        playerLooking = PlayerLooking.DOWN;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mapMoving);
        if (!mapMoving)
        {
            playerRigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                    playerLooking = PlayerLooking.RIGHT;

                if (Input.GetAxisRaw("Horizontal") < 0)
                    playerLooking = PlayerLooking.LEFT;

                if (Input.GetAxisRaw("Vertical") > 0)
                    playerLooking = PlayerLooking.UP;

                if (Input.GetAxisRaw("Vertical") < 0)
                    playerLooking = PlayerLooking.DOWN;

                switch (playerLooking)
                {
                    case PlayerLooking.DOWN:
                        playerSprite.transform.eulerAngles = new Vector3(0, 0, 180);
                        break;
                    case PlayerLooking.LEFT:
                        playerSprite.transform.eulerAngles = new Vector3(0, 0, 90);
                        break;
                    case PlayerLooking.UP:
                        playerSprite.transform.eulerAngles = new Vector3(0, 0, 0);
                        break;
                    case PlayerLooking.RIGHT:
                        playerSprite.transform.eulerAngles = new Vector3(0, 0, 270);
                        break;
                }
            }
        }
        else
        {
            playerRigidbody2D.velocity = new Vector2(0, 0);
        }

    }

    IEnumerator footsteps()
    {

        audioSource1.clip = footstep1;
        yield return new WaitForSeconds(0.5f);
        audioSource2.clip = footstep2;
        yield return new WaitForSeconds(0.5f);
    }

}
