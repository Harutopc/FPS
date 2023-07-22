using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lore2 : MonoBehaviour
{
    public void continuar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
    }
}
