using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    public float health;
    public int score;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    protected virtual void Move()
    {
        transform.Translate(0f, -speed * Time.deltaTime, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PowerUp pu;
        Destroy(collision.gameObject);
        

        
    }
}
