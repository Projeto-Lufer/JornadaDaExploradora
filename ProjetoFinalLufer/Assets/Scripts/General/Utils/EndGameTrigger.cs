using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    [SerializeField] private GameTransitionsManager transitions;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transitions.WinGame();
        }
    }
}
