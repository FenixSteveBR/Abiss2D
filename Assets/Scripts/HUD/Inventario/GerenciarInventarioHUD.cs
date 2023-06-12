using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;

public class GerenciarInventarioHUD : MonoBehaviour
{
    [Header("Ajustes")]
    [Tooltip("Coloque o inventario que quer mostrar aqui")] [SerializeField] ScriptInventory playerInv;
    [SerializeField] bool armas, bateria, circuito, cura, iluminacao, injecao, item, outros, pregos, puzzle, sos, documentos;

    [Header("Colocar inventario na HUD")]
    [Tooltip("Não mexer - objeto do inventario para funcionar")] [SerializeField] Scrollbar scroll;
    [Tooltip("Não mexer - objeto do inventario para funcionar")][SerializeField] GameObject slotPrefab, backInventario, inventario, textSemItem;

    [Header("Colocar item no inventario")]
    [Tooltip("Não mexer - objeto do inventario para funcionar")][SerializeField] Image imagem;
    [Tooltip("Não mexer - objeto do inventario para funcionar")][SerializeField] GameObject hudItem, nome, quantidade, descricao, botao;
    [Tooltip("Não mexer - objeto do inventario para funcionar")][SerializeField] Scrollbar scroll2;

    [Header("Inventario seleção de armas")]
    [Tooltip("Não mexer - objeto do inventario para funcionar")] [SerializeField] GameObject hudEquipamento;
    [Tooltip("Não mexer - objeto do inventario para funcionar")] [SerializeField] ItemSegurar dropdownHud;
    GameObject[] slots = new GameObject[0];
    Item[] itens;
    float timeS;
     void Start()
     {

     }

    void Update()
    {
        if(timeS > Time.time)
        {
            scroll.value = 1;
        }
    }

    public void butInv()
    {
        backInventario.SetActive(true);
        inventario.SetActive(true);
        hudEquipamento.SetActive(false);
        AtualizarInv();
        hudItem.SetActive(false);
    }

    public void MostrarHud(string nome)
    {
        hudItem.SetActive(true);
        Item item = playerInv.ProcurarItem(nome);
        if (item != null)
        {
            botao.SetActive(false);
            if (nome.Contains("Cura"))
            {
                botao.SetActive(true);
            }
            this.nome.GetComponent<TextMeshProUGUI>().text = item.nome;
            if (item.tipos == Item.tipo.Item) {
                quantidade.GetComponent<TextMeshProUGUI>().text = "";
            }
            else
            {
                quantidade.GetComponent<TextMeshProUGUI>().text = "Quantidade: " + playerInv.ProcurarQuantidade(nome);
            }
            descricao.GetComponent<TextMeshProUGUI>().text = item.descricao;
            imagem.sprite = item.imagem;
            scroll2.value = 1;
        }
    }

    public void botaoUsarItem() 
    {
        if (nome.GetComponent<TextMeshProUGUI>().text.Contains("Cura"))
        {
            FindObjectOfType<Player>().Curar();
            AtualizarInv();
            quantidade.GetComponent<TextMeshProUGUI>().text = "Quantidade: " + playerInv.ProcurarQuantidade(nome.GetComponent<TextMeshProUGUI>().text);
            if (playerInv.ProcurarQuantidade(nome.GetComponent<TextMeshProUGUI>().text) <= 0) { hudItem.SetActive(false); }
        }
    }

    public void AtualizarInv()
    {
        if (playerInv == null) { Debug.Log("Sem inventario em GerenciarInventarioHUD"); return; }

        slots = new GameObject[playerInv.inventario.Count];

        // Limpar o inventario para colocar os itens novamente
        for (int a = 0; a < inventario.transform.childCount; a++)
        {
            Destroy(inventario.transform.GetChild(a).gameObject);
        }

        if (slots.Length > 0)
        {
            textSemItem.SetActive(false);
            itens = new Item[playerInv.inventario.Count];
            for (int a = 0; a < playerInv.inventario.Count; a++)
            {
                itens[a] = playerInv.inventario[a].item;
            }
            //Adiciona itens no inventario
            for (int a = 0; a < playerInv.inventario.Count; a++)
            {
                if (IgnorarTiposDeItens(itens[a].tipos))
                {
                    slots[a] = Instantiate(slotPrefab, inventario.transform);
                    slots[a].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itens[a].nome;
                    slots[a].transform.SetParent(inventario.transform);
                    if (itens[a].imagem) slots[a].transform.GetChild(1).GetComponent<Image>().sprite = itens[a].imagem;
                }
                else { Debug.Log("Ignorado no carregamento do inventario: " + itens[a].nome + " tipo: " + itens[a].tipos); }
            }
            if (hudEquipamento.activeSelf)
            {
                dropdownHud.AtualizarSlots();
            }
            timeS = Time.time + 0.1f;
        }
        else
        {
            textSemItem.SetActive(true);
        }
    }

    //Ignorar itens ao carregar inventario, ou seja não mostrar os itens;
    //true = mostrar, false = ocultar
    bool IgnorarTiposDeItens(Item.tipo tipo)
    {
        if (tipo == Item.tipo.Armas) { hudEquipamento.SetActive(true); return armas; }
        if (tipo == Item.tipo.Bateria) { return bateria; }
        if (tipo == Item.tipo.Circuito) { return circuito; }
        if (tipo == Item.tipo.Cura) { return cura; }
        if (tipo == Item.tipo.Iluminacoes) { hudEquipamento.SetActive(true); return iluminacao; } 
        if (tipo == Item.tipo.Injecao) { return injecao; }
        if (tipo == Item.tipo.Item) { return item; }
        if (tipo == Item.tipo.Outros) { return outros; }
        if (tipo == Item.tipo.Pregos) { return pregos; }
        if (tipo == Item.tipo.Puzzle) { return puzzle; }
        if (tipo == Item.tipo.SOS) { return sos; }
        if (tipo == Item.tipo.Documento) { return documentos; }

        else { return false; }
    }
}
