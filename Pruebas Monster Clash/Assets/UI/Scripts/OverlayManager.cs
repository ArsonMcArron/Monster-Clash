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

    // ==========================================
    // ESCENA 1: PARA LOS BOTONES "COMING SOON"
    // (Solo abre el panel y no permite que se cierre al repetir click)
    // ==========================================
    public void OpenOverlayComingSoon(string panelName)
    {
        GameObject panel = BuscarPanel(panelName);
        if (panel == null) return;

        // Limpiamos pantalla y abrimos a piñón fijo
        CloseAllOverlays();
        panel.SetActive(true);
        Debug.Log($"PANELIIIIN [{panel.name}] cambiado a: True (Modo Fijo)");
    }

    // ==========================================
    // ESCENA 2: PARA LOS BOTONES QUE SÍ SE CIERRAN
    // (Hace el toggle normal: si ya estaba abierto, lo cierra)
    // ==========================================
    public void OpenOverlayConToggle(string panelName)
    {
        GameObject panel = BuscarPanel(panelName);
        if (panel == null) return;

        // Guardamos si ya estaba activo antes de borrar la pantalla
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

    // FUNCIÓN AUXILIAR INTERNA (Para no repetir código de búsqueda)
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
