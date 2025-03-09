using UnityEngine;
using UnityEngine.SceneManagement;

public class DevManager : MonoBehaviour
{
    public GameObject Card;
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
            GameObject card = Instantiate(Card);
            ServiceLocator.GetService<Hand>().Cards.Add(card.GetComponent<Card>());
        }
    }
}
