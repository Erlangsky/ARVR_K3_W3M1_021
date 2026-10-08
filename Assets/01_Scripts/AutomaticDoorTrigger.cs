using UnityEngine;

public class AutomaticDoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    private static readonly int DoorOpen = Animator.StringToHash("DoorOpen");

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        doorAnimator.SetBool(DoorOpen, true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        doorAnimator.SetBool(DoorOpen, false);
    }
}
