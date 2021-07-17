using UnityEngine;

public class DontDestroyOnload : MonoBehaviour
{
    private static bool firsttime;
    private void Awake()
    {
        if (!firsttime) { firsttime = true; DontDestroyOnLoad(gameObject); }
        else
        { Destroy(gameObject); }
    }
}