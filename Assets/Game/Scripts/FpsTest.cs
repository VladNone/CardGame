using TMPro;
using UnityEngine;

public class FpsTest : MonoBehaviour
{
    private TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        text.text = "Fps " + (int)(1.0f / Time.deltaTime);
    }
}
