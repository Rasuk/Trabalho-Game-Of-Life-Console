using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    struct Cube
    {
        public Vector3 position;
        public Color color;

    }
    public ComputeShader computeShader;
    public int ncubes = 100;
    Cube[] data;
    GameObject[] gameObjects;
public GameObject cubeprefab;
    void Start()
    {

    }


    void Update()
    {

    }
    private void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,100,50),"Create "))
        {
            CreateCube();
        }
        if (GUI.Button(new Rect(0, 100, 100, 20), "Random CPU"))
        {
            for (int i = 0; i < ncubes; i++)
            {
                for (int j = 0; j < ncubes; j++)
                {
                    gameObjects[i * ncubes + j].GetComponent<MeshRenderer>().material.SetColor("_Color", UnityEngine.Random.ColorHSV());
                }
            }
        
        }
    }

    private void CreateCube()
    {
        data = new Cube[ncubes * ncubes];
        gameObjects = new GameObject[ncubes * ncubes];
        for (int i = 0; i < ncubes; i++)
        {
            float offsetX = (-ncubes / 2 + i);
            for (int j = 0; j < ncubes; j++)
            {
                float offsetY = (-ncubes / 2 + j);
                GameObject go = GameObject.Instantiate(cubeprefab, new Vector3(offsetX * 1.1f, 0, offsetY * 1.1f), Quaternion.identity);
                go.GetComponent<MeshRenderer>().material.SetColor("_Color", UnityEngine.Random.ColorHSV());
                Color NME = UnityEngine.Random.ColorHSV();
                data[i * ncubes + j] = new Cube();
                data[i*ncubes+j].position = go.transform.position;
                data[i*ncubes+j].color = NME;
                gameObjects[i*ncubes+j] = go;
            }
        }
    }
}
