using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    public Text text;
    public CharacterStat characterStat;

    private void Start()
    {
        text = GetComponent<Text>();
        StartBlinking();
    }

    void Update()
    {
        if(GameObject.FindWithTag("Player") != null)
        {
            characterStat = GameObject.FindWithTag("Player").GetComponent<CharacterStat>();

        }

        if (Input.GetMouseButtonDown(0))
        {
            if(SceneManager.GetActiveScene().name == "IntroScene")
            {
                SceneManager.LoadScene("DirectionScene");

            }
            if(SceneManager.GetActiveScene().name == "DirectionScene")
            {
                SceneManager.LoadScene("SpringWorld");
                ResetGame();


            }
            if (SceneManager.GetActiveScene().name == "DeathScene")
            {
                SceneManager.LoadScene("IntroScene");
                ResetGame();
            }
        }
    }
    IEnumerator Blink()
    {
        while (true)
        {
            switch (text.color.a.ToString())
            {
                case "0":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }

    public void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    public void StopBlinking()
    {
        StopCoroutine("Blink");
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }

    void ResetGame()
    {
        characterStat.Reset();
    }

    
}
