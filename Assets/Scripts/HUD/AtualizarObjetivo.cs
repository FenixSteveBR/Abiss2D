using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AtualizarObjetivo : MonoBehaviour
{
    public GameObject ativaCena;
    public TextMeshProUGUI textoObjetivo, textoObjetivoMenu;
    public GameObject objetivoUI, objetivoMenu;
    AudiosPequenos audiosPequenos;
    public ScriptInventory invPlayer;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        audiosPequenos = FindObjectOfType<AudiosPequenos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invPlayer.ProcurarItem("Kit SOS") && i==0)
        {

            AtualizarObjetivoEntregarKit();
        }
    }

    public void AtualizarObjetivoKitSOS()
    {
        textoObjetivo.text = "Encontre uma maneira de ajuda-lá.";
        textoObjetivoMenu.text = "Encontre uma maneira de ajuda a mulher que está machucada no Vestiário.";
        StartCoroutine(Mensagem());
        objetivoMenu.SetActive(true);
    }

    public void AtualizarObjetivoEntregarKit()
    {
        ativaCena.SetActive(true);
        textoObjetivo.text = "Entregue o kit SOS para a mulher machucada.";
        textoObjetivoMenu.text = "Entregue o kit SOS para a mulher machucada.";
        StartCoroutine(Mensagem());
        i++;
    }

    public void AtualizarObjetivoPuzzleBateria()
    {
        textoObjetivo.text = "Busque uma maneira de destrancar as portas.";
        textoObjetivoMenu.text = "Busque uma maneira de destrancar as portas.";
        StartCoroutine(Mensagem());
    }

    IEnumerator Mensagem()
    {
        audiosPequenos.ColetaDocumento();
        yield return new WaitForSeconds(3f);
        objetivoUI.SetActive(true);
        yield return new WaitForSeconds(7f);
        objetivoUI.SetActive(false);


    }

}
