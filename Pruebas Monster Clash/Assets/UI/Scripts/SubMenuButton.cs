using UnityEngine;

public class SubMenuButton : MonoBehaviour
{
    [Header("Configuración del Submenú")]
    public GameObject panelSubmenu;
    public GameObject panelPadre;

    [Header("Referencia al Manager")]
    public OverlayManager managerDirecto;

    public void EjecutarApertura()
    {
        //TA EL BOTON O NO?
        if (managerDirecto == null)
        {
            Debug.LogError($"[ERROR] EL BOTON '{gameObject.name}' NO TIENE ASIGNAAS LAS COSAS CHAVAL");
            return;
        }

        //TAN LOS PANELES O NO?
        if (panelSubmenu != null && panelPadre != null)
        {
            Debug.Log($"[BOTÓN] TOY TRATANDO DE ABRIR '{panelSubmenu.name}' QUE DEPENDE DE '{panelPadre.name}'");

            //MANAGER, HAZ COSAS
            managerDirecto.OpenSubOverlay(panelSubmenu.name, panelPadre.name);
        }
        else
        {
            Debug.LogError($"[ERROR] ASIGNA LOS PANELES AL BOTON '{gameObject.name}', CACHO MELON.");
        }
    }
}


