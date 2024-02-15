using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixos : MonoBehaviour
{
    public delegate void PodeClicar(bool podeClicar);
    public static event PodeClicar LataSpawnada;
    [SerializeField] float tempoDesaparecer;

    private void Start() 
    {
        if (LataSpawnada != null)
        {
            LataSpawnada(true);
        }
        StartCoroutine(TempoDestroy());
    }

    IEnumerator TempoDestroy()
    {
        yield return new WaitForSeconds(tempoDesaparecer);
        if (LataSpawnada != null)
        {
            LataSpawnada(false);
        }
        Destroy(this.gameObject);
    }
}
