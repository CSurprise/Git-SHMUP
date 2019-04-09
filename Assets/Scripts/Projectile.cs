using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    SpriteRenderer rend;
    WeaponStyle _style;
    public ParticleSystem explosion;
    private GameObject manager;

    public AudioSource sound;
    public AudioClip thud;

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
        manager = GameObject.Find("score");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void SetStyle(WeaponStyle s)
    {
        _style = s;
        rend.material.color = WeaponManager.GetWeaponDefinition(s).projectileColor;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        explosion.Play();
        sound.PlayOneShot(thud);
        Destroy(collision.gameObject);
        manager.SendMessage("counter");
        
    }
}
