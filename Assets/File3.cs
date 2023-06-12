using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class File3 : MonoBehaviour
{
    AtivaDocumento ad;
    public GameObject interagir, mensagem, imagemDocumento;
    public TextMeshProUGUI textoMensagem, textoDocumento;
    bool tocando;
    public string mensagemText;
    [TextArea(10, 10)]
    public string texto;
    Canvas documento;
    int n = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        ad = FindObjectOfType<AtivaDocumento>();
    }

    // Update is called once per frame
    void Update()
    {
        AtivaCanvas();
    }

    

    public void AtivaCanvas()
    {
        if (Input.GetKeyDown(KeyCode.F) && tocando == true)
        {
            SalvarInformacoes.EscreverLinha("Pegou Documento do computador");
            imagemDocumento.SetActive(true);
            textoDocumento.text = texto;
            ad.ativaDoc3();
            n++;
        }
        
        
    }

    public void DesativaCanvas()
    {
        imagemDocumento.SetActive(false);
        textoMensagem.text = mensagemText;
        if (n == 1)
        {
            StartCoroutine(Mensagem());
        }
        


    }

    IEnumerator Mensagem()
    {
        yield return new WaitForSeconds(0.1f); 
        mensagem.SetActive(true);

        yield return new WaitForSeconds(3f);
        mensagem.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SalvarInformacoes.EscreverLinha("Passou pelo computador da sala 5 (chefe)");
            interagir.SetActive(true);
            tocando = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            interagir.SetActive(false);
            tocando = false;
        }
    }

}
