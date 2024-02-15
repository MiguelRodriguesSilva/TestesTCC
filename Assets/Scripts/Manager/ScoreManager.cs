using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreUI, comboUI;

    private void Awake() 
    {
        PlayerController.RecebeuScore += RecebendoValores;
    }

    void RecebendoValores(int score, int combo)
    {
        scoreUI.text = score.ToString();
        comboUI.text = combo.ToString();
    }
}
