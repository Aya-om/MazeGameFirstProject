using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    public Text scoreText;
    public Text winText;
    private int score;

    private string TAG_NAME1 = "Sweet";
    private string TAG_NAME2 = "Pepper";

    public GameOverScreen GameOverScreen;
    public WinScript WinScript;


    private bool isGameOver = false;
    public void GameOver()
    {
        GameOverScreen.Setup(score);
        isGameOver = true;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setTextScore();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (isGameOver == false)
        {
            rb.AddForce(new Vector3(h, 0, v) * speed * Time.deltaTime, ForceMode.Impulse);
        }
        
       // transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        string s;
        s= collision.collider.name;
        if (s.Remove(3) == "Swe")
        {
            Destroy(collision.gameObject);
            score++;
            setTextScore();
        }
        if (s.Remove(3) == "Pep" && score>0)
        {
            Destroy(collision.gameObject);
            //setTextScore();
            GameOver();
        }
        if (s.Remove(3) == "Pin")
        {
            Destroy(collision.gameObject);
            WinScript.ShowWin();
            isGameOver = true;

            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_NAME1))
        {
            Destroy(other.gameObject);
            score++;
            setTextScore();
        }
        if (other.CompareTag(TAG_NAME2) && score > 0)
        {
            Destroy(other.gameObject);
            //setTextScore();
            GameOver();
        }
        if (other.CompareTag("Pin"))
        {
            Destroy(other.gameObject);
            WinScript.ShowWin();
            isGameOver = true;


        }
    }
    private void setTextScore()
    {
        scoreText.text = "Score :" + score;
    }
}
