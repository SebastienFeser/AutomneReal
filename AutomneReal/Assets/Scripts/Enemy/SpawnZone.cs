using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnPosition;
    GameObject actualEnemy;
    PlayerMovements playerMovements;
    bool checkIfDestroyed = false;
    bool respawn = true;
    bool destroying = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfDestroyed && actualEnemy == null)
        {
            respawn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCheck" && respawn && !destroying)
        {
            if (playerMovements == null)
            {
                playerMovements = collision.GetComponentInParent<PlayerMovements>();
            }
            StartCoroutine("instantiateEnemy");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCheck")
        {
            StartCoroutine("destroyEnemy");
        }
    }

    IEnumerator instantiateEnemy()
    {
        while (playerMovements.mapMoving == true)
        {
            yield return new WaitForSeconds(0.01f);
        }
        actualEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        checkIfDestroyed = true;
        yield return null;
    }

    IEnumerator destroyEnemy()
    {
        destroying = true;
        checkIfDestroyed = false;
        Destroy(actualEnemy);
        yield return new WaitForSeconds(1f);
        destroying = false;
    }

   
}
