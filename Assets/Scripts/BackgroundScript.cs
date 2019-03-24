using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float speedScrolling;

    private Material backgroundMaterial;
    private Vector2 offset = Vector2.zero;

    private void Awake()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        var heightBackground = Camera.main.orthographicSize * 2.0f;
        var widthBackground = heightBackground * Screen.width / Screen.height;
        transform.localScale = new Vector3(widthBackground, heightBackground, 0f);

        offset = backgroundMaterial.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += speedScrolling * Time.deltaTime;
        backgroundMaterial.SetTextureOffset("_MainTex", offset);
    }
}
