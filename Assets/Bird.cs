
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Bird : MonoBehaviour
{
    public int score = 0;
    public static bool gameRunning;

    public GameObject title;
    public GameObject Gameover;
    public Canvas canves;

    public GameObject pipePair3, pipePair1, pipePair2;

    public UnityEngine.UI.Text scoretext;

    private Rigidbody2D rb;

    private void Start()
    {
        score = 0;
        gameRunning = false;

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        title.transform.localScale = new Vector2(0.44846f, 0.44846f);
        Gameover.transform.localScale = Vector2.zero;
        canves.enabled = false;
    }

    void Update()
    {
        // PC + Mobile
        if (IsInputPressed())
        {
            if (gameRunning == false)
            {
                gameRunning = true;
                rb.gravityScale = 1;

                title.transform.localScale = Vector2.zero;
            }

            rb.AddForceY(200);
        }
    }

    // =========================
    // PC + Mobile Input
    // =========================
    bool IsInputPressed()
    {
        // PC - Mouse
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            return true;
        }

        // Mobile - Touch
        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("pipePair1") ||
            collision.collider.CompareTag("floor"))
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        gameRunning = false;

        rb.gravityScale = 0;

        Gameover.transform.localScale =
            new Vector2(0.44846f, 0.44846f);

        canves.enabled = true;
    }

    public void Restart()
    {
        score = 0;

        Time.timeScale = 1;

        transform.position = new Vector2(-0.25f, 1.1f);

        pipePair3.transform.position =
            new Vector2(7.5f, 0);

        pipePair1.transform.position =
            new Vector2(11f, 0);

        pipePair2.transform.position =
            new Vector2(14.5f, 0);

        gameRunning = false;

        rb.gravityScale = 1;

        title.transform.localScale =
            new Vector2(0.44846f, 0.44846f);

        Gameover.transform.localScale = Vector2.zero;

        canves.enabled = false;

        scoretext.text = "score:0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;

        scoretext.text = "score:" + score;
    }
}
