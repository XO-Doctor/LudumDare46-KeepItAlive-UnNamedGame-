using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class totorialScrolling : MonoBehaviour
{
    public int active;
    public GameObject textholder;
    public bool tutorial;

    private void Start()
    {
        if (tutorial)
        {
            active = 0;
            for (int i = 0; i < textholder.transform.childCount; i++)
            {
                if (i == active)
                {
                    textholder.transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    textholder.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }

    public void next()
    {
        active++;
        for (int i = 0; i < textholder.transform.childCount; i++)
        {
            if(i == active)
            {
                textholder.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                textholder.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void back()
    {
        active--;
        for (int i = 0; i < textholder.transform.childCount; i++)
        {
            if (i == active)
            {
                textholder.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                textholder.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
