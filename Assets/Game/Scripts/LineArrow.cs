using UnityEngine;

public class LineArrow : MonoBehaviour, IVisualizer
{
    public Color Color = Color.white;
    
    private Vector2 position;
    private LineRenderer linePrefab;
    private LineRenderer line;
    private PlayerMovement player;
    private void Start()
    {
        player = ServiceLocator.GetService<PlayerMovement>();
        linePrefab = ServiceLocator.GetService<LineRenderer>();
        line = Instantiate(linePrefab, new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
        line.gameObject.SetActive(false);
        line.startColor = Color;
        line.endColor = Color;
    }

    public void Visualize(bool isShow)
    {
        if (isShow)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - playerPosition;
            RaycastHit2D hit = Physics2D.Raycast(playerPosition, direction);

            line.gameObject.SetActive(true);
            line.SetPosition(0, playerPosition);
            line.SetPosition(1, hit.point);
        }
        else
        {
            if (line != null) line.gameObject.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        if (line != null) Destroy(line.gameObject);
    }
}
