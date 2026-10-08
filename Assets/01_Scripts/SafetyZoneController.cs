using UnityEngine;

public class SafetyZoneController : MonoBehaviour
{
    [Header("Components & References")]
    [SerializeField] private Animator barrierAnimator;
    [SerializeField] private MeshRenderer lampRenderer;

    [Header("Materials")]
    [SerializeField] private Material greenMaterial;
    [SerializeField] private Material redMaterial;

    private static readonly int IsClosedHash = Animator.StringToHash("IsClosed");

    private bool isInZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (isInZone) return;

        isInZone = true;
        ActivateSafetySystem();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!isInZone) return;

        isInZone = false;
        DeactivateSafetySystem();
    }

    private void ActivateSafetySystem()
    {
        SetBarrierState(true);
        SetLampMaterial(redMaterial);
    }

    private void DeactivateSafetySystem()
    {
        SetBarrierState(false);
        SetLampMaterial(greenMaterial);
    }

    private void SetBarrierState(bool isClosed)
    {
        if (barrierAnimator != null)
        {
            barrierAnimator.SetBool(IsClosedHash, isClosed);
        }
    }

    private void SetLampMaterial(Material newMaterial)
    {
        if (lampRenderer != null && newMaterial != null)
        {
            lampRenderer.material = newMaterial;
        }
    }
}