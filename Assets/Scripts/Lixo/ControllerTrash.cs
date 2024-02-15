using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTrash : MonoBehaviour
{
    public int Direcao;

    private void Start() 
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("Direction", Direcao);
    }
}
