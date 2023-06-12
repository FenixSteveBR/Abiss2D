using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConfig : MonoBehaviour
{

    public GameObject painelMapa, painelItens, painelDocumemtos;

    public void Itens()
    {
        painelItens.SetActive(true);
        painelMapa.SetActive(false);
        painelDocumemtos.SetActive(false);
    }
    public void Mapa()
    {
        painelItens.SetActive(false);
        painelMapa.SetActive(true);
        painelDocumemtos.SetActive(false);
    }
    public void Documentos()
    {
        painelItens.SetActive(false);
        painelMapa.SetActive(false);
        painelDocumemtos.SetActive(true);
    }

    public void FecharTodos()
    {
        painelItens.SetActive(false);
        painelMapa.SetActive(false);
        painelDocumemtos.SetActive(false);
    }

}
