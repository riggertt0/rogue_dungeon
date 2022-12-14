using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Spawners = new List<GameObject>();
    public List<GameObject> Enemies = new List<GameObject>();
    public List<GameObject> TypeOfEnemies = new List<GameObject>();
    private List<GameObject> Doors = new List<GameObject>();
    public List<GameObject> Levels = new List<GameObject>();
    public List<GameObject> PassedLevels = new List<GameObject>();
    public GameObject Chest;
    private bool Spawned;
    public GameObject image;
    static private bool OpenDoors;
    // Start is called before the first frame update
    void Start()
    {
        Levels.Add(gameObject);
        Invoke("SetDoors", 3f);
        Spawned = false;
        OpenDoors = true;
        GameObject SpawnerPoints = transform.Find("SpawnPoints").gameObject;
        foreach (Transform child in SpawnerPoints.transform)
        {
            Spawners.Add(child.gameObject);
        }
    }

    private void SetDoors()
    {
        Doors = new List<GameObject>(GameObject.FindGameObjectsWithTag("Door"));
    }

    private void CloseAllDoors()
    {
        OpenDoors = false;
        foreach (var door in Doors)
        {
            door.gameObject.SetActive(true);
        }

    }

    private void OpenAllDoors()
    {
        OpenDoors = true;
        foreach (var door in Doors)
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !Spawned)
        {
            Spawned = true;
            CloseAllDoors();
            int CountSpawner = Random.Range(2, 5);
            Debug.Log("Count Spawners");
            Debug.Log(Spawners.Count);
            Debug.Log("Count spawned enemies/chest");
            Debug.Log(CountSpawner);
            while (Spawners.Count != CountSpawner)
            {
                int delIndex = Random.Range(0, Spawners.Count);
                for (int i = delIndex; i < Spawners.Count - 1; ++i)
                {
                    Spawners[i] = Spawners[i + 1];
                }
                Spawners.RemoveAt(Spawners.Count - 1);
            }

            foreach (var spawner in Spawners)
            {
                int rand = Random.Range(0, 11);
                if (rand < 10)
                {
                    GameObject enemyType = TypeOfEnemies[Random.Range(0, TypeOfEnemies.Count)];
                    GameObject enemy = Instantiate(enemyType, spawner.transform.position, Quaternion.identity);
                    enemy.transform.SetParent(gameObject.transform);
                    Enemies.Add(enemy);
                }
                if (rand == 10)
                {
                    GameObject chest = Instantiate(Chest, spawner.transform.position, Quaternion.identity);
                    chest.transform.SetParent(gameObject.transform);
                }
                
            }
            StartCoroutine(CheckEnemies());
        }
    }
    IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => Enemies.Count == 0);
        Levels.Remove(gameObject);
        PassedLevels.Add(gameObject);
        if (Levels.Count == 0)
        {
            image.gameObject.SetActive(true);
        }
        OpenAllDoors();
    }
}

