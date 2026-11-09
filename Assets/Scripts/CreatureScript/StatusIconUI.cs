
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StatusIconUI : MonoBehaviour
{
    public GameObject iconPrefab;

    private List<GameObject> activeIcons = new List<GameObject>();

    public void UpdateIcons(List<StatusData> statuses)
    {
        foreach (GameObject icon in activeIcons)
        {
            Destroy(icon);
        }

        activeIcons.Clear();
        foreach (StatusData status in statuses)
        {
            GameObject newIcon = Instantiate(iconPrefab, transform);

            Image image = newIcon.GetComponent<Image>();

            if (image != null)
            {
                image.sprite = status.icon;
                image.enabled = status.icon != null;
            }

            activeIcons.Add(newIcon);
        }
    }
}
