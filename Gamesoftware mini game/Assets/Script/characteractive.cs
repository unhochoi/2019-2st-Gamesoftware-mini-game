using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class characteractive : MonoBehaviour
{

    public float movePower = 1f;    //좌우속도
    public float jumpPower = 1f;    //점프속도
    public int maxHealth = 3;       //최대 생명력


    Rigidbody2D rigid;
    Animator animator;

    SpriteRenderer spriteRenderer;

    Vector3 movement;      
    bool isDie = false;     //플레이어 사망
    bool isJumping = false;     //점프 상태
    bool isUnBeatTime = false;
    int health = 3;     //현재 생명력
    
    // Start is called before the first frame update
    

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        health = maxHealth;     //게임 시작될 때마다 현재 체력을 최대 체력으로 셋팅
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow)){     //점프키가 눌리면 

            if (rigid.velocity.y == 0 ){        //땅에 착지했을때만 점프 가능!
                isJumping = true;
            }
        }
           
    }
    
    void FixedUpdate(){

        Move();
        Jump();
        
    }

    void Die(){     //사망함수 
        isDie = true;
        transform.position = new Vector3(0.0f, 1.7f, 0.0f);

    }

    
    void Move(){        //이동 함수
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal")<0 ){          //왼쪽으로 움직인다.
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1,1,1);
        }
        else if(Input.GetAxisRaw("Horizontal") >0){     //오른쪽으로 움직인다.
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1,1,1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump(){        //점프 함수
        if (!isJumping){    //점프가 아니라면 빠져나감
            return;
        }

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0,jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;      //점프 했으니 false 만듦
    }
    
void OnTriggerEnter2D(Collider2D other)
    {
        
        //장애물을 만나게 되면
        if (other.gameObject.tag == "Mushroom" )
        {
            
            //넉백
            Vector2 killVelocity = new Vector2(-7f, 5f);
            rigid.AddForce(killVelocity, ForceMode2D.Impulse);

            health--;       //생명력 감소
            
            //무적타임이라는 bool 변수 선언 후 피격 당할 때 마다 활성화 
            if(health >0){
                isUnBeatTime = true;
                StartCoroutine("UnBeatTime");
            }

            if(health <=0){     //생명력이 다 떨어지면 게임종료
                other.enabled = false;
                Game_Manager.EndGame(health);
            }
        }
        //종료포탈에 닿으면
        if (other.gameObject.tag == "end" )
        {
            other.enabled = false;
            Game_Manager.EndGame(health);
            
        }
        //아래로 떨어지면
        if (other.gameObject.tag == "falldown" )
        {
            other.enabled = false;
            health = 0;
            Game_Manager.EndGame(health);
        }
        
    }
 
 IEnumerator UnBeatTime(){

     int countTime = 0;
     while (countTime < 3){
         if (countTime%2 == 0){
             spriteRenderer.color = new Color32(255,255,255,90);
         }else{
             spriteRenderer.color = new Color32(255,255,255,180);
         }

         yield return new WaitForSeconds(0.2f);
         countTime++;
     }
     spriteRenderer.color = new Color32(255,255,255,255);
     isUnBeatTime = false;
     yield return null;
 }

 void OnGUI(){      //생명력 상태 표시 
     GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
     GUILayout.BeginVertical();
     GUILayout.Space(10);
     GUILayout.BeginHorizontal();
     GUILayout.Space(15);

     string heart = "";
     for (int i=0; i<health;i++){
         heart += "<color=#ff0000>" + "♥ " + "</color>";

     }
     GUILayout.Label(heart);

     GUILayout.FlexibleSpace();
     GUILayout.EndHorizontal();
     GUILayout.FlexibleSpace();
     GUILayout.EndVertical();
     GUILayout.EndArea();
 }
    



}
