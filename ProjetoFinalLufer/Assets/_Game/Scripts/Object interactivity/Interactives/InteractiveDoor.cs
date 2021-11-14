using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDoor : Interactive
{
    [SerializeField] private ItemConfig keyType;
    [SerializeField] private bool isLocked;
    [SerializeField] private GameObject lockObject;
    [SerializeField] private Animator animator;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxDoorOpening;
    [FMODUnity.EventRef]
    public string sfxDoorLocked;
    [FMODUnity.EventRef]
    public string sfxDoorUnlocked;

    [SerializeField] private Dialogue lockedDialogue;

    private void Start()
    {
        lockObject.SetActive(isLocked);
    }

    public override void Interact(GameObject player)
    {
        ObjectCollector collector = player.GetComponent<ObjectCollector>();

        if(isLocked && collector.CheckQty(keyType) == 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot(sfxDoorLocked, transform.position);
            player.GetComponentInChildren<PlayerDialogueState>().dialogue = lockedDialogue;
            player.transform.GetChild(2).GetComponent<ConcurrentStateMachine>().ChangeState(typeof(PlayerDialogueState));
        }
        else if (isLocked && collector.CheckQty(keyType) > 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot(sfxDoorUnlocked, transform.position);
            isLocked = false;
            collector.UseItem(keyType);
            lockObject.SetActive(false);
        }
        else if(!isLocked)
        {
            animator.SetTrigger("Open");
            FMODUnity.RuntimeManager.PlayOneShot(sfxDoorOpening, transform.position);
        }
    }
}