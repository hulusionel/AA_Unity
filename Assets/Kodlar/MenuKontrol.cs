using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    public void Oyna()
    {
        int kayit = PlayerPrefs.GetInt("level");
        if(kayit==0)
        {
            SceneManager.LoadScene(kayit+1);
        }
        else
        {
            SceneManager.LoadScene(kayit);
        }
        
    }
	public void Cik()
    {
        Application.Quit();
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
