using UnityEngine;

public class DissolveKill : MonoBehaviour
{
    public float Smooth = 2.5f;
    
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();    
    }
    private void Update()
    {
        float p = sprite.material.GetFloat("_Threshold");
        p += Smooth * Time.deltaTime;
        sprite.material.SetFloat("_Threshold", p);

        if (p > 0.85) Destroy(gameObject);
    }
}
