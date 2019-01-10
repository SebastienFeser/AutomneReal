using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChangerTrig : MonoBehaviour
{
    [SerializeField] GameObject map;
    [SerializeField] GameObject player;
    float TileSizeX = 18f;
    float TileSizeY = 10f;
    [SerializeField] float waitForSeconds;
    float playerMoveX = 0.165f;
    float playerMoveY = 0.155f;

    Vector2 startPosition;
    Vector2 endPosition;
    enum TriggerPosition
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }

    [SerializeField] TriggerPosition triggerPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCheck")
        {
            if (!player.GetComponent<PlayerMovements>().mapMoving)
            {
                switch (triggerPosition)
                {
                    case TriggerPosition.UP:
                        MoveUp();
                        break;
                    case TriggerPosition.DOWN:
                        MoveDown();
                        break;
                    case TriggerPosition.LEFT:
                        MoveLeft();
                        break;
                    case TriggerPosition.RIGHT:
                        MoveRight();
                        break;
                }
            }
        }
    }

    void MoveUp()
    {
        StartCoroutine("MoveUpCor");
    }

    void MoveDown()
    {
        StartCoroutine("MoveDownCor");
    }

    void MoveLeft()
    {
        StartCoroutine("MoveLeftCor");
    }

    void MoveRight()
    {
        StartCoroutine("MoveRightCor");
    }
  
    IEnumerator MoveUpCor()
    {
        player.GetComponent<PlayerMovements>().mapMoving = true;
        startPosition = map.transform.position;
        endPosition = new Vector2(map.transform.position.x, map.transform.position.y - TileSizeY);
        for (float i = 0; i < TileSizeY; i += 0.18f)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - playerMoveY);
            map.transform.position = new Vector2(startPosition.x, startPosition.y - i);
            yield return new WaitForSeconds(waitForSeconds);
        }
        player.GetComponent<PlayerMovements>().mapMoving = false;
        map.transform.position = endPosition;
    }

    IEnumerator MoveDownCor()
    {
        player.GetComponent<PlayerMovements>().mapMoving = true;
        startPosition = map.transform.position;
        endPosition = new Vector2(map.transform.position.x, map.transform.position.y + TileSizeY);
        for (float i = 0; i < TileSizeY; i += 0.18f)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + playerMoveY);
            map.transform.position = new Vector2(startPosition.x, startPosition.y + i);
            yield return new WaitForSeconds(waitForSeconds);
        }
        player.GetComponent<PlayerMovements>().mapMoving = false;
        map.transform.position = endPosition;
    }

    IEnumerator MoveLeftCor()
    {
        player.GetComponent<PlayerMovements>().mapMoving = true;
        startPosition = map.transform.position;
        endPosition = new Vector2(map.transform.position.x + TileSizeX, map.transform.position.y);
        for (float i = 0; i < TileSizeX; i += 0.18f)
        {
            player.transform.position = new Vector2(player.transform.position.x + playerMoveX, player.transform.position.y);
            map.transform.position = new Vector2(startPosition.x + i, startPosition.y);
            yield return new WaitForSeconds(waitForSeconds);
        }
        player.GetComponent<PlayerMovements>().mapMoving = false;
        map.transform.position = endPosition;
    }

    IEnumerator MoveRightCor()
    {
        player.GetComponent<PlayerMovements>().mapMoving = true;
        startPosition = map.transform.position;
        endPosition = new Vector2(map.transform.position.x - TileSizeX, map.transform.position.y);
        for (float i = 0; i < TileSizeX; i += 0.18f)
        {
            player.transform.position = new Vector2(player.transform.position.x - playerMoveX, player.transform.position.y);
            map.transform.position = new Vector2(startPosition.x - i, startPosition.y);
            yield return new WaitForSeconds(waitForSeconds);
        }
        player.GetComponent<PlayerMovements>().mapMoving = false;
        map.transform.position = endPosition;
    }
}
