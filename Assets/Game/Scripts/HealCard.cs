using UnityEngine;
[RequireComponent (typeof(Card))]
public class HealCard : MonoBehaviour
{
    private Card card;
    private void Start()
    {
        card = GetComponent<Card>();
    }
    private void Update()
    {
        card.IsReverted = false;
    }
    private void OnDestroy()
    {
        PlayerMovement player = ServiceLocator.GetService<PlayerMovement>();
        if (player != null && card.Aimed)
        {
            player.Hp = player.Hp + 1f; // ну лучше конечно сделать по красивее ну ладно
            Debug.Log(player.Hp);
        }
    }
}
