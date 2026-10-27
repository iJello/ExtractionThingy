using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button continueButton;

    private bool gameEnded = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (endGamePanel != null)
        {
            endGamePanel.SetActive(false);
        }

        if (continueButton != null)
        {
            continueButton.onClick.AddListener(GoToMainBase);
        }
    }

    public void Win()
    {
        ShowEndPanel("You Win!");
    }

    public void Lose()
    {
        ShowEndPanel("You Lost!");
    }

    private void ShowEndPanel(string text)
    {
        if (gameEnded)
        {
            return;
        }
        gameEnded = true;

        if (resultText != null)
        {
            resultText.text = text;
        }

        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    private void GoToMainBase()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainBase");
    }
}