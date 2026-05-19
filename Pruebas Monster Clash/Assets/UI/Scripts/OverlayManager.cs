using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    public GameObject overlayPanel;

    //ESTADO APAGAO AL INICIO
    private void Start()
    {
        if (overlayPanel != null)
        {
            overlayPanel.SetActive(false);
        }
    }

    //ESTADO OVERLAY
    public void ToggleOverlay()
    {
        if (overlayPanel != null)
        {
            //INVERTIR ESTADO
            bool isActive = overlayPanel.activeSelf;
            overlayPanel.SetActive(!isActive);
            Debug.Log("Estado del panel cambiado a: " + !isActive);
        }
    }
}

