using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Text contador;
    public float tiempo = 0f;
    // Start is called before the first frame update
    

    public void tiempoturno(float tiempo = 0f)
    {
        tiempo = 0f;
        contador.text = " " + tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        contador.text = " " + tiempo.ToString("f0");
    }
}
