using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menü : MonoBehaviour
{
    public FixedTouchField Touch;
    GameObject Tap;
    void Start()
    {
        Time.timeScale = 0f;
        Tap = GameObject.Find("Tap");
    }

    // Update is called once per frame
    void Update()
    {
        GameStart();
        
    }
    void GameStart()
    {
        if (Touch.Pressed)
        {
            gameObject.SetActive(false);
            Tap.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level");
    }
  public void Exit()
    {
        Application.Quit();
    }
}
