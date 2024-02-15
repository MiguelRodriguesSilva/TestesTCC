using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLixo : MonoBehaviour
{
    public int direcao, lixo;
    [SerializeField] GameObject[] prefBaudes;

    private void Awake() 
    {
        SpawnLixos.LixoDecidido += Lixo;
    }

    void Lixo(int qualLixo, int qualDirecao)
    {
        if (qualDirecao == direcao)
        {
            GameObject certo = Instantiate(prefBaudes[qualLixo], transform.position, Quaternion.identity);
            if (certo.TryGetComponent(out ControllerTrash c))
            {
                c.Direcao = direcao;
            }
        }
        else
        {
            int outroLixo = Random.Range(0,4);
            while(outroLixo == qualLixo)
            {
                outroLixo = Random.Range(0,4);
            }
            GameObject errado = Instantiate(prefBaudes[outroLixo], transform.position, Quaternion.identity);
            if (errado.TryGetComponent(out ControllerTrash t))
            {
                t.Direcao = direcao;
            }
        }
    }
}