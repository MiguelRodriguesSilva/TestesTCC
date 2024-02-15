using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baude : MonoBehaviour
{
    [SerializeField] float tempoDesaparecer;

    private void Start() 
    {
        StartCoroutine(TempoDestroy());
    }

    IEnumerator TempoDestroy()
    {
        yield return new WaitForSeconds(tempoDesaparecer);
        Destroy(this.gameObject);
    }
}
