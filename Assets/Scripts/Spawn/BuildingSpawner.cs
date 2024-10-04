using System.Collections;
using UnityEngine;

[System.Serializable]
public class Building
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField][Range(0, 1000)]
    private float chance; //이 숫자를 조절해서 생성 확률 조절
    private float rate; //실제 생성시 적용될 확률

    public GameObject Prefab { get => prefab; }
    public float Chance { get => chance; }//읽기 전용 프로퍼티
    public float Rate {  get => rate; set { rate = value; } }
}



public class BuildingSpawner : MonoBehaviour
{

    [SerializeField]
    private Building[] buildings;
    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private int spawnCount;
    public int SpawnCount { get => spawnCount; private set { spawnCount = value; } }

    private float totalChance; //chance의 총합

    private void Awake()
    {
        CalculateChance();

        InputManager.OnSpawnRequested += Spawn;
    }

    private void CalculateChance()
    {
        totalChance = 0;

        foreach (Building b in buildings)
        {
            totalChance += b.Chance;
            
            b.Rate = totalChance;
        }

    }

    private void Spawn()
    {
        SpawnCount--;

        if (SpawnCount >= 0)
        {
            SpawnBuilding();
        }
        else
        { 
        
        }
    }

    private void SpawnBuilding()
    {
        Building building = buildings[GetRandomIndex()];
        Instantiate(building.Prefab, GetRandomSpawnPoint(), Quaternion.identity);
    }

    private int GetRandomIndex()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        float random = Random.Range(0, totalChance); // float [min, max]

        int result = 0;

        for(int i = 0; i < buildings.Length; i++)
        {
            if(random < buildings[i].Rate)
            {
                result = i;

                break;
            }
        }

        return result;
    }

    private Vector2 GetRandomSpawnPoint()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int index = Random.Range(0, spawnPoints.Length); //int [min, max)

        return spawnPoints[index].position;
    }

}
