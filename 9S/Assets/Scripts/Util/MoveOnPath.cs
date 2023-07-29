using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour
{
    [SerializeField] private List<GameObject> PathPoints;
    [SerializeField] private float StepSize = 5;
    int CurrntPoint = 0;


    // Update is called once per frame
    void Update()
    {
        
        //transform.position += PathPoints[CurrntPoint].transform.position * Time.deltaTime * 0.1f;
        transform.position = Vector3.MoveTowards(transform.position, PathPoints[CurrntPoint].transform.position, StepSize * Time.deltaTime);
        if (Vector3.Distance(transform.position, PathPoints[CurrntPoint].transform.position) <= 0.05f)
        {
            CurrntPoint++;
            Debug.Log(CurrntPoint);
        }

        if (CurrntPoint == PathPoints.Count)
        {
            CurrntPoint = 0;
        }



    }
}
