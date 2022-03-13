using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class TextCollider : MonoBehaviour
{
    public TMP_Text texty;

    private void Start()
    {
        texty.enabled = false;
    }
    private float timeToAppear = 2f;
    private float timeWhenDisappear;

    //Call to enable the text, which also sets the timer
    public void EnableText()
    {
        texty.enabled = true;
        timeWhenDisappear = Time.time + timeToAppear;
    }

    //We check every frame if the timer has expired and the text should disappear
    void Update()
    {
        if (texty.enabled && (Time.time >= timeWhenDisappear))
        {
            texty.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("show me the text");
        EnableText();
        Debug.Log("i just did");
    }
}
