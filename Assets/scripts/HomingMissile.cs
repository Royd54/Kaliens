using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject collisionEffect;
    [SerializeField] float speed = 5f;
    [SerializeField] float rotateSpeed = 200f;
    [SerializeField] int ScoreValue = 1;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	void Update () {
		Vector2 direction = (Vector2)target.position - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(collisionEffect, transform.position, transform.rotation);
        SharedValues_Script.score += ScoreValue;
        Destroy(gameObject);
    }
}
