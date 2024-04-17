using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnemyBehavior2 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public bool toAttack;
    public float attackTimer = 2.0f;
    public bool dead;
    public float dieTimer;
    public float despawnTimer = 3.0f;

    public float lerpDir = 1.0f;
    public float lerpTime = 0.0f;
    public float lerpSpeed = 0.05f;

    Vector3 startPos;
    Vector3 endPos = new Vector3(12.0f, 2.13f, -0.1f);

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        startPos = transform.position;
        dead = false;
        toAttack = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        despawnTimer = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (lerpTime >= 0.5 && spriteRenderer.enabled == false)
        {
            spriteRenderer.enabled = true;
        }
        if (despawnTimer <= 0)
        {
            Debug.Log("SAFE");

            GameData.enemyAtDoor2 = false;
            GameData.lvl2enemySpawned = false;
            Destroy(gameObject);
        }
        if (lerpTime >= 1 && !toAttack)
        {
            toAttack = true;
            Vector3 newScale = new Vector3(5f, 5f, 5f);
            transform.localScale = newScale;
        }
        if (GameData.door1Closed && !toAttack)
        {
            lerpTime += Time.deltaTime * lerpSpeed * lerpDir;
            transform.position = Vector3.Lerp(startPos, endPos, lerpTime);
        }
        else if (GameData.flashlightOn && GameData.isAtDoor1)
        {
            if (toAttack && GameData.door1Closed)
            {
                despawnTimer = despawnTimer - Time.deltaTime;
            }
        }

        else if (dead)
        {
            dieTimer = dieTimer - Time.deltaTime;
            if (dieTimer <= 0.0f)
            {
                GameData.lvl2enemySpawned = false;
                GameData.enemyAtDoor2 = false;
                Debug.Log("U ARE DEAD");
                UnityEngine.SceneManagement.SceneManager.LoadScene("DoorDeath"); // LOAD SCENE WITH JUMPSCARE
            }
        }
        else if (toAttack)
        {
            if (GameData.door1Closed)
            {
                despawnTimer = despawnTimer - Time.deltaTime;
            }
            else
            {
                attackTimer = attackTimer - Time.deltaTime;
                if (attackTimer <= 0.0f)
                {
                    dieTimer = Random.Range(1.0f, 1.5f);
                    dead = true;
                    spriteRenderer.enabled = false;

                }
            }

        }

        else
        {
            lerpTime += Time.deltaTime * lerpSpeed * lerpDir;
            transform.position = Vector3.Lerp(startPos, endPos, lerpTime);
        }



    }


}
