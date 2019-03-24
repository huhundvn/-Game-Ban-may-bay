using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyScript : MonoBehaviour
{

    public float speed;
    [SerializeField]
    public GameObject explode;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroy());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(0f, -speed);
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Instantiate(explode, transform.position, Quaternion.identity);
    }
}
