using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;

    [SerializeField] float moveSpeed;
    float horizontalInput, verticalInput;

    int score= 0;
    [SerializeField] int winCondition = 5;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI loseText;
    [SerializeField] GameObject restartButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        horizontalInput = joystick.Horizontal * moveSpeed;
        verticalInput = joystick.Vertical * moveSpeed;

        transform.Translate(horizontalInput, verticalInput, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Candy")
        {
            score++;
            Destroy(collision.gameObject);
            if (score >= winCondition)
            {
                
                Time.timeScale = 0f;
                winText.gameObject.SetActive(true);
                restartButton.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        loseText.gameObject.SetActive(true);
        restartButton.SetActive(true);

    }
}
