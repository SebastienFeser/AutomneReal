using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTears : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovements>().IncreaseTears();
            Destroy(gameObject);
        }
    }
}
