using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Manager : MonoBehaviour
{
    Vector3 StartingPos;            //시작위치
    Quaternion StartingRotate;      //시작로테이트
    bool isStarted = false;         //시작지점인지!
    static bool isEnded = false;    //종료지점인지!

    //Scene index 를 저장할 변수
    static int stageLevel = 3;

    void Awake(){
        Time.timeScale = 0f;        //게임을 정지 시킨다.
    }
    
    void Start()
    {
        StartingPos = GameObject.FindGameObjectWithTag("start").transform.position;
        StartingRotate = GameObject.FindGameObjectWithTag("start").transform.rotation;

        if (stageLevel >3){
            StartGame();
        }
    }

    void OnGUI(){
            GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));      //시작

            GUILayout.BeginHorizontal();        //수평정렬
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();        //수직정렬
            GUILayout.FlexibleSpace();

        //현재 어느 스테이지에 있는지 알려주기 위한 GUI
        if (!isEnded && stageLevel < 6){
            GUILayout.Label(" Stage " + (stageLevel-2));
        }
        else{
            GUILayout.Label(" Stage End");
        }

            GUILayout.Space(5);
            GUILayout.EndVertical();        
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.EndArea();        //끝


        
        if (!isStarted && stageLevel == 3){    //게임 시작하고 첫 스테이지라면!
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
        else if (isEnded || stageLevel == 6){   //게임이 끝났다면!
            GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));      //시작
            GUILayout.BeginHorizontal();        //수평정렬
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();        //수직정렬
            GUILayout.FlexibleSpace();

            GUILayout.Label("<color=#000000>" + "게임종료!"+ "</color>");

            if (GUILayout.Button("<color=#000000>" + "restart?"+ "</color>")){
                isEnded = false;
                stageLevel = 3;
                SceneManager.LoadScene(3,LoadSceneMode.Single);
            
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();        
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();        //끝

        }
    }
    public static void EndGame(int health){       //게임이 종료되면!
        Time.timeScale = 0f;
        ++stageLevel;

        //생명력이 다 달아서 endgame된거면 시작 씬으로 돌아간다.
        if (health <= 0){
            isEnded = true;
        }
        // 마지막 씬에서 포탈에 닿은거면 게임종료!
        else if (stageLevel == 6){
            isEnded = true;
        }
        // 그냥 종료포탈에 닿은거면!
        else{
            SceneManager.LoadScene(stageLevel, LoadSceneMode.Single);   //다음 스테이지로 넘어간다!
        }
    }
    void StartGame(){       //게임시작하면!
        Time.timeScale = 1f;    //게임진행

    }
    
}
