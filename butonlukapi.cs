using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butonlukapi : MonoBehaviour
{
    public float hiz; // kapının kapanma hızı
    public GameObject kapi; // kapı objesi
    Vector2 yon; // kapının kapanacağı yön
    bool basti; // sadece 1 kere basmak için bool
    private void Start()
    {
        yon = new Vector2(0, -0.01f); // y ekseninde gideceği yön, -0.01f aşağı, 0.01f yukarı doğru gider.
    }
    private void Update()
    {
        if (basti == true && kapi != null) KapiyiAc(); // bastıysa ve kapı objesi yok edilmediyse yavaşça kapıyı açmaya devam eder
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // butona bastığında butonun yeri ve renginin değişmesi; tek seferlik basma
        if (basti == false)
        {
            basti = true;
            Vector3 basilanPos = new Vector2(0, -0.1f);
            transform.position += basilanPos;
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
    // tek yönden küçültmek/büyültmek için formül
    void Resize(float hiz, Vector3 yon)
    {
        kapi.transform.position += hiz * yon / 2;
        kapi.transform.localScale += hiz * yon;
    }
    // kapıyı hıza ve yöne göre boyutlandırma ve 0'dan küçük olduğunda kapıyı yok etme
    void KapiyiAc()
    {
        Resize(hiz, yon);
        if (kapi.transform.localScale.y <= 0) Destroy(kapi);
    }
}
