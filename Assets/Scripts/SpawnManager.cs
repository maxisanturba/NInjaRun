using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnManager : MonoBehaviour
{
    private float minToSpawn = .75f;
    private float maxToSpawn = 0;
    private float globalClock;

    GameObject spawnThis;
    [SerializeField] private GameObject[] prefabs;
    private enum PrefabsEnum
    {
        ClockStop, ClockUp, Coin, EnemyJump, EnemyStomp, Felipe
    }
   // private PrefabsEnum prefabsEnum;

    private static KeyValuePair<PrefabsEnum, int>[] PREFABS_PROBS =
    {
        new KeyValuePair<PrefabsEnum, int>(PrefabsEnum.ClockStop, 5),
        new KeyValuePair<PrefabsEnum, int>(PrefabsEnum.ClockUp, 5),
        new KeyValuePair<PrefabsEnum, int>(PrefabsEnum.Coin, 19),
        new KeyValuePair<PrefabsEnum, int>(PrefabsEnum.EnemyJump, 35),
        new KeyValuePair<PrefabsEnum, int>(PrefabsEnum.EnemyStomp, 35),
        new KeyValuePair<PrefabsEnum, int>(PrefabsEnum.Felipe, 1)
    };

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private PrefabsEnum GetRandomPrefab()
    {
        int cumulative = 0;

        for (int i = 0; i < PREFABS_PROBS.Length; i++)
        {
            cumulative += PREFABS_PROBS[i].Value;

            if (Random.Range(0, 100) < cumulative)
            {
                return PREFABS_PROBS[i].Key;
            }
        }
        return PrefabsEnum.Coin;
    }

    private IEnumerator SpawnObject()
    {
        PrefabsEnum getPrefab = GetRandomPrefab();

        spawnThis = getPrefab switch
        {
            PrefabsEnum.ClockStop => prefabs[0],
            PrefabsEnum.ClockUp => prefabs[1],
            PrefabsEnum.Coin => prefabs[2],
            PrefabsEnum.EnemyJump => prefabs[3],
            PrefabsEnum.EnemyStomp => prefabs[4],
            PrefabsEnum.Felipe => prefabs[5],
            _ => prefabs[2],
        };

        globalClock = FindObjectOfType<GameControl>().clock;
        if (globalClock >= 20)
            maxToSpawn = (globalClock * 5) / 100;
        else 
            maxToSpawn = (20 * 5) / 100;

        yield return new WaitForSeconds(Random.Range(minToSpawn, maxToSpawn));

        Instantiate(spawnThis);
        StopAllCoroutines();
        StartCoroutine(SpawnObject());
    }
}
