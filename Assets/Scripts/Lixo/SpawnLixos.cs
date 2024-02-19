using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpawnLixos : MonoBehaviour
{
    public float[] momentosQueLixoSpawna;
    public int indexSpawn = 0;
    [SerializeField] GameObject[] prefLixo;
    public GameObject localSpawn;
    public float cont, tempoAntes, quandoMusicaComeca;
    [SerializeField] PlayableDirector pd;
    
    public delegate void QualLixoVaiSerSpawnado(int qualLixo, int qualDirecao);
    public static event QualLixoVaiSerSpawnado LixoDecidido;

    private void Update() 
    {
        if (pd.time > ((momentosQueLixoSpawna[indexSpawn] + quandoMusicaComeca) - tempoAntes))
        {
            int lixoSpawn = Random.Range(0,4);
            int direcaoLixo = Random.Range(0,2);
            if (LixoDecidido != null)
            {
                LixoDecidido(lixoSpawn, direcaoLixo);
            }

            Instantiate(prefLixo[lixoSpawn], localSpawn.transform.position, Quaternion.identity);
            indexSpawn++;
            
        }
    }
}
