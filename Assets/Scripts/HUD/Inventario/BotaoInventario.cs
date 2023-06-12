using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotaoInventario : MonoBehaviour
{
    public enum tipos { Inventario, Documento}
    GerenciarInventarioHUD inv;
    GerenciarDocumentosHUD doc;
    public tipos tipo;
    void Start()
    {
        if (tipo.Equals(tipos.Inventario))
        {
            inv = GameObject.FindGameObjectWithTag("Inventario").GetComponent<GerenciarInventarioHUD>();
        }else if (tipo.Equals(tipos.Documento))
        {
            doc = GameObject.FindGameObjectWithTag("Documentacao").GetComponent<GerenciarDocumentosHUD>();
        }
    }

    public void botao(Button btn)
    {
        if (tipo.Equals(tipos.Inventario))
        {
            inv.MostrarHud(btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
        }
        else if (tipo.Equals(tipos.Documento))
        {
            doc.MostrarHud(btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
        }
    }
}
