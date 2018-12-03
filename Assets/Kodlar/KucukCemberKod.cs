using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukCemberKod : MonoBehaviour {

    Rigidbody2D fizik;
    public float hiz;
    bool hareketKontrol = false;
    GameObject oyunYoneticisi;
    void Start ()
    {
        fizik = GetComponent<Rigidbody2D>();
        oyunYoneticisi = GameObject.FindGameObjectWithTag("oyunyoneticisitag");
	}
	
	
	void FixedUpdate ()
    {
        if(!hareketKontrol)
        {
            fizik.MovePosition(fizik.position + Vector2.up * hiz * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="donencembertag")
        {
            transform.SetParent(collision.transform);
            hareketKontrol = true;
        }
        if (collision.tag=="kucukcemberprefabtag")
        {
            oyunYoneticisi.GetComponent<OyunYoneticisi>().OyunBitti();
        }
    }
}
