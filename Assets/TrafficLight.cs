using UnityEngine;

public class TrafficController : MonoBehaviour
{
    [SerializeField] GameObject greenLight, yellowLight, redLight;
    MeshRenderer greenRenderer, yellowRenderer, redRenderer;

    [SerializeField] Color green, yellow, red;

    void Awake()
    {
        greenRenderer = greenLight.GetComponent<MeshRenderer>();
        yellowRenderer = yellowLight.GetComponent<MeshRenderer>();
        redRenderer = redLight.GetComponent<MeshRenderer>();
    }

    void Start()
    {
        InvokeRepeating(nameof(SwitchToGreen), 0f, 12f);
        Invoke(nameof(SwitchToYellow), 5f);
        Invoke(nameof(SwitchToRed), 7f);
    }

    void SwitchToGreen()
    {
        SetLight(greenRenderer, green, 5f);
        SetLight(yellowRenderer, yellow * 0.2f, 0f);
        SetLight(redRenderer, red * 0.2f, 0f);
    }

    void SwitchToYellow()
    {
        SetLight(greenRenderer, green * 0.2f, 0f);
        SetLight(yellowRenderer, yellow, 5f);
        SetLight(redRenderer, red * 0.2f, 0f);
    }

    void SwitchToRed()
    {
        SetLight(greenRenderer, green * 0.2f, 0f);
        SetLight(yellowRenderer, yellow * 0.2f, 0f);
        SetLight(redRenderer, red, 5f);
    }

    void SetLight(MeshRenderer renderer, Color baseColor, float emissionMultiplier)
    {
        renderer.material.color = baseColor;
        renderer.material.SetColor("_EmissionColor", baseColor * emissionMultiplier);
    }
}