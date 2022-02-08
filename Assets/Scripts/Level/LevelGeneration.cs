using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject LatestPlatform;

    [SerializeField]
    private Vector3 SpawnLocation;
    [SerializeField]
    private float SpawnDistance;

    [SerializeField]
    private GameObject PlatformPrefab;

    [SerializeField]
    private static float CurrentSpeed = 1f;

    private void Start()
    {
        while (LatestPlatform.transform.position.x < SpawnLocation.x)
        {
            LatestPlatform = Instantiate(PlatformPrefab, LatestPlatform.transform.position + Vector3.right * SpawnDistance, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (Vector3.Magnitude(LatestPlatform.transform.position - SpawnLocation) > SpawnDistance)
        {
            LatestPlatform = Instantiate(PlatformPrefab, SpawnLocation, Quaternion.identity);
        }
    }

    public static float GetCurrentSpeed()
    {
        return CurrentSpeed;
    }
}
