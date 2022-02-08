using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 2;
    public Image uiPlayer;
    public string playerName;

    [Header("Key Setup")]
    public KeyCode keyCodeUp = KeyCode.W;
    public KeyCode keyCodeDown = KeyCode.S;
    public Rigidbody2D myRigidbody2d;

    [Header("Points")]
    public int maxPoints = 2;
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;



    private void Awake()
    {
        currentPoints = 0;
        UpdateUI();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyCodeUp))
        {
            myRigidbody2d.MovePosition(transform.position + transform.up * speed);        
        }
        if (Input.GetKey(keyCodeDown))
        {
            myRigidbody2d.MovePosition(transform.position + transform.up * -speed);        
        }

        UpdateUI();
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
    }

    public void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    public void CheckMaxPoints()
    {
        if(currentPoints >= maxPoints)
        {
            Debug.Log("Salvei" + this);
            HighscoreManager.Instance.SavePlayerWin(this);
            GameManager.Instance.GameOver();
        }
        else
        {
            StateManager.Instance.ResetPosition();
        }
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }
}
