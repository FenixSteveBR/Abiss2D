using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaCanvasPassagem : MonoBehaviour
{
    public GameObject Interagir, player;
    public bool tocando;
    // Start is called before the first frame update
    void Start()
    {
        tocando = false;
    }

    // Update is called once per frame
    void Update()
    {
    //    if (tocando == true)
    //    {
    //        Interagir.SetActive(true);
    //    }
    //    else Interagir.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && player.GetComponent<Player>().PdAgachar == true)
        {
            
            //tocando = true;
            Interagir.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //tocando = false;
            Interagir.SetActive(false);
        }
    }
}
