using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollision : MonoBehaviour
{
    [SerializeField] AudioSource portalColl;
    [SerializeField] int x;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (portalColl != null)
        {
            portalColl.Play(); //?
            DontDestroyOnLoad(portalColl);
            Destroy(gameObject);
        }

        SceneManager.LoadScene(x);
    }
}
