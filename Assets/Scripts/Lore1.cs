using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lore1 : MonoBehaviour
{
    public void continuar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
    }
}
