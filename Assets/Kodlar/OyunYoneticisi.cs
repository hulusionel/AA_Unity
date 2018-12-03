using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunYoneticisi : MonoBehaviour {

    GameObject AnaCember;
    GameObject DonenCember;
    public Animator animator;
    public Text DonenCemberLevel;
    public Text bir;
    public Text iki;
    public Text uc;
    public int KucukCemberSayisi;
    bool kontrol = true;

	void Start ()
    {
        PlayerPrefs.SetInt("level", int.Parse(SceneManager.GetActiveScene().name));
        //kayıtlı leveli alır, istenilen yerden çağırılabilir 
        //geçilen sahne telefon hafızasında kayıtlı kalır
        AnaCember = GameObject.FindGameObjectWithTag("anacembertag");
        DonenCember = GameObject.FindGameObjectWithTag("donencembertag");
        DonenCemberLevel.text=SceneManager.GetActiveScene().name;

        if (KucukCemberSayisi < 2)
        {
            bir.text = KucukCemberSayisi + "";
        }
        else if (KucukCemberSayisi < 3)
        {
            bir.text = KucukCemberSayisi + "";
            iki.text = (KucukCemberSayisi-1) + "";
        }
        else
        {
            bir.text = KucukCemberSayisi + "";
            iki.text = (KucukCemberSayisi - 1) + "";
            uc.text = (KucukCemberSayisi - 2) + "";
        }
    }

    public void KucukCemberText()
    {
        KucukCemberSayisi--;
        if (KucukCemberSayisi < 2)
        {
            bir.text = KucukCemberSayisi + "";
            iki.text = "";
            uc.text = "";
        }
        else if (KucukCemberSayisi < 3)
        {
            bir.text = KucukCemberSayisi + "";
            iki.text = (KucukCemberSayisi - 1) + "";
            uc.text = "";
        }
        else
        {
            bir.text = KucukCemberSayisi + "";
            iki.text = (KucukCemberSayisi - 1) + "";
            uc.text = (KucukCemberSayisi - 2) + "";
        }
        if (KucukCemberSayisi == 0)
        {
            
            StartCoroutine(YeniLevel());
        }
    }
    IEnumerator YeniLevel()
    {
        DonenCember.GetComponent<Dondurme>().enabled = false;
        AnaCember.GetComponent<AnaCember>().enabled = false;
        yield return new WaitForSeconds(0.3f);

        if (kontrol)
        {
            animator.SetTrigger("yenilevel");
            yield return new WaitForSeconds(1.5f);
            if(int.Parse(SceneManager.GetActiveScene().name)==3)
            {
                SceneManager.LoadScene("AnaMenu");
            }
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
    }

    public void OyunBitti()
    {
        StartCoroutine(Cagrilan());
    }

    IEnumerator Cagrilan()
    {

        DonenCember.GetComponent<Dondurme>().enabled = false;
        AnaCember.GetComponent<AnaCember>().enabled = false;
        //unity de eklediğimiz script kodlarını kod ile kapattık
        animator.SetTrigger("oyunbitti");
        kontrol = false; 
        yield return new WaitForSeconds(2);
        
        SceneManager.LoadScene("AnaMenu");
    }
}
