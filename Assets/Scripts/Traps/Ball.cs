using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(-50.0f, 50.0f)]
    public float angle = 0f;
    public float stepRotate = 45f;
    public bool directionInversion = true;
    public GameObject TutorialMenu;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Update()
    {
        if (!TutorialMenu || (TutorialMenu && TutorialMenu.activeInHierarchy == false))
        {
            if (TimeZone.GetAmount() != 0 && !TimeZone.GetTimeZone())
            {
                if (directionInversion == true)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 50.0f), stepRotate * Time.deltaTime);
                    if (transform.rotation == Quaternion.Euler(0, 0, 50.0f))
                    {
                        directionInversion = false;
                    }
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -50.0f), stepRotate * Time.deltaTime);
                    if (transform.rotation == Quaternion.Euler(0, 0, -50.0f))
                    {
                        directionInversion = true;
                    }
                }
            }
        }
    }
}
