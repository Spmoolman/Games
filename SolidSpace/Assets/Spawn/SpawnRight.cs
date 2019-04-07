using Assets.Interfaces;
using UnityEngine;

public class SpawnRight : MonoBehaviour, ISpawn
{
    public GameObject Prefab;
    public float SpawnTime = 3f;
    public float StartTimeTime = 3f;
    public float Spawns = 3;

    public void SpawnObject()
    {
        int count = 1;
        Vector3 location;
        GameObject newHeart;

        while (count <= Spawns)
        {
            location = new Vector3(transform.position.x - count, transform.position.y + count);
            newHeart = Instantiate(Prefab, location, new Quaternion(180, 0, 0, 0));

            count++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", StartTimeTime, SpawnTime);
    }
}
