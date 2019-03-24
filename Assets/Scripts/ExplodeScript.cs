using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destyoy());
    }

    // Update is called once per frame
    IEnumerator destyoy()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
