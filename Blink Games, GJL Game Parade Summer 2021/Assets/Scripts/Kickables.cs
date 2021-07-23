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
        a = GetComponentInChildren<Animator>();
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
                Player playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                StartCoroutine(playerScript.Kill());
                a.SetBool("Dead", true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
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