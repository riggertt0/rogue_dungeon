using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;
    private float waitTime = 100f;

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right,
        None
    }

    private RoomVariants variants;
    private int rand;
    private static HashSet<Vector3> SpawnPointsSet = new HashSet<Vector3>() { new Vector3(0f, 0f, 0f) };
    [SerializeField]
    private void Start()
    {
        Vector3 pos = transform.position;
        if (SpawnPointsSet.Contains(pos))
        {
            Destroy(gameObject);
        }
        else
        {
            SpawnPointsSet.Add(pos);
            variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
            Destroy(gameObject, waitTime);
            Invoke("Spawn", 0.2f);
        }
    }
    private GameObject Level;
    public void Spawn()
    {
        if (direction == Direction.Top)
        {
            rand = Random.Range(0, variants.topRooms.Length);
            Level = Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
        }
        else if (direction == Direction.Bottom)
        {
            rand = Random.Range(0, variants.bottomRooms.Length);
            Level = Instantiate(variants.bottomRooms[rand], transform.position, variants.bottomRooms[rand].transform.rotation);
        }
        else if (direction == Direction.Left)
        {
            rand = Random.Range(0, variants.leftRooms.Length);
            Level = Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
        }
        else if (direction == Direction.Right)
        {
            rand = Random.Range(0, variants.rightRooms.Length);
            Level = Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
        }

    } 

}
