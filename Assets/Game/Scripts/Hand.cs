using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Card> Cards;
    public float Distance = 0.3f;
    public float AimedMult = 2f;

    private float originDistance;
    private void Awake()
    {
        originDistance = Distance;
    }
    private void Update()
    {
        if (Cards == null || Cards.Count == 0) return;

        int centerIndex = Cards.Count / 2;

        originDistance = Distance - Cards.Count * 0.1f;

        for (int i = 0; i < Cards.Count; i++)
        {
            if (Cards[i] == null)
            {
                Cards.Remove(Cards[i]);
                continue;
            }
            float aimed = 0f;
            if (Cards[i].Aimed) aimed = AimedMult;

            float offset = (i - centerIndex) * originDistance;

            Cards[i].Position = transform.position + Vector3.right * offset + Vector3.up * aimed;
        }
    }
    //public void DeleteCard(GameObject Card)
    //{
    //    if (Cards == null || Cards.Count == 0) return;

    //    for (int i = 0; i < Cards.Count; i++)
    //    {
    //        if (Cards[i].gameObject.GetInstanceID() == Card.gameObject.GetInstanceID())
    //        { 
    //            Cards.Remove(Cards[i]);
    //            Destroy(Card);
    //        }
    //    }
    //}
}
