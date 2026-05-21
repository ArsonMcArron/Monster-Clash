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

    //PARA ABRIR LOS PANELES SUBMENUS SIN CERRAR EL PADRE
    //panelName = SUBMENU
    //padreANoCerrar = MENU DEL QUE DEPENDE EL SUBMENU
    public void OpenSubOverlay(string panelName, string padreANoCerrar)
    {
        GameObject panel = BuscarPanel(panelName);
        if (panel == null) return;

        //GUARDAR EL ESTADO DEL TOGGLE
        bool estabaActivo = panel.activeSelf;

        //MATA ESOS OVERLAYS!! (EXCEPTO EL PADRE)
        CloseAllOverlaysExcept(padreANoCerrar);

        //SI TA APAGAO PRENDETE Y VICEVERSA
        if (!estabaActivo)
        {
            panel.SetActive(true);
            Debug.Log($"SUBPANEL [{panel.name}] abierto. Padre [{padreANoCerrar}] se mantuvo activo.");
        }
        else
        {
            Debug.Log($"SUBPANEL [{panel.name}] cerrado.");
        }
    }

    //PARA LOS PANELES QUE NO CIERRAN
    public void OpenOverlaySinToggle(string panelName)
    {
        GameObject panel = BuscarPanel(panelName);
        if (panel == null) return;

        //MATA ESOS OVERLAYS Y DEJALOS FIJOOOS
        CloseAllOverlays();
        panel.SetActive(true);
        Debug.Log($"PANELIIIIN [{panel.name}] cambiado a: True (Modo Fijo)");
    }

    //PARA LOS PANELES CON TOGGLES, ESTOS SI CIERRAN
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

    //APAGAME TODO MENOS EL PANELIN QUE TE DIGA EH
    private void CloseAllOverlaysExcept(string nombreIgnorado)
    {
        if (overlayPanels == null) return;

        foreach (GameObject panel in overlayPanels)
        {
            if (panel != null)
            {
                // Si el panel es el que queremos ignorar (el padre), nos lo saltamos
                if (panel.name == nombreIgnorado) continue;

                panel.SetActive(false);
            }
        }
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

    //RESOLUCIONES DE PANTALLA
public class ResolutionManager : MonoBehaviour
{
    public void SetResolution_HD()
    {
        //PANTALLA COMPLETA
        Screen.SetResolution(1280, 720, true);
        Debug.Log("Resolución cambiada a HD (1280x720)");
    }

    public void SetResolution_FullHD()
    {
        //PANTALLA COMPLETA
        Screen.SetResolution(1920, 1080, true);
        Debug.Log("Resolución cambiada a Full HD (1920x1080)");
    }

    public void SetResolution_QuadHD()
    {
        //PANTALLA COMPLETA
        Screen.SetResolution(2560, 1440, true);
        Debug.Log("Resolución cambiada a Quad HD (2560x1440)");
    }
}

}
