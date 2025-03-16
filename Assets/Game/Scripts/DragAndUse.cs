using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndUse : MonoBehaviour, IVisualizer
{
    public GameObject DragObject;

    private Vector2 offset;
    private void Start()
    {
        DragObject.SetActive(false);
    }
    public void Visualize(bool isShow)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            offset = mousePos - transform.position;
        }

        if (isShow)
        {
            Vector2 mousePosition = mousePos;

            DragObject.SetActive(true);
            DragObject.transform.position = mousePosition - offset;
        }
        else
        {
            DragObject.SetActive(false);
        }
    }
}
