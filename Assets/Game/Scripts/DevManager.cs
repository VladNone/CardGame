using UnityEngine;
using UnityEngine.SceneManagement;

public class DevManager : MonoBehaviour
{
    public GameObject Enemy;
    private void Start()
    {
        #if !UNITY_EDITOR
            Destroy(gameObject);
        #endif
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ServiceLocator.GetService<Deck>().AddToHand();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(Enemy, mousePos, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ServiceLocator.GetService<SwapCard>().RerollSwapCards();
        }
    }
}
