using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float enemySpeed = 3f;
    [SerializeField] Rigidbody2D enemyRigidBody;
    [SerializeField] Enemy1 enemy1Script;
    [SerializeField] Animation enemyAnimation;
    [SerializeField] Animator animationNormal;
    [SerializeField] Animator running;
    [SerializeField] GameObject Tears;

    GameObject map;

    PlayerMovements playerMovements;
    float xDistance;
    float yDistance;
    float angle1;
    float angle2;
    float ySpeed = 0;
    float xSpeed = 0;
    bool normalMove = true;
    int count = 0;
    bool getplayer = false;
    bool canMove = false;
    

    private void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map");
    }

    private void Update()
    {
        if (enemy1Script.backup == true)
        {
            StartCoroutine("backup");
            enemy1Script.backup = false;
        }
        if (playerMovements != null)
        {
            if (playerMovements.mapMoving == true)
            {
                canMove = false;
                enemyRigidBody.velocity = new Vector2(0, 0);
            }
            else
            {
                canMove = true;
            }
        }
        if (xSpeed >= 0)
        {
            enemy.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            enemy.transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCheck" && normalMove)
        {
            if (!getplayer)
            {
                playerMovements = collision.GetComponentInParent<PlayerMovements>();
                getplayer = true;
            }
            
            xDistance = collision.transform.position.x - enemy.transform.position.x;
            yDistance = collision.transform.position.y - enemy.transform.position.y;
            angle1 = Mathf.Atan2(yDistance, xDistance);
            angle2 = Mathf.Atan2(xDistance, yDistance);
            ySpeed = Mathf.Cos(angle2) * enemySpeed;
            xSpeed = Mathf.Cos(angle1) * enemySpeed;

            if ((xDistance > 0.1f || xDistance < -0.1f || yDistance > 0.1f || yDistance < -0.1f) && canMove)
                enemyRigidBody.velocity = new Vector2(xSpeed, ySpeed);
            else
                enemyRigidBody.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCheck")
        {
           enemyRigidBody.velocity = new Vector2(0, 0);
        }
    }
    IEnumerator backup()
    {
        count += 1;
        normalMove = false;
        enemyRigidBody.velocity = new Vector2(-xSpeed, -ySpeed);
        yield return new WaitForSeconds(0.3f);
        normalMove = true;
        if (count >= 3)
        {
            Instantiate(Tears, new Vector2(enemy.transform.position.x, enemy.transform.position.y), Quaternion.identity, map.transform);
            Destroy(enemy);
        }

    }
}
