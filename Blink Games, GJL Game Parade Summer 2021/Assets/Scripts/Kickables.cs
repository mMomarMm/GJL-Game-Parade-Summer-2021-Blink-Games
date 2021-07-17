using UnityEngine;
using UnityEngine.UI;
public class Kickables : MonoBehaviour
{
    Animator a;
    int health = 3;
    bool inRange;
    public Text text;
    private void Start()
    {
        a = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) inRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) inRange = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && inRange)
        {
            health--;
            text.text = health.ToString();
            if (health <= 0)
            {
                a.SetBool("Dead", true);
                BoxCollider2D b = GetComponent<BoxCollider2D>();
                CapsuleCollider2D p = GetComponent<CapsuleCollider2D>();
                b.enabled = false;
                p.enabled = false;
                Destroy(text);
                Destroy(this);
            }
            else
            {
                a.SetTrigger("Knock");
            }
        }
    }
}
