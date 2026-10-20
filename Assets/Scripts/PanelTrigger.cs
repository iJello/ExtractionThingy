using UnityEngine;

public class PanelTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private GameObject losePanel;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
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
        
        switch (gameObject.tag)
        {
            case "Win":
                if (winPanel != null)
                {
                    winPanel.SetActive(true);
                }
                break;
            case "Lost":
                if (lostPanel != null)
                {
                    lostPanel.SetActive(true);
                }
                break;
            case "Lose":
                if (losePanel != null)
                {
                    losePanel.SetActive(true);
                }
                break;
        }
    }
}

