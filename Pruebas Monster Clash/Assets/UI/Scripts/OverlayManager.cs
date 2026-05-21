using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    //ARRAY
    public GameObject[] overlayPanels;

    //ESTADO APAGAO AL INICIO
    private void Start()
    {
        if (overlayPanels != null)
        {
            foreach (GameObject panel in overlayPanels)
            {
                if (panel != null)
                {
                    panel.SetActive(false);
                }
            }
        }
    }

    //PARA LOS BOTONES "COMING SOON" DEL CHOOSE YOUR CHARACTER
    public void OpenOverlayComingSoon(string panelName)
    {
        GameObject panel = BuscarPanel(panelName);
        if (panel == null) return;

        //MATA ESOS OVERLAYS Y DEJALOS FIJOOOS
        CloseAllOverlays();
        panel.SetActive(true);
        Debug.Log($"PANELIIIIN [{panel.name}] cambiado a: True (Modo Fijo)");
    }

    //PARA LOS BOTONES CON TOGGLES, ESTOS SI CIERRAN
    public void OpenOverlayConToggle(string panelName)
    {
        GameObject panel = BuscarPanel(panelName);
        if (panel == null) return;

        bool estabaActivo = panel.activeSelf;

        CloseAllOverlays();

        if (estabaActivo)
        {
            Debug.Log($"PANELIIIIN [{panel.name}] cambiado a: False (Cerrado por repetir click)");
        }
        else
        {
            panel.SetActive(true);
            Debug.Log($"PANELIIIIN [{panel.name}] cambiado a: True");
        }
    }

    //COMO REPITAS EL CODIGO DE BUSQUEDA ME MATO.
    private GameObject BuscarPanel(string panelName)
    {
        if (overlayPanels == null) return null;

        foreach (GameObject panel in overlayPanels)
        {
            if (panel != null && panel.name == panelName)
            {
                return panel;
            }
        }
        Debug.LogWarning("NO TA ESO EH: " + panelName);
        return null;
    }

    //QUITAME LOS OVERLAYS MANIN
    public void CloseAllOverlays()
    {
        if (overlayPanels == null) return;

        foreach (GameObject panel in overlayPanels)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }
}
