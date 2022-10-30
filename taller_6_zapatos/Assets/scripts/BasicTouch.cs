using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class BasicTouch : MonoBehaviour
{
    public Camera mainCamera;
    
    [SerializeField] GameObject insulto_1;
    [SerializeField] GameObject insulto_2;
    [SerializeField] GameObject insulto_3;
    [SerializeField] GameObject insulto_4;
    [SerializeField] GameObject insulto_5;
    [SerializeField] GameObject insulto_6;
    [SerializeField] GameObject insulto_7;
    [SerializeField] GameObject insulto_8;
    [SerializeField] GameObject insulto_9;

    [SerializeField] int escena;

    [SerializeField] int puntaje;
    [SerializeField] int necesario;

    [SerializeField] float timer;

    bool verifi=false;

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        //InstanciaCubos();
    }

    /*void InstanciaCubos() {
        cubitos = new GameObject[10];

        for (int i = 0; i < cubitos.Length; i++)
        {
            GameObject tempo = Instantiate(cubobase);
            cubitos[i] = tempo;
        }
    }*/


    // Update is called once per frame
    void Update()
    {

        //FollowFinger();
        //FollowFingerssss();
        insultos();
        TouchPhaser();

        if (Input.GetKeyDown(KeyCode.Space) ||puntaje== necesario || timer<=0)
        {
            SceneManager.LoadScene(escena);
        }

    }
    private void FixedUpdate()
    {
        if (verifi == true)
        {
            timer -= Time.deltaTime;
        }
    }


    void TouchPhaser() {

        if (Input.touchCount > 0) {
            Touch t = Input.GetTouch(0);


            if (t.phase == TouchPhase.Began) {
                puntaje++;
                Debug.Log("Tap");
            }
            if (t.phase == TouchPhase.Moved)
            {
                Debug.Log("Moviendo");
            }
            if (t.phase == TouchPhase.Ended)
            {
                Debug.Log("Levantó");
            }
        }

    }

    void insultos()
    {
        verifi = true;
        if (puntaje == 5)
        {
            
            insulto_1.SetActive(true);
        }
        if (puntaje == 20)
        {
            insulto_2.SetActive(true);
        }
        if (puntaje == 30)
        {
            insulto_3.SetActive(true);
        }
        if (puntaje == 40)
        {
            insulto_4.SetActive(true);
        }
        if (puntaje == 60)
        {
            insulto_5.SetActive(true);
        }
        if (puntaje == 70)
        {
            insulto_6.SetActive(true);
        }
        if (puntaje == 80)
        {
            insulto_6.SetActive(true);
        }
        if (puntaje == 85)
        {
            insulto_7.SetActive(true);
        }
        if (puntaje == 88)
        {
            insulto_8.SetActive(true);
        }
        if (puntaje == 90)
        {
            insulto_9.SetActive(true);
        }
    }

    /*void FollowFinger()
    {

        if (Input.touchCount > 0)
        {
            pos = mainCamera.ScreenToWorldPoint(
                new Vector3(Input.GetTouch(0).position.x,
                Input.GetTouch(0).position.y,
                10));

            cubobase.transform.position = pos;
        }
    }

    void FollowFingerssss()
    {

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Vector3 tempV = mainCamera.ScreenToWorldPoint(
                                new Vector3(Input.GetTouch(i).position.x,
                                Input.GetTouch(i).position.y,
                                10));
                cubitos[i].transform.position = tempV;
            }


        }
    }*/
}
