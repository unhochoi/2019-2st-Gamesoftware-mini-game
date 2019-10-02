using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static void RestartStage(){
            Time.timeScale = 0f;
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            
        }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
