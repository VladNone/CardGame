using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Card[] Cards = new Card[4];
    public float Distance = 0.3f;
    public float AimedMult = 2f;

    private float originDistance;
    private void Awake()
    {
        originDistance = Distance;
    }
    private void Update()
    {
        if (Cards == null) return;

        int centerIndex = Cards.Length / 2;

        originDistance = Distance - Cards.Length * 0.1f;

        for (int i = 0; i < Cards.Length; i++)
        {
            if (Cards[i] == null)
            {
                continue;
            }
            float aimed = 0f;
            if (Cards[i].Aimed) aimed = AimedMult;

            float offset = (i - centerIndex) * originDistance;

            Cards[i].Position = transform.position + Vector3.right * offset + Vector3.up * aimed;
        }
    }
    public void AddCard(Card card)
    {
        for (int i = 0; i < Cards.Length; i++)
        {
            if (Cards[i] == null)
            {
                Cards[i] = card;
                break;
            }
        }
    }
    public int CardsCount()
    {
        int count = 0;
        for (int i = 0; i < Cards.Length; i++)
        {
            if (Cards[i] != null) count++;
        }

        return count;
    }
}
