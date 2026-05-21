using UnityEngine;

public class SubMenuButton : MonoBehaviour
{
    [Header("Configuración del Submenú")]
    public string nombreDelSubmenu;
    public string nombreDelPadre;

    public void EjecutarApertura()
    {
        //BUSCA EL OVERLAY POR DIOS TE LO PIDO
        OverlayManager manager = Object.FindFirstObjectByType<OverlayManager>();
        if (manager != null)
        {
            manager.OpenSubOverlay(nombreDelSubmenu, nombreDelPadre);
        }
        else
        {
            Debug.LogError("¡No hay ningún OverlayManager en la escena, manín!");
        }
    }
}

