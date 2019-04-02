using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificEnemy : Enemy {

    public float amplitude;
    public float frequency;
    float initialX;

	// Use this for initialization
	void Start () {
        initialX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    protected override void Move()
    {
        Vector3 pos = transform.position;
        pos.x = initialX + Mathf.Sin(Time.time * frequency) * amplitude ;
        transform.position = pos;
        base.Move();
    }
}
