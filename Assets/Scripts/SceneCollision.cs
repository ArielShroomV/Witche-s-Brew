using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollision : MonoBehaviour
{
    [SerializeField] AudioSource portalColl;
    [SerializeField] GameObject portal;
    [SerializeField] int x;
    private void OnTriggerEnter2D(Collider2D other)
    {
      if  (portalColl != null)
        {
            portalColl.Play(); // not playing sound!
            DontDestroyOnLoad(portalColl);
            portal.SetActive(false);
        }
        
        SceneManager.LoadScene(x);
    }
}
