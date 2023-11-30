using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    public GameObject tile;
    public int size;
    public float speed;
    private float offset;
    public float strength;
    public float density;
    public bool running;
    

    public GameObject[,] board;
    public void Start()
    {
        board = new GameObject[size, size];
        
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            { 
                board[i,j] = Instantiate(tile,new Vector3(i*2, 0, j*2), Quaternion.identity);
                board[i,j].transform.SetParent(gameObject.transform);
            }
        }

        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        running = true;

        while (running)
        {
            for(int i =0; i<size ;i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Vector3 initial = board[i, j].transform.position;
                    float h = i + j;
                    board[i, j].transform.position = new Vector3(initial.x, Mathf.Sin(h*(density/100)+offset)*strength, initial.z);
                }
            }

            offset += speed / 100;
            yield return new WaitForSeconds(0.01f);
        }

        yield return null;
    }

}
