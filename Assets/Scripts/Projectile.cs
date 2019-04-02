using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    SpriteRenderer rend;
    WeaponStyle _style;

    public WeaponStyle style
    {
        get
        {
            return (_style);
        }
        set
        {
            SetStyle(value);
        }
    }

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 50f)
        {
            Destroy(gameObject);
        }

    }

    public void SetStyle(WeaponStyle s)
    {
        _style = s;
        rend.material.color = WeaponManager.GetWeaponDefinition(s).projectileColor;
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
