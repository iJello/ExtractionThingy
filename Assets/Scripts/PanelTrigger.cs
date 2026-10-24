using UnityEngine;

public class PanelTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private GameObject losePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        if (lostPanel != null)
        {
            lostPanel.SetActive(false);
        }
        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }

        bool showPanel = false;
        
        switch (gameObject.tag)
        {
            case "Win":
                if (winPanel != null)
                {
                    winPanel.SetActive(true); showPanel = true;
                }
                break;
            case "Lost":
                if (lostPanel != null)
                {
                    lostPanel.SetActive(true); showPanel = true;
                }
                break;
            case "Lose":
                if (losePanel != null)
                {
                    losePanel.SetActive(true); showPanel = true; 
                    
                }
                break;
        }
        
        if (showPanel)
        {
            FirstPersonCamera fps = FindAnyObjectByType<FirstPersonCamera>();
            if (fps != null)
            {
                fps.UnlockCursor();
            }

            Time.timeScale = 0f;
        }
    }
}