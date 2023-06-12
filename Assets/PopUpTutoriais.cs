using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTutoriais : MonoBehaviour
{
    bool tocando;
    public GameObject canvas;
    int i = 0;
    // Start is called before the first frame update
    
    void Start()
    {
        //StartCoroutine(Aparece());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (tocando == true && i == 1)
        {
            StartCoroutine(Aprarece());
        }*/
        //Fechar();
    }

    IEnumerator Aprarece()
    {
        yield return new WaitForSeconds(0);
        canvas.SetActive(true);
        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);
    }

    public void Fechar()
    {
        canvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            i++;
            tocando = true;
            StartCoroutine(Aprarece());
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tocando = false;
        }
    }

}
