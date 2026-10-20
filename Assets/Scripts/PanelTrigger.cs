using UnityEngine;

public class PanelTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private GameObject losePanel;
    
    private void OnTriggerEnter(Collider other)
    {
        // Only react if the Player enters
        if (!other.CompareTag("Player")) return;

        // Hide all panels first
        if (winPanel != null) winPanel.SetActive(false);
        if (lostPanel != null) lostPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);

        // Show the panel matching this trigger's tag
        switch (gameObject.tag)
        {
            case "Win":
                if (winPanel != null) winPanel.SetActive(true);
                break;
            case "Lost":
                if (lostPanel != null) lostPanel.SetActive(true);
                break;
            case "Lose":
                if (losePanel != null) losePanel.SetActive(true);
                break;
            default:
                Debug.LogWarning($"Trigger tag '{gameObject.tag}' has no matching panel.");
                break;
        }
    }
}

