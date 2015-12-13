using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour {

    private GameObject huntingTarget;
    private bool targetOnRight;
    private bool isHunting;
    public float step;

    public float msBetweenJump;
    private float lastJump;

    private bool traped;
    private Rigidbody2D _rigidBody2D;
    private Transform _transform;

	// Use this for initialization
	void Start () {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        traped = false;
        isHunting = false;
        lastJump = 0;
	}
	
	// Update is called once per frame
	void Update () {
        SetMove();
        if (Time.time - lastJump > msBetweenJump && isHunting)
        {
            lastJump = Time.time;
            Jump();
        }
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
            _transform.position = new Vector3(_transform.position.x + step*Time.deltaTime, _transform.position.y, _transform.position.z);
        }
        else {
            _transform.position = new Vector3(_transform.position.x - step*Time.deltaTime, _transform.position.y, _transform.position.z);
        }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isHunting = true;
            huntingTarget = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isHunting = false;
            huntingTarget = other.gameObject;
        }
    }
    void Jump()
    {
        _rigidBody2D.AddForce(new Vector2(150f, 300f));
    }
}
