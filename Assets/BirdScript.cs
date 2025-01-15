using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D bird;
    public float flapStrength;
    public Logic logic;
    
    public bool birdIsAlive = true;
    public float deathBackFling = -25;
    public float deathDownFling = -25;
    public float deathRotate = -25;
    public Sprite flapUp;
    public Sprite flapDown;
    public SpriteRenderer birdRend;
    public float delayTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            bird.velocity = Vector2.up * flapStrength;
            birdRend.sprite = flapDown;
            StartCoroutine(ChangeSpriteAfterDelay());
        }

        if (transform.position.y < -35 || transform.position.y > 35)
        {
            birdIsAlive = false;
            logic.gameOver();
        }
    }

    IEnumerator ChangeSpriteAfterDelay()
    {
        Debug.Log("Coroutine started");
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Change the sprite back to flapUp
        birdRend.sprite = flapUp;
        Debug.Log("Sprite changed back to flapUp");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsAlive = false;
        gameObject.layer = LayerMask.NameToLayer("dead");
        bird.velocity = new Vector2(deathBackFling, deathDownFling);
        bird.angularVelocity = deathRotate;
        logic.gameOver();
    }
}
