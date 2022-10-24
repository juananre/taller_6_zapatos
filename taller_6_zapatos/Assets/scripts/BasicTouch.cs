using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BasicTouch : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] cubitos;
    public GameObject cubobase;
    [SerializeField] int escena;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        //InstanciaCubos();
    }

    void InstanciaCubos() {
        cubitos = new GameObject[10];

        for (int i = 0; i < cubitos.Length; i++)
        {
            GameObject tempo = Instantiate(cubobase);
            cubitos[i] = tempo;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //FollowFinger();
        //FollowFingerssss();
        TouchPhaser();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(escena);
        }

    }

    

    void TouchPhaser() {

        if (Input.touchCount > 0) {
            Touch t = Input.GetTouch(0);


            if (t.phase == TouchPhase.Began) {
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

    void FollowFinger()
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
    }
}
