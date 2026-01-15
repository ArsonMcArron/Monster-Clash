using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void CambiarEscena (string nombre) 
    {
        SceneManager.LoadScene(nombre);
    }
}
