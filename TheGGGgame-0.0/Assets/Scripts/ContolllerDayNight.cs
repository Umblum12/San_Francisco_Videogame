using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContolllerDayNight : MonoBehaviour
{
    public int rotationscale = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationscale * Time.deltaTime, 0 , 0);
    }
}
