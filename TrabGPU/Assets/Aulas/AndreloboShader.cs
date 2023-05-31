using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndreloboShader : MonoBehaviour
{
    public ComputeShader computeShader;
    public RenderTexture renderTexture;
    
    void Start()
    {
        renderTexture = new RenderTexture(8, 8, 32);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();

        computeShader.SetTexture(0, "Result", renderTexture);
        computeShader.SetFloat("resolution", renderTexture.width);
        computeShader.Dispatch(0, renderTexture.width / 8, renderTexture.width / 8, 1);
        gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", renderTexture );


    }

    void Update()
    {
        


    }
}
