using UnityEngine;

public class DragAndUse : MonoBehaviour, IVisualizer
{
    public MoveableSmoothDamp DragObject;

    private Vector2 offset;
    private void Start()
    {
        DragObject.gameObject.SetActive(false);
    }
    public void Visualize(bool isShow)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            offset = mousePos - transform.position;

            DragObject.gameObject.transform.position = transform.position;
            DragObject.targetPosition = transform.position;
        }

        if (isShow)
        {
            Vector2 mousePosition = mousePos;

            DragObject.gameObject.SetActive(true);
            DragObject.targetPosition = mousePosition - offset;
        }
        else
        {
            DragObject.gameObject.SetActive(false);
        }
    }
}
