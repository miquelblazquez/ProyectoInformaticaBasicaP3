using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;

    public int Health;

    public int vidaMaxima;

    // Update is called once per frame
    void Update()
    {
        barraDeVida.fillAmount = Health / vidaMaxima;
    }
}
