using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float MinPosition;

    private void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;

        if (transform.position.x < MinPosition)
        {
            Destroy(gameObject);
        }
    }
}
