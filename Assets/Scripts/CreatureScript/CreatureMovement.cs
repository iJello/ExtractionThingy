using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureMovement : MonoBehaviour
{
    [SerializeField] private Transform movePoint1;
    [SerializeField] private Transform movePoint2;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float range = 10f;
    
    private Vector3 target;
    private bool headingToPoint2 = true;
    private bool inRange;
    private bool isChasing = false;

    void Start()
    {
        transform.position = movePoint1.position;
         
        target = movePoint2.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        Vector3 direction = target - transform.position;
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            headingToPoint2 = !headingToPoint2;
            
            Transform nextPoint = headingToPoint2 ? movePoint2 : movePoint1;
            
            target = new Vector3(nextPoint.position.x, transform.position.y, nextPoint.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Test");
            SceneManager.LoadScene("BattleScene");
        }
    }
    
}