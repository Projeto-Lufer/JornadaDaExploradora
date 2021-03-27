using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InteractiveIdentifier interactiveIdentifier;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("Trying to interact");
            Interactive interactive = interactiveIdentifier.Getmostrelevantinteractive();

            if(interactive != null)
            {
                interactive.Interact();
            }
        }
    }
}
