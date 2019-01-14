using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] Collider2D enemyTrigger;
    [SerializeField] Collider2D enemyDetectionZone;
    [SerializeField] Collider2D spawnZone;
    [SerializeField] GameObject enemy;
    [HideInInspector] public bool backup = false;
    void Start()
    {
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HaxeHit")
        {
            backup = true;
        }
    }
    
}
