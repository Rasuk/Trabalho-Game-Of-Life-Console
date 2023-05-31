using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    struct Cube
    {
        public Vector3 position;
        public Color color;

    }
    public GameObject[] Alou;
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
        if (GUI.Button(new Rect(0, 0, 100, 50), "100 Cubos "))
        {
            CreateCube();
        }
        if (GUI.Button(new Rect(100, 0, 100, 50), "200 Cubos "))
        {
            ncubes = 200;
            CreateCube();
        }
        if (GUI.Button(new Rect(200, 0, 100, 50), "500 Cubos "))
        {
            ncubes = 500;
            CreateCube();
        }
        if (GUI.Button(new Rect(300, 0, 100, 50), "1000 Cubos "))
        {
            ncubes = 1000;
            CreateCube();
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

                Color NME = UnityEngine.Random.ColorHSV();
                data[i * ncubes + j] = new Cube();
                data[i * ncubes + j].position = go.transform.position;
                data[i * ncubes + j].color = NME;
                gameObjects[i * ncubes + j] = go;
            }

        }
    }


}
