using UnityEngine;

public class PlayerDraggingState : ConcurrentState
{
    [Header("External references")]
    [SerializeField] private ObjectManipulator objectManipulator;
    [SerializeField] private Animator animator;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string voiceAylaShortActions;


    public override void Enter()
    {
        FMODUnity.RuntimeManager.PlayOneShot(voiceAylaShortActions, transform.position);
        animator.SetBool("Pushing", true);
    }

    public override void Exit()
    {
        animator.SetBool("Pushing", false);
        animator.SetBool("PushingForward", false);
        animator.SetBool("PushingBackwards", false);
        animator.SetFloat("MoveAmount", 0f);
    }

    public override void HandleInput()
    {
        if (stateMachine.inputManager.actionInteract.triggered || stateMachine.inputManager.actionCancel.triggered)
        {
            objectManipulator.ReleaseObject();
            base.stateMachine.ChangeState(typeof(PlayerNotActingState));
        }
    }
}