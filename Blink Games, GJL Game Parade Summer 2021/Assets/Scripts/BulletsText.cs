using TMPro;
using UnityEngine;

public class BulletsText : MonoBehaviour
{
    TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Bullets = " + Player.bullets;
    }
}
