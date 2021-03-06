﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    public GameObject enterFromTop;
    public Transform startPosition;
    public Text text1;
    public Text text2;

    public Color fadeColor1;
    public Color fadeColor2;
    public Color fadeColor3;
    public AudioClip audioClip;

    Vector3 endPosition;
    bool isFading;

    void Awake()
    {
        Screen.SetResolution(160, 144, false);
    }

    // Use this for initialization
    void Start ()
    {
        endPosition = enterFromTop.transform.position;
        
    }
    
    // Update is called once per frame
    void Update ()
    {
        enterFromTop.transform.position = Vector3.Lerp(startPosition.position, endPosition, Time.timeSinceLevelLoad / 3f);

        if (Time.timeSinceLevelLoad>=3 && !isFading)
        {
            SfxManager.sfxManager.PlayClip(audioClip);
            isFading = true;
            StartCoroutine(FadeCo());
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Screen.SetResolution(Screen.width + 160, Screen.height + 144, false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Screen.SetResolution(Screen.width - 160, Screen.height - 144, false);
        }
    }

    IEnumerator FadeCo()
    {
        yield return new WaitForSeconds(1f);
        text1.color = fadeColor1;
        text2.color = fadeColor1;
        yield return new WaitForSeconds(0.1f);
        text1.color = fadeColor2;
        text2.color = fadeColor2;
        yield return new WaitForSeconds(0.1f);
        text1.color = fadeColor3;
        text2.color = fadeColor3;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }
}
