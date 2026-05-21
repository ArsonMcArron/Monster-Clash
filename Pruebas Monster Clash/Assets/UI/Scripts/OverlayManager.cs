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

        if (panel == null)
        {
            Debug.LogError($"NO TA ESO EH: {panelName}");
            return;
        }

        bool estabaActivo = panel.activeSelf;

        //MANTENER A AMBOS PAPI E HIJO
        CloseAllOverlaysExcept(padreANoCerrar, panelName);

        if (!estabaActivo)
        {
            panel.SetActive(true);
            Debug.Log($"SUBPANEL [{panel.name}] abierto.");
        }
        else
        {
            panel.SetActive(false);
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

    private GameObject BuscarPanel(string panelName)
    {
        if (overlayPanels == null)
        {
            Debug.LogError("¡EL ARRAY 'overlayPanels' ESTÁ TOTALMENTE NULO EN EL INSPECTOR!");
            return null;
        }

        Debug.Log($"[INFO] Buscando: '{panelName}' (Longitud: {panelName.Length}). Total en array: {overlayPanels.Length}");

        foreach (GameObject panel in overlayPanels)
        {
            if (panel == null)
            {
                Debug.LogWarning("-> Ojo: Hay un hueco vacío (Missing/Null) dentro del array overlayPanels.");
                continue;
            }

            Debug.Log($"-> Comparando con: '{panel.name}' (Longitud: {panel.name.Length})");

            if (panel.name == panelName)
            {
                return panel;
            }
        }

        Debug.LogWarning("NO TA ESO EH: " + panelName);
        return null;
    }

    //APAGAME TODO MENOS EL PANELIN QUE TE DIGA EH
    private void CloseAllOverlaysExcept(params string[] nombresIgnorados)
    {
        if (overlayPanels == null) return;

        foreach (GameObject panel in overlayPanels)
        {
            if (panel != null)
            {
                bool ignorar = false;

                foreach (string nombre in nombresIgnorados)
                {
                    if (panel.name == nombre)
                    {
                        ignorar = true;
                        break;
                    }
                }

                if (ignorar) continue;

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
}
