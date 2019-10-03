using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Manager : MonoBehaviour
{

    //public GameObject player;

    Vector3 StartingPos;
    Quaternion StartingRotate;
    bool isStarted = false;
    static bool isEnded = false;

    void Awake(){
        Time.timeScale = 0f;        //게임을 정지 시킨다.
    }
    
 
    
    // Start is called before the first frame update

    void Start()
    {
    }

    void OnGUI(){

        if (!isStarted){    //게임 시작하면
            //영역 크기는 화면 전체로
            GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));      //시작

            GUILayout.BeginHorizontal();        //수평정렬
            GUILayout.FlexibleSpace();

            GUILayout.BeginVertical();        //수직정렬
            GUILayout.FlexibleSpace();

            GUILayout.Label("<color=#000000>" + "준비됐나요? " + "</color>");

            if (GUILayout.Button("<color=#000000>" + "start!"+ "</color>")){
                isStarted = true;
                StartGame();
            
            }
            
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();        
            

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.EndArea();        //끝
        }
        else if (isEnded){
            GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));      //시작
            GUILayout.BeginHorizontal();        //수평정렬
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();        //수직정렬
            GUILayout.FlexibleSpace();

            GUILayout.Label("<color=#000000>" + "게임종료!"+ "</color>");

            if (GUILayout.Button("<color=#000000>" + "restart?"+ "</color>")){
                SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);     //신을 다시 불러온다.
                isEnded = false;
            
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();        
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();        //끝

        }
    }
    public static void EndGame(){       //게임이 종료되면!
        Time.timeScale = 0f;
        isEnded = true;
    }
    void StartGame(){       //게임시작하면!
        Time.timeScale = 1f;    //게임진행

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
