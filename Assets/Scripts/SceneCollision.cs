using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollision : MonoBehaviour
{
    [SerializeField] AudioSource portalColl;
    private void OnTriggerEnter2D(Collider2D other)
    {
        portalColl.Play(); ;
        DontDestroyOnLoad(portalColl);
        SceneManager.LoadScene("Level two");
    }
}
