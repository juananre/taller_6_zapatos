using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class Touch2 : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    [SerializeField] int escena;
    [SerializeField] int cambio_estado = 0;

    [SerializeField] int min, seg;

    private float restante;

    [Header("-- posiciones")]
    [SerializeField] Transform pocision1;
    [SerializeField] Transform pocision2;
    [SerializeField] Transform pocision3;
    [SerializeField] Transform pocision4;
    [SerializeField] Transform pocision5;

    [Header("--usuario")]
    [SerializeField] GameObject usuario;
    [Header("-- carteles")]
    [SerializeField] GameObject cartel1;
    [SerializeField] GameObject cartel2;
    [SerializeField] GameObject cartel3;
    [SerializeField] GameObject cartel4;
    [SerializeField] GameObject cartel5;

    [Header("-- luces")]
    [SerializeField] GameObject luz2;
    [SerializeField] GameObject luz3;
    [SerializeField] GameObject luz4;
    [SerializeField] GameObject luz5;


    bool verifi = true;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //FollowFinger();
        //FollowFingerssss();
        
        TouchPhaser();
        if (verifi==false)
        {
            andar();
        }
        if (cambio_estado >= 1)
        {
            restante -= Time.deltaTime;
            int tempmin = Mathf.FloorToInt(restante / 60);
            int tempseg = Mathf.FloorToInt(restante % 60);
            timer.text = string.Format("{00:00}:{01:00}", tempmin, tempseg);
        }

        if (Input.GetKeyDown(KeyCode.Space) || restante<= 0 ||cambio_estado >= 6 )
        {
            SceneManager.LoadScene(escena);
        }

    }
    public void Awake()
    {
        restante = (min * 60) + seg;
    }


    void TouchPhaser()
    {

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);


            if (t.phase == TouchPhase.Began)
            {
                cambio();
                
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
   



void andar()
    {
        switch (cambio_estado)
        {
            case 0:
                
                break;
            case 1:
                luz2.SetActive(true);
                cartel1.SetActive(true);
                verifi = true;
                
                break;
            case 2:
                
                cartel1.SetActive(false);
                Sequence sequence = DOTween.Sequence();
                sequence.Append(usuario.transform.DOMove(pocision2.position, 2f));
                sequence.OnComplete(() => verifi = true);
                cartel2.SetActive(true);
                luz3.SetActive(true);
                break;
            case 3:
                cartel2.SetActive(false);
                Sequence sequence2 = DOTween.Sequence();
                sequence2.Append(usuario.transform.DOMove(pocision3.position, 2f));
                sequence2.OnComplete(() => verifi = true);
                cartel3.SetActive(true);
                luz4.SetActive(true);
                break;
            case 4:
                cartel3.SetActive(false);
                Sequence sequence3 = DOTween.Sequence();
                sequence3.Append(usuario.transform.DOMove(pocision4.position, 2f));
                sequence3.OnComplete(() => verifi = true);
                cartel4.SetActive(true);
                luz5.SetActive(true);
                break;
            case 5:
                cartel4.SetActive(false);
                Sequence sequence4 = DOTween.Sequence();
                sequence4.Append(usuario.transform.DOMove(pocision5.position, 2f));
                sequence4.OnComplete(() => verifi = true);
                cartel5.SetActive(true);
                break;

        }
       
    }
    void cambio()
    {
        if (verifi==true)
        {
            cambio_estado++;
            verifi = false;
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