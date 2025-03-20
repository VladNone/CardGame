using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Card : MonoBehaviour
{
    public Vector2 Position;
    public bool Aimed = false;
    public bool IsBuying = false;
    public bool IsReverted = true;

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
        if (IsBuying)
        {
            Select();
        }
        else
        {
            isMouseDown = true;
            Time.timeScale = 0.1f;
        }
    }
    private void OnMouseExit()
    {
        if (IsBuying) return;
        isMouseExit = true;
        Aimed = false;
    }
    private void OnMouseEnter()
    {
        if (IsBuying) return;
        isMouseExit = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && isMouseDown && isMouseExit && !IsBuying)
        {
            CardUse();
            isMouseDown = false;
            isMouseExit = false;
            Time.timeScale = 1f;
        }
        else if (Input.GetMouseButtonUp(0) && !IsBuying)
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
        if (IsBuying) return;
        Aimed = true;
    }
    public virtual void CardUse()
    {
        Debug.Log("this is an abstract class!");
    }
    public void Select()
    {
        ServiceLocator.GetService<SwapCard>().Select(this);
    }
    public void Kill()
    {
        if (IsReverted) ServiceLocator.GetService<Deck>().ReturnToDeck(this);
        Destroy(gameObject);
    }
}
