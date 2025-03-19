using UnityEditor;
using UnityEngine;

public class ScaleKill : MonoBehaviour
{
    public bool IsScaleKill = false;
    public float Speed = 40f;

    private void Update()
    {
        if (IsScaleKill)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(0f, 0f, 0f), Speed * Time.deltaTime);
            if (transform.localScale == new Vector3(0f, 0f, 0f)) Destroy(gameObject);
        }
    }
}
