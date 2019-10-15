using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomthrow : MonoBehaviour
{

    //속도 지정
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //투사체는 수평으로 날라가며 일정 위치를 넘어가면 시작 위치로 돌아간다.
        if (transform.position.x < -18.55f){
            transform.position = new Vector3(0.56f,2.5f,-9.880508f);

        }else{
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
          if(other.tag.Equals("Player")){ //부딪힌 객체가 적인지 검사하고 적이면 시작 위치로 돌아온다.
            transform.position = new Vector3(0.56f,2.5f,-9.880508f);
          }
    }

    

}
