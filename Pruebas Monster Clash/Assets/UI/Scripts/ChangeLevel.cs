using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void CargarEscena(string nombreEscena)
    {
        //BOTON VACIO DEBUG
        if (string.IsNullOrEmpty(nombreEscena))
        {
            Debug.LogError("¡Error! No hay nombre de escena en el boton.");
            return;
        }

        //BOTON FUNCIONA DEBUG
        Debug.Log("El boton funciona. YIPPIEEE. Intentando cargar: " + nombreEscena);

        //CARGA ESCENA
        SceneManager.LoadScene(nombreEscena);
    }
}
