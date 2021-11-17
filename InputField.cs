using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputField : MonoBehaviour
{
    public int columna;
    public GameManager gm;
    public Contador cont;
    //public float tiempo = 0f;

    void OnMouseDown()
    {
        gm.seleccionarcolumna(columna);
        gm.turno(columna);
        //cont.tiempoturno(tiempo);
    }
}
