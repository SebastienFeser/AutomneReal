using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] treeSpriteRenderer;
    [SerializeField] GameObject upTrees;
    [SerializeField] AudioSource treeAudioSource;
    [SerializeField] AudioSource treeAudioSource2;
    [SerializeField] AudioClip treeHit;
    [SerializeField] AudioClip treeFalling;
    [SerializeField] GameObject wood;
    [SerializeField] Collider2D treeCollider;
    [SerializeField] Transform tree;
    bool canHit = true;
    int hitCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HaxeHit" && canHit)
        {
            StartCoroutine("hitted");
        }
    }

    IEnumerator hitted()
    {
        treeAudioSource.clip = treeHit;
        treeAudioSource.Play();
        hitCount++;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.01f, gameObject.transform.position.y);
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.02f, gameObject.transform.position.y);
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.02f, gameObject.transform.position.y);
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.02f, gameObject.transform.position.y);
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.01f, gameObject.transform.position.y);
        if(hitCount >= 3)
        {
            canHit = false;
            StartCoroutine("treeFall");
            
        }
    }

    IEnumerator treeFall()
    {
        treeAudioSource2.clip = treeFalling;
        treeAudioSource2.Play();
        for (float i = 0; i < 100f; i+=2)
        {
            upTrees.transform.eulerAngles = new Vector3(0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.2f);
        Instantiate(wood, new Vector2(treeCollider.transform.position.x - 1, treeCollider.transform.position.y), Quaternion.identity, tree);
        for (int i = 0; i < treeSpriteRenderer.Length; i++)
        {
            Destroy(treeSpriteRenderer[i]);
        }
        yield return null;
    }
}
