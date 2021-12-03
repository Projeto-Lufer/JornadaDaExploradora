using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victory : MonoBehaviour
{

    public GameObject UIScreen;
    public GameObject fade;

    IEnumerator waiter()
    {
        fade.SetActive(true);
        yield return new WaitForSecondsRealtime(2.0f);
        Time.timeScale = 0;
        UIScreen.SetActive(true);
    }


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(waiter());
            Debug.Log("coco");
        }
    }
}
