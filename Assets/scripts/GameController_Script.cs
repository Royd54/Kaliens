using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController_Script : MonoBehaviour 
{
    [SerializeField] private float spawnRadius = 7, time = 2f;
    [SerializeField] private GameObject player;

    public GameObject[] enemies;

	// Use this for initialization
	void Start ()
	{
        Application.targetFrameRate = 60;
        player = GameObject.Find("Player");
        StartCoroutine(SpawnAnEnemy());
    }

	// Update is called once per frame
	void Update () 
	{
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            //Excute when keyboard button R pressed
            if (Input.GetKey("r"))
            {
                Application.LoadLevel(1);       //Load Level 0 (same Level) to make a restart
            }

            //Excute when keyboard button R pressed
            if (Input.touchCount > 0)
            {
                Application.LoadLevel(1);       //Load Level 0 (same Level) to make a restart
            }
        }

        //Excute when keyboard button R pressed
        if (Input.GetKey("r") && SharedValues_Script.gameover == true)
		{
			Application.LoadLevel(1);		//Load Level 0 (same Level) to make a restart
		}

        //Excute when keyboard button R pressed
        if (Input.touchCount > 0 && SharedValues_Script.gameover == true)
        {
            Application.LoadLevel(1);       //Load Level 0 (same Level) to make a restart
        }
    }		

    IEnumerator SpawnAnEnemy()
    {
        if (SharedValues_Script.gameover == false)
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
        yield return new WaitForSeconds(time);
    }
}
