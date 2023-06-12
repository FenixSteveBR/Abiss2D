using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Reator : MonoBehaviour
{
    public Light2D[] luzes;
    bool podeInteragir = false;
    public bool geradorLigado;
    public GameObject interagir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (podeInteragir = true && Input.GetKeyDown(KeyCode.E))
        {
            Ligar();
            geradorLigado = true;
        }
        if (geradorLigado)
        {
            podeInteragir = false;
        }
    }
    public void Ligar()
    {
        foreach (Light2D luz in luzes)
        {
            luz.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            podeInteragir = true;
            interagir.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            podeInteragir = false;
            interagir.SetActive(false);
        }
    }
}
