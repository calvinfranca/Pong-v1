using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Vector2 speedDirection;
    public float speed = 9f;
    public int randomStart;
    public string tagToCheck = "Player";
    private Vector3 _startingPosition;
    private bool _canMove = false;
    private Rigidbody2D ballRigidbody;

    // Start is called before the first frame update
    private void Awake()
    {
        _startingPosition = transform.position;

        RandomBall();
        ballRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_canMove) return;

        ballRigidbody.MovePosition((Vector2)transform.position + speedDirection * speed);
        //transform.Translate(speedDirection * speed);


        //Debug.Log(speedDirection);
        Debug.Log(speed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == tagToCheck)
        {
            speedDirection.x *= -1;
            speed += 0.5f;
        }
        else
        {
            speedDirection.y *= -1;
        }
    }

    public void RandomBall()
    {
        randomStart = Random.Range(1, 5);

        if (randomStart == 1)
        {
            speedDirection = new Vector2(1, 1);
        }
        else if (randomStart == 2)
        {
            speedDirection = new Vector2(1, -1);
        }
        else if (randomStart == 3)
        {
            speedDirection = new Vector2(-1, 1);
        }
        else if (randomStart == 4)
        {
            speedDirection = new Vector2(-1, -1);
        }


    }

    public void ResetBall()
    {
        transform.position = _startingPosition;
        speed = 9f;
        RandomBall();
        
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }

}
