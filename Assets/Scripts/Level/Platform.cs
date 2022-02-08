using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float Speed, InitialSpeed;
    [SerializeField]
    private float MinPosition;

    private void Awake()
    {
        InitialSpeed = Speed;
    }

    private void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;

        if (transform.position.x < MinPosition)
        {
            Destroy(gameObject);
        }
    }

    public void StopMoving()
    {
        Speed = 0f;
    }

    public void StartMoving()
    {
        Speed = InitialSpeed;
    }
}
