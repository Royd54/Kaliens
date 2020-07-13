using UnityEngine;
using System.Collections;

public class GameController_Script : MonoBehaviour 
{
    [SerializeField] private float spawnRadius = 7, time = 2f;
    [SerializeField] private GameObject player;

    public GameObject[] enemies;

	// Use this for initialization
	void Start ()
	{
        player = GameObject.Find("Player");
        StartCoroutine(SpawnAnEnemy());
    }

	// Update is called once per frame
	void Update () 
	{
		//Excute when keyboard button R pressed
		if(Input.GetKey("r"))
		{
			Application.LoadLevel(1);		//Load Level 0 (same Level) to make a restart
		}
    }		

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        if (time >= 0.5f)
        {
            time -= 0.01f;
        }
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
