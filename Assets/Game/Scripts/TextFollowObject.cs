using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset;   

    void Update()
    {
        if (target != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
        }
    }
}
