using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRadius = 7, time = 2f;
    [SerializeField] private GameObject player;
    [SerializeField] private int pickupsAmount;
    [SerializeField] private int maxPickupsAmount = 4;

    public GameObject[] pickups;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(SpawnAnPickup());
    }

    IEnumerator SpawnAnPickup()
    {
        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        if (pickupsAmount < maxPickupsAmount)
        {
            Instantiate(pickups[Random.Range(0, pickups.Length)], spawnPos, Quaternion.identity);
        }
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnPickup());
    }

    public int getPickupsInScene()
    {
        return pickupsAmount;
    }

    public void setPickupsInScene(int amount)
    {
        pickupsAmount = amount;
        if (pickupsAmount < maxPickupsAmount)
        {
            pickupsAmount = amount;
        }
    }
}
