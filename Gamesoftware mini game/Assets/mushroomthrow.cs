﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomthrow : MonoBehaviour
{

    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -18.55f){
            transform.position = new Vector3(0.5256591f,2.435f,-9.880508f);

        }else{
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
          if(other.tag.Equals("Player")){ //부딪힌 객체가 적인지 검사합니다.
              transform.position = new Vector3(0.5256591f,2.435f,-9.880508f);
          }
    }

    

}
