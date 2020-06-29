using UnityEngine;
using System.Collections;

public class Player_Script : MonoBehaviour 
{
	public GameObject Explosion;    //Explosion Prefab

    private Rigidbody2D rb2d;
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    [SerializeField] private float movementSpeed = 4;
    [SerializeField] private float rotationSpeed = 5;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        RotatePlayer();
        MovePlayer();
    }


    private void GetPlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void RotatePlayer()
    {
        float rotation = -_horizontalInput * rotationSpeed;
        transform.Rotate(Vector3.forward * rotation);
    }

    private void MovePlayer()
    {
        rb2d.velocity = transform.right *  movementSpeed;
    }

    //Called when the Trigger entered
    void OnTriggerEnter2D(Collider2D other)
	{

		//Excute if the object tag was equal to one of these
		if(other.tag == "Enemy" || other.tag == "Asteroid" || other.tag == "EnemyShot") 
		{
			Instantiate (Explosion, transform.position , transform.rotation); 				//Instantiate Explosion
			SharedValues_Script.gameover = true; 											//Trigger That its a GameOver
			Destroy(gameObject); 															//Destroy Player Ship Object
		}
	}
}
