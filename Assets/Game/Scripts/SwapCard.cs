using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCard : MonoBehaviour
{

    public List<Card> NewCards;
    public List<Card> OwnCards;
    public List<GameObject> OtherCards;
    public GameObject[] NewCardPlaces = new GameObject[4];
    public GameObject[] OwnCardPlaces = new GameObject[4];

    private Deck deck;
    private Hand hand;
    private ArenaStats stats;
    private CoreGame game;
    private bool isNewSelected = false;
    private bool isOwnSelected = false;
    private AudioSource source;
    private void Awake()
    {
        deck = ServiceLocator.GetService<Deck>();
        hand = ServiceLocator.GetService<Hand>();
        stats = ServiceLocator.GetService<ArenaStats>();
        game = ServiceLocator.GetService<CoreGame>();
        source = GetComponent<AudioSource>();
    }
    public void RerollSwapCards()
    {
        source.Play();
        isNewSelected = false;
        isOwnSelected = false;

        for (int i = 0; i < NewCardPlaces.Length; i++)
        {
            int random = Random.Range(0, OtherCards.Count);
            Card card = Instantiate(OtherCards[random], NewCardPlaces[i].transform).GetComponent<Card>();
            card.IsBuying = true;
            card.IsReverted = false;
            card.Position = NewCardPlaces[i].transform.position;
            NewCards.Add(card);
        }

        for (int i = 0; i < OwnCardPlaces.Length; i++)
        {
            deck.AddToOwnCards();
            hand.AddCard(OwnCards[i]);
            OwnCards[i].IsBuying = true;
        }
    }
    public void AddOwnCard(Card card)
    {
        if (OwnCards.Count < OwnCardPlaces.Length)
        {
            OwnCards.Add(card);
        }
    }
    public void Select(Card card)
    {
        foreach (Card _card in NewCards)
        {
            if (_card.gameObject == card.gameObject)
            {
                SetRevertedNew(card);
                return;
            }
        }

        foreach (Card _card in OwnCards)
        {
            if (_card.gameObject == card.gameObject)
            {
                SetRevertedOwn(card);
            }
        }
    }
    private void SetRevertedNew(Card card)
    {
        foreach (Card _card in NewCards)
        {
            _card.IsReverted = false;
            _card.Aimed = false;
            if (_card.gameObject == card.gameObject)
            {
                _card.IsReverted = true;
                _card.Aimed = true;
                isNewSelected = true;
            }
        }

        if (isOwnSelected && isNewSelected)
        {
            StartCoroutine(Finish());
        }
    }
    private void SetRevertedOwn(Card card)
    {
        foreach (Card _card in OwnCards)
        {
            _card.IsReverted = true;
            _card.Aimed = false;
            if (_card.gameObject == card.gameObject)
            {
                _card.IsReverted = false;
                _card.Aimed = true;
                isOwnSelected = true;
            }
        }

        if (isOwnSelected && isNewSelected)
        {
            StartCoroutine(Finish());
        }
    }
    private IEnumerator Finish()
    {
        stats.MouseLock = true;
        for (int i = NewCards.Count - 1; i >= 0; i--)
        {
            if (!NewCards[i].IsReverted)
            {
                NewCards[i].Kill();
                NewCards.RemoveAt(i);
            }
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = OwnCards.Count - 1; i >= 0; i--)
        {
            if (!OwnCards[i].IsReverted)
            {
                OwnCards[i].Kill();
                OwnCards.RemoveAt(i);
            }
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = NewCards.Count - 1; i >= 0; i--)
        {
            NewCards[i].Kill();
            NewCards.RemoveAt(i);
            yield return null;
        }

        for (int i = OwnCards.Count - 1; i >= 0; i--)
        {
            OwnCards[i].Kill();
            OwnCards.RemoveAt(i);
            yield return null;
        }
        stats.MouseLock = false;

        yield return new WaitForSeconds(0.5f);
        game.SwitchGameplay();
    }
}