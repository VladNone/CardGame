using UnityEngine;
using UnityEngine.SceneManagement;

public class DevManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Mine;
    public GameObject Money;
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
            ServiceLocator.GetService<Hand>().KillAllCards();
            ServiceLocator.GetService<SwapCard>().RerollSwapCards();
        }
        if ( Input.GetKeyDown(KeyCode.F))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(Mine, mousePos, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(Money, mousePos, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            for (int i = 0; i < 3; i++)
            {
                Instantiate(Money, mousePos, transform.rotation);
            }
        }
    }
}
