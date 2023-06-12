using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DetecPlayer : MonoBehaviour
{
    bool tocando, ativou;
    public PlayableDirector playableDirector;
    int n = 0;
    
    // Start is called before the first frame update
    void Start()
    {
                
    }

    


    // Update is called once per frame
    void Update()
    {
        if (tocando == true && n == 1 && ativou == false)
        {
            AtivaApari��o();
        }
    }

    public void AtivaApari��o()
    {
        ativou = true;
       
        playableDirector.Play();

        SalvarInformacoes.EscreverLinha("Ativou a apari��o, agora se ele viu � outros quinhentos");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) 
        {
            n++;
            tocando = true;
        }
    }
}
