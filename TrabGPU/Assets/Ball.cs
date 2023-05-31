using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public bool Alive;
    public bool StartGame;
    public List<GameObject> Gjob;
    public int Neighbors;
    public sbyte Comportamento;
    void Start()
    {
        Gjob = new List<GameObject>();
        StartGame = false;
    }

    // Update is called once per frame
    void Update()
    {

        StartGame = rigi.StartingGame;

        if (StartGame)
        {
            
         if(Neighbors==3)
            {
                if(Alive==true)
                {
                    StayAlive();
                }
                else
                Vive();
            }
         else if(Neighbors<2)
            {
                if(Alive==false)
                {
                StayDead();
                }
                else
                {
                Die();
                }
             
            }
         else if(Neighbors>3) 
            {
                Die();
                if(Alive==false)
                {
                    StayDead();
                }
            }
         else if(Neighbors==2 && Alive==true)
            {
                StayAlive();
                
            }





        }
    }
    private void OnMouseDown()
    {

        if(Alive) 
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            for (int i = 0; i < Gjob.Count; i++)
            {
                Gjob[i].GetComponent<Ball>().Neighbors -= 1;
            }

            Alive = false;
          
        }
        else
        {
            Alive=true;
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            for (int i = 0; i < Gjob.Count; i++)
            {
                Gjob[i].GetComponent<Ball>().Neighbors += 1;
            }

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Gjob.Add(other.gameObject);

    }
    private void OnTriggerExit(Collider other)
    {
        Gjob.Remove(other.gameObject);
    }
    public void Vive()
    {
       Alive = true;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        for (int i = 0; i < Gjob.Count; i++)
        {
            Gjob[i].GetComponent<Ball>().Neighbors += 1;
        }
    }
    public void Die()
    {
        Alive = false;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        for (int i = 0; i < Gjob.Count; i++)
        {
            Gjob[i].GetComponent<Ball>().Neighbors -= 1;
        }
    }
   public void StayAlive()
    {
        Alive = true;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;

    }
    public void StayDead()
    {
        Alive = false;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
