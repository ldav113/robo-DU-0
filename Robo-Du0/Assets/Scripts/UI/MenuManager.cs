using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("LevelTest");
    }

    public void QuitGame()
    {
        Application.Quit ();
    }
}
