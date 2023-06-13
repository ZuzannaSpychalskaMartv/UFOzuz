using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Text scoreText;
    public Text winText;
    Rigidbody2D rb2d;
    private int count = 0;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * 15);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            count++;
            Destroy(collision.gameObject);
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Wynik: " + count;
        if (count == 3)
        {
            winText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);

        }
    
    }

}
