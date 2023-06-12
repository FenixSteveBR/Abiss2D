using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Timeline.Actions.MenuPriority;

public class Navegar : MonoBehaviour
{
    [SerializeField] GameObject navegador, inventario, mapa, documentos;
    void Start()
    {
        navegador.SetActive(false);
    }

    public void AbrirHudInventario()
    {
        navegador.SetActive(true);
        documentos.SetActive(false);
        inventario.SetActive(true);
        mapa.SetActive(false);
        inventario.GetComponent<GerenciarInventarioHUD>().butInv();
    }

    public void FecharHudInventario()
    {
        navegador.SetActive(false);
    }

    public bool VerificarAberto()
    {
        if (navegador.activeSelf)
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }
}