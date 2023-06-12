using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MapaConfig : MonoBehaviour, IDeselectHandler
{
    public TextMeshProUGUI txtnomeSala, txtLocal;
    public GameObject nomeLocal;
    string texto;
    Button botao;

    // Start is called before the first frame update
    void Start()
    {
        botao = GetComponent<Button>();
        nomeLocal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelecionouSala()
    {
       
        nomeLocal.SetActive(true);
        texto = txtnomeSala.text;
        txtLocal.text = texto;
        
    }
    public void OnDeselect(BaseEventData eventData)
    {
        nomeLocal.SetActive(false);
        // faça algo quando o botão não estiver mais selecionado
    }




}
