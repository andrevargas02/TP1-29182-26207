using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int countdownTime = 3;
    public TextMeshProUGUI countdownDisplay;
    public GameObject victoryPanel;
    public PlayerController playerController;
    public GameTimer gameTimer;

    private void Start()
    {
        if (countdownDisplay == null || victoryPanel == null || playerController == null || gameTimer == null)
        {
            Debug.LogError("GameController: Missing component references in the inspector!");
            return;
        }

        victoryPanel.SetActive(false);
        playerController.canMove = false;
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        countdownDisplay.gameObject.SetActive(true);

        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdownTime--;
        }

        countdownDisplay.text = "GO";
        yield return new WaitForSecondsRealtime(1f);
        countdownDisplay.gameObject.SetActive(false);

        gameTimer.StartTimer();
        playerController.canMove = true;
    }

    public void EndGame()
    {
        playerController.canMove = false;
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);
        gameTimer.StopTimer();
        Debug.Log("Game Ended: Player has won!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
