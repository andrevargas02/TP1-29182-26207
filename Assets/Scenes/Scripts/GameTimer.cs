using System.Collections;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;
    public float timer { get; private set; } // Agora é uma propriedade para acesso externo
    private bool timerRunning = false;

    public void StartTimer()
    {
        timer = 0f;
        timerRunning = true;
        timerDisplay.gameObject.SetActive(true);
    }

    public void StopTimer()
    {
        timerRunning = false;
        timerDisplay.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;
            timerDisplay.text = $"Time: {timer:F2}s";
        }
    }
}
