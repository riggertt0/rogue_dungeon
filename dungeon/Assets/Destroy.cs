using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject spell;
    private float FireTime;
    void Start()
    {
        FireTime = Time.time;
    }

    void Update()
    {
        if(Time.time - FireTime > 0.3)
            Destroy(spell);
    }
}
