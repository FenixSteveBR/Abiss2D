using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaJanela : MonoBehaviour
{
    [SerializeField] bool portaBateria, portaMadeira;
    [SerializeField] Transform destination;
    [SerializeField] float tempo;
    Animator anim;
    GameObject player;
    bool utilizavel;
    Rect rect;
    Vector3 posicaoTela;
    bool pular;

    public GameObject interagir;

    private void Start()
    {
        anim = null;
        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && utilizavel)
        {
            if(anim != null){
                anim.SetBool("Aberta", true);
                anim.SetTrigger("Abrir");
            }
            StartCoroutine(Abrindo());
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        posicaoTela = Camera.main.WorldToScreenPoint(transform.position);
        if (col.CompareTag("Player"))
        {
            pular = true;
            player = col.gameObject;
            utilizavel = true;
        }
        if (pular == true)
        {
            interagir.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = null;
            utilizavel = false;
            pular = false;
        }
        if (pular == false)
        {
            interagir.SetActive(false);
        }
    }

    IEnumerator Abrindo()
    {
        player.GetComponent<Player>().SetParado(true);
        yield return new WaitForSeconds(tempo);
        player.transform.position = destination.position;
        player.GetComponent<Player>().SetParado(false);
        if (!portaBateria && anim != null)
        {
            anim.SetBool("Aberta", false);
        }
    }

    /*void OnGUI(){
        if(pular){
            rect = new Rect(new Vector2(posicaoTela.x + ((Screen.width) / 100), Screen.height - posicaoTela.y + ((Screen.height * +15) / 100)), new Vector2(500,450));
            GUI.skin.label.fontSize = ((Screen.width + Screen.height) * 2) / 170;
            GUI.Label(rect, "Pular Janela");
        }else{
            GUI.Label(rect, "");
        }
    }*/
}
