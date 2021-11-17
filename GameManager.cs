using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string debugStartMessage;
    public GameObject jugador1;
    public GameObject jugador2;
    public GameObject circulogana;
    public GameObject[] spawnpoints;
    public Contador turn;
    public float tiempo1 = 0;
    public float tiempo2 = 0;
    public int n = 6;
    public int m = 7;


    bool turnjugador1 = true;
    int[,] tablero;//0 sera vacio, 1 sera jugador 1 y 2 sera jugador 2

    void Start()
    {
        tablero = new int[m, n];
    }

    public void seleccionarcolumna(int columna)
    {
        Debug.Log("Gamemanager columna " + columna);
        
    }

    public void turno(int columna)
    {
        if (actualizartablero(columna))
        {
            if (turnjugador1==true)
            {
                Instantiate(jugador1, spawnpoints[columna].transform.position, Quaternion.identity);
                turnjugador1 = false;
                if (gano(1))
                {
                    Debug.LogWarning("Gano jugador 1");
                }
                //tiempo1 = turn.tiempo + tiempo1;
                //Debug.Log("tiempo turno 1 " + tiempo1);
            }
            else
            {
                Instantiate(jugador2, spawnpoints[columna].transform.position, Quaternion.identity);
                turnjugador1 = true;
                if (gano(2))
                {
                    Debug.LogWarning("Gano jugador 2");
                }
                //tiempo2 = turn.tiempo + tiempo2;
                //Debug.Log("tiempo turno 1 " + tiempo2);
            }
            if (empato())
            {
                Debug.LogWarning("Se empato el juego");
            }
        }
        
        
    }
    bool actualizartablero(int columna)
    {
        for (int i = 0; i < n; i++)
        {
            if (tablero[columna,i] == 0)//cuando esta vacio el lugar
            {
                if (turnjugador1)
                {
                    tablero[columna, i] = 1;
                }
                else
                {
                    tablero[columna, i] = 2;
                }
                Debug.Log("ficha generada en (" + columna + "," + i + ")");
                return true;
            }
            
        }
        Debug.LogWarning("La columna " + columna + " esta llena");
        return false;
    }
    bool gano(int jugador)
    {
        //Horizontal
        for (int x = 0; x < m-3; x++)
        {
            for (int y = 0; y < n; y++)
            {
                if (tablero[x,y]==jugador && tablero[x+1,y]==jugador && tablero[x+2, y] == jugador && tablero[x+3, y] == jugador)
                {
                    Instantiate(circulogana, new Vector3(x-3, y, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x-4, y, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x-5, y, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x-6, y, 0), Quaternion.identity);
                    return true;
                }
            }
        }
        //vertical
        for (int x = 0; x < m; x++)
        {
            for (int y = 0; y < n-3; y++)
            {
                if (tablero[x,y]==jugador && tablero[x,y+1]==jugador && tablero[x, y+2] == jugador && tablero[x, y + 3] == jugador)
                {
                    Instantiate(circulogana, new Vector3(x-6, y, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x-6, y+1, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x-6, y+2, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x-6, y+3, 0), Quaternion.identity);
                    return true;
                }
            }
        }
        //diagonal x=y principal
        for (int x = 0; x < m-3; x++)
        {
            for (int y = 0; y < n-3; y++)
            {
                if (tablero[x, y] == jugador && tablero[x+1, y + 1] == jugador && tablero[x+2, y + 2] == jugador && tablero[x+3, y + 3] == jugador)
                {
                    Instantiate(circulogana, new Vector3(x-6, y, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x -5, y+1, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x -4, y+2, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x -3, y+3, 0), Quaternion.identity);
                    return true;
                }
            }
        }
        //diagonal x=-y secundaria
        for (int x = 0; x < m - 3; x++)
        {
            for (int y = 0; y < n - 3; y++)
            {
                if (tablero[x, y+3] == jugador && tablero[x + 1, y + 2] == jugador && tablero[x + 2, y + 1] == jugador && tablero[x + 3, y] == jugador)
                {
                    Instantiate(circulogana, new Vector3(x-6, y+3, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x -5, y + 2, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x -4, y + 1, 0), Quaternion.identity);
                    Instantiate(circulogana, new Vector3(x -3, y, 0), Quaternion.identity);
                    return true;
                }
            }
        }
        return false;
    }
    bool empato()
    {
        for (int x = 0; x < m; x++)
        {
            if (tablero[x,n-1]==0)
            {
                return false;
            }
        }
        return true;
    }
}
