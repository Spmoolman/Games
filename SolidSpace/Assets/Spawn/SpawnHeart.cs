using Assets.Interfaces;
using UnityEngine;

public class SpawnHeart : MonoBehaviour, ISpawn
{
    public GameObject Prefab;
    public float SpawnTime = 3f;

    public void SpawnObject()
    {
        GameObject newHeart;
        newHeart = Instantiate(Prefab);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", SpawnTime, SpawnTime);
    }
}