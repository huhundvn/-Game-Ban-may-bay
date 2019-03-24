using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    private BoxCollider2D boxCollider2D;

    private float maxX, minX;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        maxX = boxCollider2D.bounds.size.x / 2f;
        minX = -boxCollider2D.bounds.size.x / 2f;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(Random.RandomRange(1.0f, 3.0f));
        Vector3 temp = transform.position;
        temp.x = Random.RandomRange(minX, maxX);
        Instantiate(enemy, temp, Quaternion.identity);
        StartCoroutine(spawn());
    }
}
