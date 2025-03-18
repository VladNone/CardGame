using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    private ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (particle.particleCount == 0 && !particle.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
