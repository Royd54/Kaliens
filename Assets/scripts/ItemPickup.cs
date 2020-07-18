using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private GameObject _audiosource;
    //Check distance naar speler, als de speler te ver weg is destroyen, en dan bij de pickupspawner index verlagen van de pickups die in de map zitten
    //ability toevoegen aan het item, als de speler deze oppakt ook bij de pickupspawner index verlagen van de pickups die in de map zitten

    // Start is called before the first frame update
    void Start()
    {
        _audiosource = GameObject.FindGameObjectWithTag("audio");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _audiosource.GetComponent<AudioSource>().Play();
            SharedValues_Script.fuelScore += 1;
            Destroy(gameObject);
        }
    }
}
