using UnityEngine;
using System.Collections;

public class MoveTowardPlayer : MonoBehaviour {

	private Transform target;

	private Transform currentPosition;

	public float moveSpeed;

	void Awake()
	{
		currentPosition = transform;
	}

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//currentPosition.position.x -= moveSpeed * Time.deltaTime;
	}
}
