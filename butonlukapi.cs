using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butonlukapi : MonoBehaviour
{
    public float hiz;
    public GameObject kapi;
    Vector2 yon;
    bool basti;
    private void Start()
    {
        yon = new Vector2(0, -0.01f);
    }
    private void Update()
    {
        if (basti == true && kapi != null) KapiyiAc();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (basti == false)
        {
            basti = true;
            Vector3 basilanPos = new Vector2(0, -0.1f);
            transform.position += basilanPos;
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    void Resize(float hiz, Vector3 yon)
    {
        kapi.transform.position += hiz * yon / 2;
        kapi.transform.localScale += hiz * yon;
    }

    void KapiyiAc()
    {
        Resize(hiz, yon);
        if (kapi.transform.localScale.y <= 0) Destroy(kapi);
    }
}
