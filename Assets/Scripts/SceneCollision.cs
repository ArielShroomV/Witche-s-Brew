using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollision : MonoBehaviour
{
    [SerializeField] AudioSource portalColl;
    [SerializeField] int x;
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

        SceneManager.LoadScene(x);
        yield return null;
    }
}
