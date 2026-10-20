using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
    [SerializeField] private float displayTime = 3f;
    [SerializeField] private bool destroyTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (textObject != null)
        {
            textObject.SetActive(true);
        }
        
        if (destroyTrigger)
        {
            Destroy(gameObject);
        }
        
        if (textObject != null)
        {
            Destroy(textObject, displayTime);
        }
    }
}