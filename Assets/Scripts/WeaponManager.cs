using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public WeaponDefinition[] weaponDefinitions;
    static public Dictionary<WeaponStyle, WeaponDefinition> W_DEFS;

    // Use this for initialization
    void Awake()
    {
        W_DEFS = new Dictionary<WeaponStyle, WeaponDefinition>();
        foreach (WeaponDefinition def in weaponDefinitions)
        {
            W_DEFS[def.style] = def;
        }
    }

    static public WeaponDefinition GetWeaponDefinition(WeaponStyle style)
    {
        // does the key exist?
        if (W_DEFS.ContainsKey(style))
        {
            return (W_DEFS[style]);
        }
        return (new WeaponDefinition());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
