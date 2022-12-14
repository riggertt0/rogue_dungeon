using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance_spell : MonoBehaviour
{
    public GameObject spell;

    public Vector3 start_pos;

    public float distance;
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(start_pos, spell.GetComponent<Transform>().position) > distance)
        {
            Destroy(spell);
        }
    }
}
