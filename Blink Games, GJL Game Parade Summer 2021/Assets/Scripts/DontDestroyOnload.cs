using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnload : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}