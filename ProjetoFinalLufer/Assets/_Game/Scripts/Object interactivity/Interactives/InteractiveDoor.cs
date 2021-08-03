using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDoor : Interactive
{
    [SerializeField] private bool isLocked;
    [SerializeField] private GameObject lockObject;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        lockObject.SetActive(isLocked);
    }

    public override void Interact(GameObject player)
    {
        ObjectCollector collector = player.GetComponent<ObjectCollector>();

        if (isLocked && collector.GetKeysPossessed() > 0)
        {
            isLocked = false;
            collector.UseKey();
            lockObject.SetActive(false);
        }
        else if(!isLocked)
        {
            animator.SetTrigger("Open");
            audioSource.Play();
        }
    }
}
