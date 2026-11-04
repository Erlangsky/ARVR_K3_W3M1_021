using UnityEngine;

public class ProximityUI : MonoBehaviour
{
    public GameObject panelUI;

    private void Start()
    {
        if (panelUI != null) panelUI.SetActive(false); // Awal mulai: panel sembunyi
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") || other.CompareTag("Player"))
            panelUI.SetActive(true); // Dekat mesin: panel langsung muncul
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera") || other.CompareTag("Player"))
            panelUI.SetActive(false); // Menjauh: panel sembunyi lagi
    }
}