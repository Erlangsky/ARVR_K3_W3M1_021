using UnityEngine;

public class SafetyZoneManager : MonoBehaviour
{
    [Header("Components Reference")]
    [SerializeField] private Animator barrierAnimator;
    [SerializeField] private Renderer lampRenderer;
    [SerializeField] private Light warningLight;

    [Header("Lamp Materials")]
    [SerializeField] private Material greenMaterial;
    [SerializeField] private Material redMaterial;

    private const string PLAYER_TAG = "Player";
    private const string ANIM_PARAM_IS_CLOSED = "IsClosed";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            SetSafetySystemState(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            SetSafetySystemState(true);
        }
    }

    private void SetSafetySystemState(bool isPlayerInside)
    {
        ControlBarrier(isPlayerInside);
        UpdateWarningLamp(isPlayerInside);
    }

    private void ControlBarrier(bool close)
    {
        if (barrierAnimator != null)
        {
            barrierAnimator.SetBool(ANIM_PARAM_IS_CLOSED, close);
        }
    }

    private void UpdateWarningLamp(bool isRed)
    {
        if (lampRenderer != null)
        {
            lampRenderer.material = isRed ? redMaterial : greenMaterial;
        }

        if (warningLight != null)
        {
            warningLight.color = isRed ? Color.red : Color.green;
        }
    }
}