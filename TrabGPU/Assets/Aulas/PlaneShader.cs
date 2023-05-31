using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShader : MonoBehaviour
{


    public ComputeShader computeShader;
    RenderTexture renderTexture;

    // Start is called before the first frame update
    void Start()
    {
        renderTexture = new RenderTexture(256, 256, 32);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();

        computeShader.SetTexture(0, "Result", renderTexture);
        //computeShader.SetFloat("resolution", renderTexture.width / 8,1);
        computeShader.Dispatch(0, renderTexture.width / 8, renderTexture.width / 8, 1);
        gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", renderTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
