using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollision : MonoBehaviour
{
    [SerializeField] AudioSource portalColl;
    public static SceneCollision instanse;

    private void Awake()
    {
        if (instanse != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instanse = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public IEnumerator endcorotine()
    {

        if (portalColl != null)
        {
            portalColl.Play();
        }
        if (SceneManager.GetActiveScene().buildIndex + 1 <= 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
            SceneManager.LoadScene(0);

        yield return null;
    }
}
