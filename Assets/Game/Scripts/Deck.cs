using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> Cards;

    private Hand hand;
    private SwapCard swapCards;
    private void Start()
    {
        hand = ServiceLocator.GetService<Hand>();
        swapCards = ServiceLocator.GetService<SwapCard>();
        //AddToHand();
        //AddToHand();
        //AddToHand();
        //AddToHand();
    }
    public void AddToHand()
    {
        if (Cards == null || Cards.Count == 0) return;

        int cardsCount = Cards.Count;
        cardsCount = Mathf.Clamp(cardsCount, 0, hand.Cards.Length);
        int randomCard = Random.Range(0, cardsCount);
        if (hand.CardsCount() < hand.Cards.Length)
        {
            Card card = Instantiate(Cards[randomCard].GetComponent<Card>());
            hand.AddCard(card);
            Cards.Remove(Cards[randomCard]);
        }
    }
    public void AddToOwnCards()
    {
        if (Cards == null || Cards.Count == 0) return;

        int cardsCount = Cards.Count;
        int randomCard = Random.Range(0, cardsCount);

        Card card = Instantiate(Cards[randomCard].GetComponent<Card>());
        if (swapCards.OwnCards.Count < swapCards.OwnCardPlaces.Length)
        {
            swapCards.AddOwnCard(card);
            Cards.Remove(Cards[randomCard]);
        }
    }
    public void ReturnToDeck(Card card)
    {
        string resources = "Prefabs/";
        string prefabName = card.gameObject.name;
        prefabName = prefabName.Replace("(Clone)", "");
        string path = resources + prefabName;

        GameObject prefab = Resources.Load<GameObject>(path);

        if (prefab != null) Cards.Add(prefab);
    }
}
