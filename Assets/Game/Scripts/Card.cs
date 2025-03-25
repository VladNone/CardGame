using TMPro;
using UnityEngine;
using EasyTextEffects;

[RequireComponent(typeof(BoxCollider2D))]
public class Card : MonoBehaviour
{
    public float DissolveSmooth = 2.5f;
    public Vector2 Position;
    public bool Aimed = false;
    public bool IsBuying = false;
    public bool IsReverted = true;
    public string Description = "Test Description!";

    private bool isMouseDown = false;
    private bool isMouseExit = false;
    private IVisualizer visualizer;
    private MoveableSmoothDamp move;
    private ArenaStats stats;
    private SpriteRenderer sprite;
    private TextMeshProUGUI text;
    private void Awake()
    {
        TryGetComponent<IVisualizer>(out visualizer);
        TryGetComponent<MoveableSmoothDamp>(out move);
        stats = ServiceLocator.GetService<ArenaStats>();
        text = stats.Text.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        sprite.material = new Material(sprite.material);
        sprite.material.color = sprite.color;
    }
    private void OnMouseDown()
    {
        text.color = new Color(255, 255, 255, 0);
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
        text.color = new Color(255, 255, 255, 0);
        text.GetComponent<TextEffect>().Refresh();
        if (stats.MouseLock) return;
        if (IsBuying) return;
        isMouseExit = true;
        Aimed = false;
    }
    private void OnMouseEnter()
    {
        if (stats.MouseLock) return;
        if (!isMouseDown)
        {
            text.color = new Color(255, 255, 255, 255);
            text.text = Description;
            text.GetComponent<TextEffect>().Refresh();
        }
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
            text.color = new Color(255, 255, 255, 0);
        }
        else if (Input.GetMouseButtonUp(0) && !IsBuying && !stats.MouseLock)
        {
            isMouseDown = false;
            isMouseExit = false;
            Time.timeScale = 1f;
            text.color = new Color(255, 255, 255, 0);
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
        CreateView(true);
        Destroy(gameObject);
    }
    public void CreateView(bool dissolve)
    {
        GameObject view = new GameObject();
        view.transform.position = transform.position;
        view.name = "CardView";
        SpriteRenderer viewSprite = view.AddComponent<SpriteRenderer>();
        viewSprite.sprite = sprite.sprite;
        viewSprite.material = sprite.material;
        if (dissolve) view.AddComponent<DissolveKill>();
    }
}
