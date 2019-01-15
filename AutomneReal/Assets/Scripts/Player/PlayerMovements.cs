using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Rigidbody2D playerRigidbody2D;
    [SerializeField] GameObject playerSprite;
    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] AudioClip footstep1;
    [SerializeField] AudioClip footstep2;
    [SerializeField] GameObject HaxeHitbox;
    [SerializeField] Inventory inventory;
    [SerializeField] SpriteRenderer redSquareHit;

    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] Sprite LookingDown;
    [SerializeField] Sprite LookingUp;
    [SerializeField] Sprite LookingLeft;
    [SerializeField] Sprite LookingRight;

    Color actualColor;
    bool canTakeDamages = true;

    GameObject haxeHitboxIn;
    Vector3 haxeHitboxAngle;
    bool canHaxe = true;
    bool canFootsteps = false;
    [HideInInspector] public bool mapMoving = false;

    float maximumPitch = 0.5f;
    float minimumPitch = -0.5f;
    float pitch;
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
        if (!mapMoving)
        {
            playerRigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                /*if (!canFootsteps)
                {
                    canFootsteps = true;
                    StartCoroutine("footsteps");
                }
                */
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
                        playerSpriteRenderer.sprite = LookingDown;
                        break;
                    case PlayerLooking.LEFT:
                        playerSpriteRenderer.sprite = LookingLeft;
                        break;
                    case PlayerLooking.UP:
                        playerSpriteRenderer.sprite = LookingUp;
                        break;
                    case PlayerLooking.RIGHT:
                        playerSpriteRenderer.sprite = LookingRight;
                        break;
                }
            }
            /*
            else if (canFootsteps)
            {

                canFootsteps = false;
            }*/
        }
        else
        {
            playerRigidbody2D.velocity = new Vector2(0, 0);
        }

        if (Input.GetButton("Haxe") && canHaxe)
        {
            canHaxe = false;
            switch (playerLooking)
            {
                case PlayerLooking.DOWN:
                    haxeHitboxAngle = new Vector3(0, 0, 180);
                    break;
                case PlayerLooking.LEFT:
                    haxeHitboxAngle = new Vector3(0, 0, 90);
                    break;
                case PlayerLooking.UP:
                    haxeHitboxAngle = new Vector3(0, 0, 0);
                    break;
                case PlayerLooking.RIGHT:
                    haxeHitboxAngle = new Vector3(0, 0, 270);
                    break;

            }
            haxeHitboxIn = Instantiate(HaxeHitbox, gameObject.transform.localPosition, Quaternion.Euler(haxeHitboxAngle));
            haxeHitboxIn.transform.parent = gameObject.transform;
            StartCoroutine("haxe");
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "LittleEnemy" && canTakeDamages)
        {
            Debug.Log("lol");
            StartCoroutine("takeLittleDamage");
        }
    }

    IEnumerator takeLittleDamage()
    {
        
            actualColor = redSquareHit.color;
            redSquareHit.color = new Color(actualColor.r, actualColor.g, actualColor.b, (actualColor.a * 255 + 50f) / 255f);
            canTakeDamages = false;
            yield return new WaitForSeconds(3f);
            canTakeDamages = true;
            yield return new WaitForSeconds(2f);
            for (int i=1; redSquareHit.color.a > 0; i++)
            {
                if (canTakeDamages && redSquareHit.color.a *255 < 200)
                {
                    redSquareHit.color = new Color(redSquareHit.color.r, redSquareHit.color.g, redSquareHit.color.b, redSquareHit.color.a - 1 / 255f);
                    yield return new WaitForSeconds(0.1f);
                }
                else if (!canTakeDamages && redSquareHit.color.a * 255 < 200)
                {
                yield return null;
            }
                else
                {
                    SceneManager.LoadScene("Menu");
                yield return null;
            }
            

        }
        yield return null;

    }
        
    
    IEnumerator haxe()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(haxeHitboxIn);
        yield return new WaitForSeconds(0.95f);
        canHaxe = true;
    }

    IEnumerator footsteps()
    {
        while (canFootsteps)
        {
            Debug.Log("test");
            pitch = Random.Range(minimumPitch, maximumPitch);
            audioSource1.clip = footstep1;
            audioSource1.pitch = pitch;
            audioSource1.Play();
            yield return new WaitForSeconds(0.2f);
            pitch = Random.Range(minimumPitch, maximumPitch);
            audioSource2.clip = footstep1;
            audioSource1.pitch = pitch;
            audioSource2.Play();
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void IncreaseWood()
    {
        inventory.wood += 1;
    }

    public void IncreaseMushrooms()
    {
        inventory.mushrooms += 1;
    }

    public void  IncreaseTears()
    {
        inventory.tears += 1;
    }
}
