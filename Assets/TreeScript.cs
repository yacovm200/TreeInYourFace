using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TreeScript : MonoBehaviour
{
    public float speed = 5.0f;
    public float rand = 0;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        SetPosition();
    }

    private void Update()
    {
        if (transform.position.x < -13) {
            speed++;
            rb.velocity = new Vector2((Random.Range(-speed, -speed-3) ), 0);
            SetPosition();  
        }
    }
    void OnCollisionEnter2D(Collision2D Collider)
    {

        if (Collider.gameObject.tag.Equals("bird"))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            rb.velocity = new Vector2(0, 0);
            Invoke("Kill", 1f);
        }

    }
    void Kill()
    {
        Instantiate(gameObject);
        Destroy(gameObject);
    }

    void SetPosition()
    {
        transform.position = new Vector3(Random.Range(20, 35), Random.Range(-2, 3), 0);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3f, 3f), transform.position.z);

    }
}
