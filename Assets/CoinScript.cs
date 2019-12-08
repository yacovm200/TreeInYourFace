using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-6, 0);
        SetPosition();
    }

    private void Update()
    {
        if (transform.position.x < -13) { SetPosition(); }
    }
    void OnCollisionEnter2D(Collision2D Collider)
    {

        if (Collider.gameObject.tag.Equals("bird"))
        {
            Instantiate(gameObject);
            Destroy(gameObject);
        }  
    }

    void SetPosition()
    {

        transform.position = new Vector3(Random.Range(20, 40), Random.Range(-2, 3), 0);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3f, 3f), transform.position.z);

    }
}
