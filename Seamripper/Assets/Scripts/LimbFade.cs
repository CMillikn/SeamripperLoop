using TMPro;
using UnityEngine;

public class LimbFade : MonoBehaviour
{
    public float fadeSpeed;
    public string fontWords;
    public TextMeshProUGUI fontText;
    public Color fontColor;
    void Start()
    {
        fontText.color = fontColor;
        fontText.text = fontWords;
    }

    // Update is called once per frame
    void Update()
    {
        fontText.color = new Color(fontText.color.r,fontText.color.g,fontText.color.b,fontText.color.a - (Time.deltaTime * fadeSpeed));
        if (fontText.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
