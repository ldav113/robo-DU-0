using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("Level0Test");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit ();
    }
}
