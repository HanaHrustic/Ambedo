﻿using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera cam;
    

    public static int KeyCount = 0;


    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = cam.transform.right * Input.GetAxis("Horizontal") + cam.transform.forward * Input.GetAxis("Vertical");
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.gameObject.GetComponent<EnemyHealth>().TakeDamage();
                    if(enemiesKilled == 3)
                    {
                        foreach (Transform child in spiderWall.transform)
                        {
                            child.GetComponent<MeshRenderer>().enabled = false;
                            child.GetComponent<MeshCollider>().enabled = false;
                        }

                        if (Key != null)
                        {
                            foreach (Transform child in Key.transform)
                            {
                                child.GetComponent<MeshRenderer>().enabled = true;
                                child.GetComponent<BoxCollider>().enabled = true;
                            }
                        }


                    }
                    if (enemiesKilled == 4)
                    {
                        foreach (Transform child in monsterWall.transform)
                        {
                            child.GetComponent<MeshRenderer>().enabled = false;
                            child.GetComponent<MeshCollider>().enabled = false;
                        }

                        if (Key2 != null)
                        {
                            foreach (Transform child in Key2.transform)
                            {
                                child.GetComponent<MeshRenderer>().enabled = true;
                                child.GetComponent<BoxCollider>().enabled = true;
                            }
                        }
                    }
                    if (enemiesKilled == 5)
                    {
                        foreach (Transform child in lastWall.transform)
                        {
                            child.GetComponent<MeshRenderer>().enabled = false;
                            child.GetComponent<MeshCollider>().enabled = false;
                        }

                        if (Key3 != null)
                        {
                            foreach (Transform child in Key3.transform)
                            {
                                child.GetComponent<MeshRenderer>().enabled = true;
                                child.GetComponent<BoxCollider>().enabled = true;
                            }
                        }
                    }
                }
            }
        }*/
    }
}