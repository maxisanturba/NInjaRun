using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilitiesTesting : MonoBehaviour
{
    public float[] values = new float[5] { 100, 50, 30, 20, 10 }; //Array {Probabilidades}
    private void Update()
    {
        Debug.Log(Choose(values));
    }

    float Choose(float[] probs) //funcion que retorna el elemento del array segun la probabilidad
    {

        float total = 0; //almacenará el total de los elementos del array

        foreach (float elem in probs) //por cada elemento en el array
        {
            total += elem; // añade a la variable "total" cada elemento. 
        }

        float randomPoint = Random.value * total; //eleccion aleatoria = elemento aleatorio * total de elementos.

        for (int i = 0; i < probs.Length; i++) //por cada elemento del array
        {
            if (randomPoint < probs[i]) 
            {
                return i; 
            }
            else 
            {
                randomPoint -= probs[i]; 
            }
        }
        return probs.Length - 1;
    }
}
