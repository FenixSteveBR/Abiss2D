using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MarcadorMapa : MonoBehaviour
{
    public GameObject comMapa, semMapa;

    public GameObject enfermaria, vestiarios, salaDeArma, refeitorio, cozinha, deposito, incubadora, salaCirurgia, salaSeguranca, servidores, salaTeste, salaFria, salaEnsaio, salaInjecao;

    
    public GameObject corredor1A, corredor1B, corredor1C, corredor1D, corredor2A, corredor2B, corredor3A, corredor3B;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesbloqueiaMapa()
    {
        semMapa.SetActive(false);
        comMapa.SetActive(true);
    }

    /*public void Enfermaria()
    {
        Debug.Log("Esta na enfermaria");
    }

    public void Vestiarios()
    {
        Debug.Log("Esta na Vestiarios");
    }

    public void SalaDeArma()
    {

    }

    public void Refeitorio()
    {

    }

    public void Cozinha()
    {

    }

    public void Deposito()
    {

    }

    public void Incubadora()
    {
        Debug.Log("Esta na Incubadora");
    }

    public void SalaCirurgia()
    {

    }

    public void SalaSeguranca()
    {

    }

    public void Servidores()
    {

    }

    public void SalaTeste()
    {

    }

    public void SalaFria()
    {

    }

    public void SalaEnsaio()
    {

    }

    public void SalaInjecao()
    {

    }*/





}
