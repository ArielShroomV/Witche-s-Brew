using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeWitch : MonoBehaviour
{
    public float scale = .01f;
  
    public void ScaleWitch()
    {if (transform.localScale.x > 1)
        {
            transform.localScale = transform.localScale - new Vector3(scale, scale);
        }
        

        }
}
