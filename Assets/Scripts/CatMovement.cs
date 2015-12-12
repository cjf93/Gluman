using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour {

    private GameObject huntingTarget;
    private bool targetOnRight;
    private bool isHunting;

    private bool traped;
    private Rigidbody2D _rigidBody2D;
    private Transform _transform;

	// Use this for initialization
	void Start () {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        traped = false;
        isHunting = false;
	}
	
	// Update is called once per frame
	void Update () {
        SetMove();
	}
    void SetMove()
    {
        if (isHunting)
        {
            if (huntingTarget.transform.position.x > _transform.position.x)
            {
                targetOnRight = true;
            }
            else
            {
                targetOnRight = false;
            }
            Move();
        }
    }
    void Move()
    {
        if(targetOnRight) {
            _transform.position = new Vector3(_transform.position.x + 0.1f, _transform.position.y, _transform.position.z);
        }
        else {
            _transform.position = new Vector3(_transform.position.x -0.1f, _transform.position.y, _transform.position.z);
        }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        isHunting = true;
        huntingTarget = other.gameObject; 
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isHunting = false;
        huntingTarget = other.gameObject;
    }
}
