using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text timeDisplay;

    private void Start()
    {
        float lastTime = PlayerPrefs.GetFloat("LastTime", 0);
        timeDisplay.text = $"Tempo: {lastTime:F2} segundos";  // Mostra o tempo
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");  // Substitua "GameScene" pelo nome da sua cena de jogo principal
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
