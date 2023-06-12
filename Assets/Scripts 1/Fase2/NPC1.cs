using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    public void AnimacaoIdle()
    {
        anim.SetBool("Idle", true);
    }
    public void Anima��oAmeacar()
    {
        anim.SetBool("Ameaca", true);
    }

    public void Anima��oParada()
    {
        anim.SetBool("Ameaca", false);
    }

    public void AnimSegundoEncontro()
    {
        anim.SetBool("SegundoEncontro", true);
    }

    public void AnimLevantando()
    {
        anim.SetBool("Levantando", true);
    }

}
