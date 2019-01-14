using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour
{
    SpriteRenderer tempRend;
    [SerializeField] Collider2D position;
    float timer = 3;
    // Start is called before the first frame update
    void Start()
    {
            tempRend = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempRend != null)
        {
            tempRend.sortingOrder = (int)Camera.main.WorldToScreenPoint(position.transform.position).y * -1;

        }
    }
}
