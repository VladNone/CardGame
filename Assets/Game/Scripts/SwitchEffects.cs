using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SwitchEffects : MonoBehaviour
{
    public void Switch()
    {
        PostProcessVolume effect = Camera.main.GetComponent<PostProcessVolume>();

        if (effect.enabled)
        {
            effect.enabled = false;
        }
        else
        {
            effect.enabled = true;
        }
    }
}
