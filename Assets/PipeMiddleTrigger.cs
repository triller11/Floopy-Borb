using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleTrigger : MonoBehaviour
{
    public bool gameOverState = false;
    public Logic logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && gameOverState == false)
        {
            logic.addScore(1);
        }
    }

    public void setGameOverState(bool state)
    {
        gameOverState = state;
    }
}
