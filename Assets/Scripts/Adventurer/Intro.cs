using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public float WaktuTunggu;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TungguIntro());
    }


    IEnumerator TungguIntro()
    { 
        yield return new WaitForSeconds(WaktuTunggu);
        SceneManager.LoadScene(1);
    }
}
