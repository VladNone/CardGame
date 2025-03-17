using UnityEngine;
using UnityEngine.SceneManagement;

public class DevManager : MonoBehaviour
{
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
            Debug.Log(ServiceLocator.GetService<ArenaStats>().NearestEnemy());
        }
    }
}
