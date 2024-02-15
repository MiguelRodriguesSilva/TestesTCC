using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoManager : MonoBehaviour
{
    public delegate void MudarBotao(int qualBotao);
    public static event MudarBotao BotaoMudou;

    int lixo, direcao;

    void Awake()
    {
        SpawnLixos.LixoDecidido += LixoEscolhido;
    }

    void LixoEscolhido(int qualLixo, int qualDirecao)
    {
        lixo = qualLixo;
        direcao = qualDirecao;
        
        if (BotaoMudou != null)
        {
            BotaoMudou(qualDirecao);
        }
    }
}
