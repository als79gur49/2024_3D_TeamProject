using System.Collections;
using UnityEngine;

[System.Serializable]
public class Building
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField][Range(0, 1000)]
    private float chance; //ÀÌ ¼ýÀÚ¸¦ Á¶ÀýÇØ¼­ »ý¼º È®·ü Á¶Àý
    private float rate; //½ÇÁ¦ »ý¼º½Ã Àû¿ëµÉ È®·ü

    public GameObject Prefab { get => prefab; }
    public float Chance { get => chance; }//ÀÐ±â Àü¿ë ÇÁ·ÎÆÛÆ¼
    public float Rate {  get => rate; set { rate = value; } }
}



public class BuildingSpawner : MonoBehaviour
{

    [SerializeField]
    private Building[] buildings;
    [SerializeField]
    private Transform[] spawnPoints;
    private float totalChance; //chanceÀÇ ÃÑÇÕ

    [SerializeField]
    private int maxSpawnCount;
    private int currentSpawnCount;
    public int MaxSpawnCount { get => maxSpawnCount; }

    [SerializeField][Range(0, 1)]
    private float spawnDelay;

    private GameObject lastBlock; //°¡Àå ÃÖ±Ù ºí·°ÀÇ Á¤º¸¸¦ ÅëÇØ »õ·Î¿î ºí·° »ý¼º °¡´É¼º È®ÀÎ

<<<<<<< HEAD
<<<<<<< HEAD
=======
    [SerializeField][Range(0, 10)]
    private float horizontalSpeeds;
    [SerializeField][Range(0, 10)]
    private float verticalSpeeds;
>>>>>>> parent of 8830eeb (ë‚´ìš© ë³‘í•© ë° ì”¬ ì´ë™ ê°„ BGMì•Œì•„ì„œ í”Œë ˆì´, ë²„ê·¸ ìˆ˜ì •)
=======
>>>>>>> parent of ed3a944 (testê¹ƒí—ˆë²„)

    private void Awake()
    {
        CalculateChance();

        lastBlock = null;
        currentSpawnCount = 0;
    }
    private void Start()
    {
        StartCoroutine(nameof(SpawnCoroutine));
    }
    private IEnumerator SpawnCoroutine()
    {
        while(currentSpawnCount < MaxSpawnCount)
        {
            yield return new WaitUntil(() => lastBlock == null || lastBlock.GetComponent<PlayableMove>()?.IsMoving == false);

            yield return new WaitForSeconds(spawnDelay);

            lastBlock = SpawnBuilding();

            currentSpawnCount++;
        }

        //ÃÖ´ë ½ºÆù ¼ö µµ´Þ ½Ã Ã³¸®
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

    private GameObject SpawnBuilding()
    {
        Building building = buildings[GetRandomIndex()];
        GameObject block = Instantiate(building.Prefab, GetRandomSpawnPoint(), Quaternion.identity);

<<<<<<< HEAD
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 8830eeb (ë‚´ìš© ë³‘í•© ë° ì”¬ ì´ë™ ê°„ BGMì•Œì•„ì„œ í”Œë ˆì´, ë²„ê·¸ ìˆ˜ì •)
=======
>>>>>>> parent of 8830eeb (ë‚´ìš© ë³‘í•© ë° ì”¬ ì´ë™ ê°„ BGMì•Œì•„ì„œ í”Œë ˆì´, ë²„ê·¸ ìˆ˜ì •)
>>>>>>> Stashed changes
        block.GetComponent<PlayableMove>().HorizontalSpeed = horizontalSpeeds;
        block.GetComponent<PlayableMove>().VerticalSpeed = verticalSpeeds;
>>>>>>> parent of 8830eeb (ë‚´ìš© ë³‘í•© ë° ì”¬ ì´ë™ ê°„ BGMì•Œì•„ì„œ í”Œë ˆì´, ë²„ê·¸ ìˆ˜ì •)
=======
>>>>>>> parent of ed3a944 (testê¹ƒí—ˆë²„)
        //Debug.Log(block.name + " »ý¼º");

        return block;
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
