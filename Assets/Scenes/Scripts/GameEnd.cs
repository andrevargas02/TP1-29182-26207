using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject gameTimer;

    // Método para ativar o painel de vitória e parar o jogo
    public void EndGame()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f;

        // Parar o timer do jogo
        if (gameTimer != null)
        {
            gameTimer.GetComponent<GameTimer>().StopTimer();
        }
    }

    // Método para reiniciar o jogo
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Resetar a escala de tempo para o jogo voltar a funcionar
    }

    // Método para sair do jogo
    public void QuitGame()
    {
        Application.Quit();
    }
}
