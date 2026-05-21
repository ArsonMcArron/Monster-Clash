using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
