using UnityEngine.UI;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    Text t;
    float Health;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = Player.HealthPlayer.ToString();
    }
}
