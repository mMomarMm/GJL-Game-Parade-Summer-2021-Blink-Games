using UnityEngine;

public class vol : MonoBehaviour
{
    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = Menu_Pause.I2;
    }
}
