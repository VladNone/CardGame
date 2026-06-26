using System.Collections.Generic;
using UnityEngine;

public class EnemySpikes : MonoBehaviour, IDestroyable
{
    public List<GameObject> Spikes;
    public float Force = 1f;

    public void TakeDamage(float Damage)
    {
        if (Damage <= 0f) return;

        if (Damage > Spikes.Count) Damage = Spikes.Count;

        for (int y = 0; y < Damage ; y++)
        {
            int i = Random.Range(0, Spikes.Count - 1);

            GameObject spike = Spikes[i];
            Spikes.Remove(spike);

            spike.transform.SetParent(null);
            Rigidbody2D rb = spike.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            Vector2 dir = spike.transform.position - transform.position;
            rb.AddForce(dir * Force);
            rb.AddTorque(Random.Range(-Force, Force));
            ScaleKill kill = spike.AddComponent<ScaleKill>();
            kill.Speed = 1f;
            kill.IsScaleKill = true;
        }

    }
}
