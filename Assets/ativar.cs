using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ativar : MonoBehaviour
{
    public PlayableDirector timeline;
    GameObject player;
    public GameObject abrirCanvas;
    bool podeInteragir;
    int d = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        abrirCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            timeline.Play();
            d++;
         }
        if (d >= 1)
        {
            
        }
    }
    void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                abrirCanvas.SetActive(true);
            podeInteragir = true;
            
            }

        }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            abrirCanvas.SetActive(false);
            podeInteragir = false;
        }
    }
}
