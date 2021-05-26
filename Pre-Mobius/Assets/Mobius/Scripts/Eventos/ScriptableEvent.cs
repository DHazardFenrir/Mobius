using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Evento", menuName = "Eventos/EventoNuevo", order = 1)]
public class ScriptableEvent : ScriptableObject
{
    public string entradaDelDiario;
    [Range(0,600)] public float horaDeActivacion;

}
