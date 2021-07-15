using TMPro;
using UnityEngine;

public class BulletsText : MonoBehaviour
{
    TextMeshProUGUI t;
    public static int bullets;
    // Start is called before the first frame update
    void Start()
    {
        bullets = 0;
        t = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = BulletsText.bullets.ToString();
    }
}