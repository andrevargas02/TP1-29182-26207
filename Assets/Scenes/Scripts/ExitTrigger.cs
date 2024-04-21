using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public GameObject victoryPanel;  // Referência ao painel de vitória no Unity Inspector
    public GameTimer gameTimer;      // Referência ao GameTimer no Unity Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ativa o painel de vitória
            if (victoryPanel != null)
                victoryPanel.SetActive(true);
            else
                Debug.LogError("VictoryPanel não está configurado no ExitTrigger");

            // Para o timer do jogo, se existir
            if (gameTimer != null)
                gameTimer.StopTimer();
            else
                Debug.LogError("GameTimer não está configurado no ExitTrigger");

            // Congela o tempo do jogo
            Time.timeScale = 0f;
        }
    }
}
