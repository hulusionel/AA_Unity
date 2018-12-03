using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dondurme : MonoBehaviour {

    public float hiz;
	void Update ()
    {
        if (int.Parse(SceneManager.GetActiveScene().name) == 3)
        {
            transform.Rotate(0, 0,(-hiz * Time.deltaTime));
        }
        else
        transform.Rotate(0, 0, hiz * Time.deltaTime);
	}
}
