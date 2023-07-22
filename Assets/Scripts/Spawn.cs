using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

public GameObject enemigoPrefab; 
public Transform puntoSpawn; 
//public int tiempoInicial = 120; 
//public int tiempoMinimo = 10; 
//public float decrementoTiempo = 5f;
//public float respawnDistance=2f;
int cantSpawn=1;
float tiempoActual = 10;
public int nivel=3;
private List<string> tagList = new List<string>();
private string randomTag;
private string randomSelectedTag;
void Start()
    {
        tagList.Add("S1");
        tagList.Add("S2");
        tagList.Add("S3");
        tagList.Add("S4");
        tagList.Add("S5");
       // tagList.Add("S6");
      //  tagList.Add("S7");
       // tagList.Add("S8");
        //tagList.Add("S9");
        //tagList.Add("S10");
        // Elige una etiqueta aleatoriamente

        StartCoroutine(GenerarHordas());
    }
public string GetRandomTag(List<string> tagList )
    {
        // Verifica si la lista de etiquetas no está vacía
        if (tagList.Count == 0)
        {
            Debug.LogWarning("La lista de etiquetas está vacía.");
            return null;
        }
        // Selecciona un índice aleatorio de la lista de etiquetas
        int randomIndex = Random.Range(0, tagList.Count);

        // Obtiene la etiqueta aleatoria usando el índice seleccionado
       randomTag = tagList[randomIndex];

        return randomTag;
    }
    IEnumerator GenerarHordas()
    {   
        int gatillo=1;
     while( gatillo<2){
           while (cantSpawn<1)
            {
            yield return new WaitForSeconds(tiempoActual);
            
            SpawnEnemigo();
            cantSpawn +=1;
            } 
            yield return new WaitForSeconds(tiempoActual);

            SpawnEnemigo();
            nivel +=1;
            cantSpawn=1;
        }
        
    }

    void SpawnEnemigo()
    {
        randomSelectedTag = GetRandomTag(tagList);
        // Obtiene el GameObject con la etiqueta aleatoria seleccionada
        GameObject randomObject = GameObject.FindGameObjectWithTag(randomSelectedTag);
        Transform objectTransform = randomObject.transform;
        // Obtiene la posición del GameObject a través de su componente Transform
        Vector3 objectPosition = objectTransform.position;
        //Vector2 randomPosition= Random.insideUnitCircle.normalized*respawnDistance;
        if(nivel==1){

        enemigoPrefab = GameObject.FindGameObjectWithTag("L1");
        Instantiate(enemigoPrefab, objectPosition, Quaternion.identity);

        }else if(nivel==2){

        enemigoPrefab = GameObject.FindGameObjectWithTag("Enemigos");
        Instantiate(enemigoPrefab, objectPosition, Quaternion.identity);

        }else if(nivel==3){

        enemigoPrefab = GameObject.FindGameObjectWithTag("L3");
        Instantiate(enemigoPrefab, objectPosition, Quaternion.identity);

        }else if(nivel==4){

        enemigoPrefab = GameObject.FindGameObjectWithTag("L4");
        Instantiate(enemigoPrefab, objectPosition, Quaternion.identity);

        }else{

        enemigoPrefab = GameObject.FindGameObjectWithTag("L5");
        Instantiate(enemigoPrefab, objectPosition, Quaternion.identity);

        }
    }




    // Start is called before the first frame update
        //Edicion
   /* public float trespawn=15f;
    public Transform spawnpoint;
    public GameObject Vampire;
    public float respawnDistance=5f;
    public int enemigosmax=15;

    void Start()
    {
        
            InvokeRepeating("SpawnEnemies",20f,trespawn);
        
       
    }

   void SpawnEnemies()
    {
        Vector2 randomPosition= Random.insideUnitCircle.normalized*respawnDistance;
        Vector3 spawnposition=spawnpoint.position + new Vector3(randomPosition.x,0f,randomPosition.y);
        Instantiate(Vampire,spawnposition,spawnpoint.rotation);
    }  */
}
