﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public Animator Anime;
    public Rigidbody2D PlayerRigidbody2D;
    public int ForceJump;

    public bool Slide;

    //Verifica se está tocando no ground
	private bool isGrounded;

    public Transform GroundCheck;
    public LayerMask WhatIsGround;

    //Slide
    public float SlideTemp;
	private float timetemp;

	//Colisor
	public Transform colisor;

    // Use this for initialization
    private void Start(){
		
    }

    // Update is called once per frame
    private void Update(){
		
		isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, WhatIsGround);

        if ((Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && isGrounded){
		//if (Input.GetMouseButtonDown(0) && isGrounded){
            PlayerRigidbody2D.AddForce(new Vector2(0, ForceJump));

			if (Slide) {
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.5f, colisor.position.z);
				Slide = false;
			}
		}else //if (Input.GetMouseButtonDown(1) && isGrounded && !Slide){
			if (Input.GetButtonDown("Slide") || (Input.touchCount > 0 && Input.GetTouch(0).deltaPosition.x >= 0.5) && isGrounded && !Slide){
			colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.5f, colisor.position.z);
            Slide = true;
            timetemp = 0;
        }

        if (Slide){
            timetemp += Time.deltaTime;

            if (timetemp >= SlideTemp){
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.5f, colisor.position.z);
                Slide = false;
            }
        }

        Anime.SetBool("Jump", !isGrounded);
        Anime.SetBool("Slide", Slide);
    }

	void OnTriggerEnter2D(Collider2D collider2D){

		//Debug.Log ("Bateu!" + collider2D.name);
	    if(collider2D.gameObject.name.StartsWith("Hurdle") )
		     Application.LoadLevel("GameOver");
	}
		
}
                 