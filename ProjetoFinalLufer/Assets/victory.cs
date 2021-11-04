using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victory : MonoBehaviour
{

    public GameObject UIScreen;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            UIScreen.SetActive(true);
        }
    }
}
