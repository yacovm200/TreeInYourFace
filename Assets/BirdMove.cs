using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdMove : MonoBehaviour
{
    public float speed = 10f;
    public int LifeOfBird;
    public int score;
    public Animator animator;
    public GameObject BlowBox;
    bool NotDead = true;

    public Text scoreText;
    public Text LifeText;
    public Text Gameover;

    private void Start()
    {
        score = 0;
        LifeOfBird = 3;
        

    }
    // Update is called once per frame
    void Update()
    {
        
        PlayerMovement();
        WriteScoreOnScreen();
        CheckIfGameOver();
        WriteLifeOcScreen();
    }

    public void WriteLifeOcScreen()
    {
        if(LifeText != null)
        {
            LifeText.text = "Life: " + LifeOfBird.ToString();
        }
    }
    public void CheckIfGameOver()
    {
        if (Gameover != null)
        {
            if (LifeOfBird == 0)
            {
                Gameover.text = " Game over !";
                Application.Quit();
            }
        }
    }
    public void WriteScoreOnScreen()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }

    }
    void PlayerMovement()
    {
        if (LifeOfBird > 0 && NotDead)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= transform.up * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }

            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -2.8f, 2.8f), transform.position.z);
        }

          
    }
    void hitIsDone()
    {
        animator.SetBool("isHit", false);
        BlowBoxBoom box = BlowBox.GetComponent<BlowBoxBoom>();
        box.hitIsDone();
        NotDead = true;
    }
    void MoveBirdBack()
    {
        transform.position = new Vector3(-9, 0, 0); //set initiale position of player after he warm from tree,its apear each strike 
    }
    void OnCollisionEnter2D(Collision2D Collider)
    {
        
        if (Collider.gameObject.tag.Equals("tree"))
        {
            NotDead = false;
            BlowBoxBoom box = BlowBox.GetComponent<BlowBoxBoom>();
            box.hit();
            animator.SetBool("isHit", true);
            Invoke("hitIsDone", 1f);
            LifeOfBird--;
            print("Life is: " + LifeOfBird + "coins is: " + score);
            Invoke("MoveBirdBack", 1f);

        }

        if (Collider.gameObject.tag.Equals("heal") && LifeOfBird!=3)
        {
            LifeOfBird++;
            print("Life is: " + LifeOfBird + "coins is: " + score);
        }
        if (Collider.gameObject.tag.Equals("coin"))
        {
            score++;
            print("Life is: " + LifeOfBird + "coins is: " + score);
        }
    }

}
