using UnityEngine.UI;
using UnityEngine;

public class BulletsText : MonoBehaviour
{
    Text t;
    public static int bullets;
    // Start is called before the first frame update
    void Start()
    {
        bullets = 100;
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = BulletsText.bullets.ToString();
    }
}