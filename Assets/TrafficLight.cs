using UnityEngine;
using System.Collections;

public class TrafficController : MonoBehaviour
{
    [SerializeField] GameObject greenObj, yellowObj, redObj;
    MeshRenderer greenRenderer, yellowRenderer, redRenderer;

    [SerializeField] Color greenColor, yellowColor, redColor;

    void Start()
    {
        greenRenderer = greenObj.GetComponent<MeshRenderer>();
        yellowRenderer = yellowObj.GetComponent<MeshRenderer>();
        redRenderer = redObj.GetComponent<MeshRenderer>();

        StartCoroutine(LightCycle());
    }

    IEnumerator LightCycle()
    {
        Color dimGreen = greenColor * 0.2f;
        Color dimYellow = yellowColor * 0.2f;
        Color dimRed = redColor * 0.2f;

        while (true)
        {
            ApplyLight(greenRenderer, greenColor, 5f);
            ApplyLight(yellowRenderer, dimYellow, 0f);
            ApplyLight(redRenderer, dimRed, 0f);
            yield return new WaitForSeconds(5f);

            ApplyLight(greenRenderer, dimGreen, 0f);
            ApplyLight(yellowRenderer, yellowColor, 5f);
            ApplyLight(redRenderer, dimRed, 0f);
            yield return new WaitForSeconds(2f);

            ApplyLight(greenRenderer, dimGreen, 0f);
            ApplyLight(yellowRenderer, dimYellow, 0f);
            ApplyLight(redRenderer, redColor, 5f);
            yield return new WaitForSeconds(5f);
        }
    }

    void ApplyLight(MeshRenderer rend, Color col, float emission)
    {
        rend.material.color = col;
        rend.material.SetColor("_EmissionColor", col * emission);
    }
}