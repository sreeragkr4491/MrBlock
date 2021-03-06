using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;

    public GameObject gameWonPanel;
    private bool isGameWon = false;

    public GameObject gameLostPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameWon)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                rb.velocity = new Vector2(speed, 0f);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                rb.velocity = new Vector2(-speed, 0f);
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                rb.velocity = new Vector2(0f, speed);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                rb.velocity = new Vector2(0f, -speed);
            }
            else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                rb.velocity = new Vector2(0f, 0f);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "WinDoor")
        {
            gameWonPanel.SetActive(true);
            Debug.Log("Level Complete !!!");
            isGameWon = true;
        }
        else if (collision.tag == "Wall")
        {
            gameLostPanel.SetActive(true);
            Debug.Log("Level Lost !!!");
            isGameWon = true;
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
