using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SpawnLixos spawns;
    [SerializeField] float tempoClicar;
    
    bool podeClicar = false;
    public int combo = 0;
    public int pontuacao = 0;
    public int botaoCerto = 0;


    public delegate void GetScore(int scr, int cmb);
    public static event GetScore RecebeuScore;

    private void Awake() 
    {
        Lixos.LataSpawnada += LataFoiSpawnada;
        LixoManager.BotaoMudou += MudarBotao;
    }
    private void Update() 
    {
        tempoClicar += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            BotaoDireita();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BotaoEsquerda();
        }
    }

    public void BotaoDireita() 
    {
        if (podeClicar)
        {
            if (botaoCerto == 1)
            {
                combo++;
                podeClicar = false;
                Score();
            }
            else
            {
                combo = 0;
            }
            if (RecebeuScore != null)
            {
                RecebeuScore(pontuacao,combo);
            }
            
        }
    }

    public void BotaoEsquerda()
    {
        if (podeClicar)
        {
            if (botaoCerto == 0)
            {
                combo++;
                podeClicar = false;
                Score();
            }
            else
            {
                combo = 0;
            }
            if (RecebeuScore != null)
            {
                RecebeuScore(pontuacao,combo);
            }
            
        }
    }

    public void Score()
    {
        if (tempoClicar > 0.35f && tempoClicar < 0.75f)
            {
                pontuacao += 20;
            }
            else
            {
                pontuacao += 5;
            }
    }

    void MudarBotao(int qualBotao)
    {
        botaoCerto = qualBotao;
    }

    void LataFoiSpawnada(bool pc)
    {
        podeClicar = pc;
        tempoClicar = 0;
    }
}
