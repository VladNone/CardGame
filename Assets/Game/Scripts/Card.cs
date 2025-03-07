using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]  
public class Card : MonoBehaviour
{
    private bool isMouseDown = false;
    private bool isMouseExit = false;
    private void OnMouseDown()
    {
        isMouseDown = true;
        Time.timeScale = 0.1f;
    }
    private void OnMouseExit()
    {
        isMouseExit = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && isMouseDown && isMouseExit)
        {
            CardUse();
            isMouseDown = false;
            isMouseExit = false;
            Time.timeScale = 1f;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            isMouseExit = false;
            Time.timeScale = 1f;
        }
    }
    public virtual void CardUse()
    {
        Debug.Log("this is an abstract class!");
    }
}
