using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetStyle(WeaponStyle s)
    {
        _style = s;
        rend.material.color = WeaponManager.GetWeaponDefinition(s).projectileColor;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
    }
}
