using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssMove : MonoBehaviour
{
    public float Speed = 0.05f;
    private Vector3 startPosition;
    private float repeatPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        repeatPosition = Mathf.Repeat(Time.time * Speed, 10f);
        transform.position = startPosition + (Vector3.left + Vector3.back) * repeatPosition;
    }
}
