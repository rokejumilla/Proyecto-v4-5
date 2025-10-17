// CountdownTimer.cs
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [Header("Tiempo")]
    public float tiempoInicial = 60f;
    private float tiempoRestante;

    [Header("UI")]
    public Text textoTimer; // o usar TMPro (TextMeshProUGUI) si prefieres

    private bool running = true;

    private void Start()
    {
        tiempoRestante = tiempoInicial;
        UpdateUI();
    }

    private void Update()
    {
        if (!running) return;

        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante <= 0f)
        {
            tiempoRestante = 0f;
            running = false;
            // Disparar Game Over y pausar el juego
            GameEvents.TriggerGameOver();
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (textoTimer) textoTimer.text = Mathf.CeilToInt(tiempoRestante).ToString();
    }
}
