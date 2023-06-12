using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstrarIndicativo : MonoBehaviour
{
    public GameObject sinal;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //Quando entrar do collider o indicativo irá aparecer

            sinal.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //Quando sair do collider o indicativo irá sumir;

            sinal.SetActive(false);
        }
    }
}
