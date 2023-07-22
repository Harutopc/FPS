using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider=GetComponent<Slider>();
    }

    public void CambiarvidaMaxima(float vidaMaxima)
    {
        slider.maxValue=vidaMaxima;
    }

    public void CambiarvidaActual(float cantidadVida)
    {
        slider.value=cantidadVida;
    }
    public void InicializarBarra(float cantidadVida)
    {
        CambiarvidaMaxima(cantidadVida);
        CambiarvidaActual(cantidadVida);
    }

}
