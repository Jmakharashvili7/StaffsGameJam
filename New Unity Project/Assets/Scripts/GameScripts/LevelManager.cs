using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject credits;
    public void LoadScene(string name)
    {
        if (name == "Quit")
        {
            Application.Quit();
            return;
        }

        if(name=="CreditsOn")
        {
            credits.SetActive(true);
            return;
        }
        if(name=="CreditsOff")
        {
            credits.SetActive(false);
            return;
        }

        SceneManager.LoadScene(name);
    }
}
