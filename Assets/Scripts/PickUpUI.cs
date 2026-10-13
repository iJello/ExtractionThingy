using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpUI : MonoBehaviour
{
    public static PickUpUI instance;

    [SerializeField] private GameObject popupPrefab;
    [SerializeField] private Transform popupParent;

    private void Awake()
    {
        instance = this;
    }

    public void ShowPopup(Item item)
    {
        GameObject popup = Instantiate(popupPrefab, popupParent);

        Image icon = popup.transform.Find("Icon").GetComponent<Image>();
        icon.sprite = item.icon;

        popup.GetComponentInChildren<TMP_Text>().text = "+ " + item.itemName;

        Destroy(popup, 2f);
    }
}
