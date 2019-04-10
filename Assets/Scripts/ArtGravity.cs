using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtGravity : MonoBehaviour
{
    private int speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        transform.Translate(0f, -speed * Time.deltaTime, 0f);
    }
}
