﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponStyle { none, blaster }

[System.Serializable]
public class WeaponDefinition
{
    public WeaponStyle style = WeaponStyle.none;
    public string letter; // Letter to show on the powerup
    public Color color = Color.white; //Color of collar and powerup
    public GameObject projectilePrefab; //the projectile to spawn
    public GameObject Powerupprefab;
    public Color projectileColor = Color.white;
    public float damage = 0f;
    public float continuousDamage = 0f; //dps for beam weapons
    public float delayBetweenShots = 0f;
    public float velocity = 20f;
}

public class Weapon : MonoBehaviour
{
    public WeaponStyle style
    {
        get { return (_style); }
        set { SetStyle(value); }
    }
    GameObject collar;
    Transform spawnPoint;
    float lastShotTime = 0f;
    public GameObject bullet;
    WeaponStyle _style = WeaponStyle.blaster;
    WeaponDefinition def;
    public GameObject Powerup;

    public void SetStyle(WeaponStyle s)
    {
        _style = s;
        lastShotTime = 0;
        def = WeaponManager.GetWeaponDefinition(s);
        collar.GetComponent<Renderer>().material.color = def.color;
    }




    // Use this for initialization
    void Start()
    {
        collar = transform.Find("Collar").gameObject;
        spawnPoint = collar.transform;
        SetStyle(_style);
        // Add ourselves to our parent's fireDelegate
        GameObject parentGO = transform.parent.gameObject;
        Ship ship = parentGO.GetComponent<Ship>();
        if (ship != null)
        {
            ship.fireDelegate += Fire;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        Fire();
    //    }
    //}

    public void Fire()
    {
        AudioSource audio = GetComponent<AudioSource>();
        Projectile p;
        if (Time.time - lastShotTime < def.delayBetweenShots)
        {
            return;
        }
        switch (style)
        {
            case WeaponStyle.blaster:
                p = MakeProjectile();
                p.rb.velocity = def.velocity * transform.up;
                audio.Play();
                break;
        }


        
}

public Projectile MakeProjectile()
{
    GameObject go = Instantiate(def.projectilePrefab, spawnPoint.position, Quaternion.identity);
    //set the layer! 
    Projectile p = go.GetComponent<Projectile>();
    p.style = style;
    lastShotTime = Time.time;
    go.layer = LayerMask.NameToLayer("HeroProjectile");
    return (p);
}

}

