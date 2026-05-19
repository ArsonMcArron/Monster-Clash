using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{
    public void SalirDelJuego()
    {
        //SALIR FUNCIONA DEBUG
        Debug.Log("SE CIERRA. SE CIERRAAAAA. AAAA");

        //EL JUEGO CIERRA
        Application.Quit();

        //PA QUE SE VEA EN PRUEBAS UNITY
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
