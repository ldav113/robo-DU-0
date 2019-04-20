using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public string SceneName;
    public void Menu() // This MUST be inserted otherwise the script doesn't work, also the name of the scene to be loaded has to be where it says NewLebel (delete NewLebel and replace it with  your scene name
    {
        Debug.Log("Level2Boss");
        SceneManager.LoadScene("Level2Boss");
    }
    void OnTriggerEnter2D(Collider2D co)
    {
        //this finds the game object called "Ball" in the scene
        if (co.name == "Player") 
            Debug.Log("Level2Boss");
        SceneManager.LoadScene(SceneName); 
    }
}
