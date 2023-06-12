using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
//using static UnityEditor.Timeline.Actions.MenuPriority;

public class GerenciarDocumentosHUD : MonoBehaviour
{
    [Header("Ajustes")]
    [Tooltip("Coloque o inventario que quer mostrar aqui")] [SerializeField] ScriptInventory playerInv;
    [SerializeField] bool armas, bateria, circuito, cura, iluminacao, injecao, item, outros, pregos, puzzle, sos, documentosInv;


    //[Tooltip("Aqui voce pode adicionar um documento novo")][SerializeField] Documento[] documentos;
    [SerializeField] GameObject prefab, documento, hudDoc;
    [SerializeField] TextMeshProUGUI texto, nome;
    [SerializeField] Scrollbar scrollDoc, scrollHud;
    GameObject[] slots;
    Item[] itens;

    void Start()
    {
    }

    void Update()
    {

    }

    public void butDoc()
    {
        //backInventario.SetActive(true);
        documento.SetActive(true);
        AtualizarDoc();
        hudDoc.SetActive(false);
    }

    public void MostrarHud(string nome)
    {
        /*if (nome == "?????")
        {
            return;
        }*/
        hudDoc.SetActive(true);
        Item item = playerInv.ProcurarItem(nome);
        this.nome.text = nome;
        if (item != null)
        {
            this.nome.text = item.nome;
            texto.text = item.descricao;
        }


        /*for (int a = 0; a < documentos.Length; a++)
        {
            if (documentos[a].texto != "")
            {
                texto.text = documentos[a].texto;
            }
            else
            {
                texto.text = playerInv.ProcurarItem(nome).descricao;
            }
        }*/
        scrollHud.value = 1; 
    }

    public void AtualizarDoc()
    {
        slots = new GameObject[playerInv.ProcurarTipo(Item.tipo.Documento).Length];
        itens = new Item[playerInv.inventario.Count];
        for (int a = 0; a < playerInv.inventario.Count; a++)
        {
            itens[a] = playerInv.inventario[a].item;
        }

        for (int a = 0; a < documento.transform.childCount; a++)
        {
            Destroy(documento.transform.GetChild(a).gameObject);
        }

        for (int a = 0; a < playerInv.inventario.Count; a++)
        {
            if (IgnorarTiposDeItens(itens[a].tipos))
            {
                slots[a] = Instantiate(prefab, documento.transform);
                slots[a].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itens[a].nome;
                slots[a].transform.SetParent(documento.transform);
                if (itens[a].imagem) slots[a].transform.GetChild(1).GetComponent<Image>().sprite = itens[a].imagem;
            }
            else { Debug.Log("Ignorado no carregamento do inventario: " + itens[a].nome + " tipo: " + itens[a].tipos); }
        }
        /*for (int a = 0; a < documentos.Length; a++)
        {
            slots[a] = Instantiate(prefab, documento.transform);
            if (playerInv.ProcurarItem(documentos[a].title) != null)
            {
                slots[a].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = documentos[a].title;
            }
            else
            {
                slots[a].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "?????";
            }
            slots[a].transform.SetParent(documento.transform);
        }*/
        scrollDoc.value = 1;
    }

    bool IgnorarTiposDeItens(Item.tipo tipo)
    {
        if (tipo == Item.tipo.Armas) { return armas; }
        if (tipo == Item.tipo.Bateria) { return bateria; }
        if (tipo == Item.tipo.Circuito) { return circuito; }
        if (tipo == Item.tipo.Cura) { return cura; }
        if (tipo == Item.tipo.Iluminacoes) { return iluminacao; }
        if (tipo == Item.tipo.Injecao) { return injecao; }
        if (tipo == Item.tipo.Item) { return item; }
        if (tipo == Item.tipo.Outros) { return outros; }
        if (tipo == Item.tipo.Pregos) { return pregos; }
        if (tipo == Item.tipo.Puzzle) { return puzzle; }
        if (tipo == Item.tipo.SOS) { return sos; }
        if (tipo == Item.tipo.Documento) { return documentosInv; }

        else { return false; }
    }
}



[System.Serializable]
public class Documento
{
    [TextArea(1,1)]public string title;
    [TextArea(5,5)]public string texto;
    public Sprite sprite;
}