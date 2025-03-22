using System.Net.Security;
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
    private ArenaStats stats;
    private void Awake()
    {
        TryGetComponent<IVisualizer>(out visualizer);
        TryGetComponent<MoveableSmoothDamp>(out move);
    }
    private void Start()
    {
        stats = ServiceLocator.GetService<ArenaStats>();
    }
    private void OnMouseDown()
    {
        if (stats.MouseLock) return;
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
        if (stats.MouseLock) return;
        if (IsBuying) return;
        isMouseExit = true;
        Aimed = false;
    }
    private void OnMouseEnter()
    {
        if (stats.MouseLock) return;
        if (IsBuying) return;
        isMouseExit = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && isMouseDown && isMouseExit && !IsBuying && !stats.MouseLock)
        {
            CardUse();
            isMouseDown = false;
            isMouseExit = false;
            Time.timeScale = 1f;
        }
        else if (Input.GetMouseButtonUp(0) && !IsBuying && !stats.MouseLock)
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
        if (stats.MouseLock) return;
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
