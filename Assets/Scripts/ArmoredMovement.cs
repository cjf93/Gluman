using UnityEngine;
using System.Collections;

public class ArmoredMovement : MonoBehaviour {

    public float step;
    public Transform leftStop;
    public Transform rightStop;
    private bool goingRight;

    private bool traped;
    private Rigidbody2D _rigidBody2D;
    private Transform _transform;

	// Use this for initialization
	void Start () {
        goingRight = true;
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        traped = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!traped)
        {
            setMove();
        }
	}
    void setMove()
    {
        if((_transform.position.x - rightStop.position.x) > 0 && goingRight)
        {
            goingRight = false;
            _transform.localScale = new Vector3(-1, 1, 1);
        }
        else if((_transform.position.x - leftStop.position.x) < 0 && !goingRight)
        {
            goingRight = true;
            _transform.localScale = new Vector3(1, 1, 1);
        }
        Move();
    }
    void Move(){
        if (goingRight)
        {
            _transform.position = new Vector3(_transform.position.x + step*Time.deltaTime, _transform.position.y, _transform.position.z);
        }
        else 
        {
            _transform.position = new Vector3(_transform.position.x - step * Time.deltaTime, _transform.position.y, _transform.position.z);
        }
    }
}
