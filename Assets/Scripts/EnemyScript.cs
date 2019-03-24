using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rigidbody2D;

    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    public GameObject explode;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoot());
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(0f, -speed);
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(Random.RandomRange(1f, 3f));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(shoot());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        if (tag == "Bullet")
        {
            Debug.Log("shit 1");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(explode, transform.position, Quaternion.identity);
        }
    }
}
