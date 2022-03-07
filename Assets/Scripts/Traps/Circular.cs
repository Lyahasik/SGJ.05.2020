using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular : MonoBehaviour
{
    [Range(0f, 360f)]
    public float angle = 0f;
    public float stepRotate = 45f;
    public bool directionInversion = true;
    private bool middle = false;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    void Update()
    {
        Debug.Log(new Vector3(0.5f, 0.5f, 1.0f).normalized);
        if (TimeZone.GetAmount() != 0 && !TimeZone.GetTimeZone())
        {
            if (directionInversion == true)
            {
                if (middle == false)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180, 0), stepRotate * Time.deltaTime);
                    if (transform.rotation == Quaternion.Euler(0, 180, 0))
                    {
                        middle = true;
                    }
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -359, 0), stepRotate * Time.deltaTime);
                    if (transform.rotation == Quaternion.Euler(0, -359, 0))
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        middle = false;
                    }
                }
            }
            else
            {
                if (middle == false)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -180, 0), stepRotate * Time.deltaTime);
                    if (transform.rotation == Quaternion.Euler(0, -180, 0))
                    {
                        middle = true;
                    }
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 359, 0), stepRotate * Time.deltaTime);
                    if (transform.rotation == Quaternion.Euler(0, 359, 0))
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        middle = false;
                    }
                }
            }
        }
    }
}
