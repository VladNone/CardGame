using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Card : MonoBehaviour
{
    public Vector2 Position;
    public bool Aimed = false;

    private bool isMouseDown = false;
    private bool isMouseExit = false;
    private IVisualizer visualizer;
    private MoveableSmoothDamp move;
    private void Awake()
    {
        TryGetComponent<IVisualizer>(out visualizer);
        TryGetComponent<MoveableSmoothDamp>(out move);
    }
    private void OnMouseDown()
    {
        isMouseDown = true;
        Time.timeScale = 0.1f;
    }
    private void OnMouseExit()
    {
        isMouseExit = true;
        Aimed = false;
    }
    private void OnMouseEnter()
    {
        isMouseExit = false;
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


        if (visualizer != null) visualizer.Visualize(isMouseDown && isMouseExit);
        if (move != null) move.targetPosition = Position;
    }
    private void OnMouseOver()
    {
        Aimed = true;
    }
    public virtual void CardUse()
    {
        Debug.Log("this is an abstract class!");
    }
}
