using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void LoadScene(string level1)

    {
        SceneManager.LoadScene(level1); 
    }
}
