using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Kickables : MonoBehaviour
{
    Animator a;
    int health = 3;
    bool inRange;
    public Text text;
    public GameObject blood;
    [SerializeField] List<Collider2D> colliders;

    private void Start()
    {
        a = GetComponentInChildren<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        inRange = other.CompareTag("Player");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = !other.CompareTag("Player");
    }
    private void Update()
    {
        if (a.GetCurrentAnimatorStateInfo(0).fullPathHash == 2027124095) //check if in idle animation
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
                    foreach (Collider2D c in colliders)
                    {
                        c.enabled = false;
                    }
                    Destroy(text);
                    Destroy(blood, 3f);
                    blood.SetActive(true);
                    Destroy(this);
                }
                else
                {
                    a.SetTrigger("Knock");
                }
            }
        }
    }
}