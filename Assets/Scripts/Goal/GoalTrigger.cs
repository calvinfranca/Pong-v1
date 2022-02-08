using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public Player player;
    public string tagToCheck = "Ball";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagToCheck)
        {
            CountPoint();
        }
        
    }

    private void CountPoint()
    {
        player.AddPoint();
        /*if(player.currentPoints< player.maxPoints)
        {
            StateManager.Instance.ResetPosition();
        }
        else
        {

            GameManager.Instance.GameOver();
        }*/
    }
}
