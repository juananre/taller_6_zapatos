using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class BasicTouch : MonoBehaviour
{
    public Camera mainCamera;

    [SerializeField] TMP_Text timer;
    
    [SerializeField] int cambio_estado = 0;

    [SerializeField] int min, seg;

    private float restante;

    [SerializeField] GameObject insulto_1;
    [SerializeField] GameObject insulto_2;
    [SerializeField] GameObject insulto_3;
    [SerializeField] GameObject insulto_4;
    [SerializeField] GameObject insulto_5;
    [SerializeField] GameObject insulto_6;
    [SerializeField] GameObject insulto_7;
    [SerializeField] GameObject insulto_8;
    [SerializeField] GameObject insulto_9;
    [SerializeField] GameObject oscuridad_1;
    [SerializeField] GameObject oscuridad_2;
    [SerializeField] GameObject oscuridad_3;
    [SerializeField] GameObject oscuridad_4;
    [SerializeField] GameObject oscuridad_5;

    [SerializeField] int escena;

    [SerializeField] int puntaje;
    [SerializeField] int necesario;



    [SerializeField] Transform mapa;
    

    bool verifi=false;
    private int velicidad=0;
    private int quieto1 = 960;
    private int quieto2 = 540;
    
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

        
        if (Input.GetKeyDown(KeyCode.Space) || puntaje== necesario || restante < 0)
        {
            SceneManager.LoadScene(escena);
        }
       
    }
    private void FixedUpdate()
    {
        if (verifi == true)
        {
            restante -= Time.deltaTime;
            int tempmin = Mathf.FloorToInt(restante / 60);
            int tempseg = Mathf.FloorToInt(restante % 60);
            timer.text = string.Format("{00:00}:{01:00}", tempmin, tempseg);

        }
    }
    public void Awake()
    {
        restante = (min * 60) + seg;
    }

    void TouchPhaser() {

        if (Input.touchCount > 0) {
            Touch t = Input.GetTouch(0);


            if (t.phase == TouchPhase.Began) {

               
                velicidad -=80;
                mapa.position = new Vector3(quieto1, velicidad, quieto2);
                puntaje++;
                //Debug.Log("Tap");
            }
            if (t.phase == TouchPhase.Moved)
            {
                //Debug.Log("Moviendo");
            }
            if (t.phase == TouchPhase.Ended)
            {
                //Debug.Log("Levantó");
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
        if (puntaje == 15)
        {
            
            insulto_2.SetActive(true);
        }
        if (puntaje == 20)
        {
            
            insulto_2.SetActive(true);
        }
        if (puntaje == 30)
        {
           
            insulto_4.SetActive(true);
        }
        if (puntaje == 45)
        {
            oscuridad_1.SetActive(true);
            insulto_5.SetActive(true);
        }
        if (puntaje == 60)
        {
            oscuridad_1.SetActive(false);
            oscuridad_2.SetActive(true);
            insulto_6.SetActive(true);
        }
        if (puntaje == 70)
        {
            oscuridad_2.SetActive(false);
            oscuridad_3.SetActive(true);
            insulto_6.SetActive(true);
        }
        if (puntaje == 80)
        {
            oscuridad_3.SetActive(false);
            oscuridad_4.SetActive(true);
            insulto_7.SetActive(true);
        }
        if (puntaje == 88)
        {
            oscuridad_4.SetActive(false);
            oscuridad_5.SetActive(true);
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
