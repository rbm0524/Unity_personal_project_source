using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Bottle_Health_Clone : MonoBehaviour //체력병 클론 생성
{
    public bool isDestroy;
    public int spawnProbability;
    public static Vector3 zombiePosition;
    Enemy enemy;

    IEnumerator WaitForSpawn()
    {
        yield return new WaitUntil(() => isDestroy);

        int a = Random.Range(0, 101);
        spawnProbability = 15;
        if (a <= spawnProbability)
        {
            // Enemy가 파괴됐고, 일정 확률로 실행됐을 때 복제체를 생성
            GameObject enemyObject = GameObject.FindGameObjectWithTag("Zombie");
            enemy = enemyObject.GetComponent<Enemy>();
            zombiePosition.y = 0f;
            GameObject clone = Instantiate(enemy.bottlePrefab, zombiePosition, Quaternion.identity);
            gameObject.GetComponent<Renderer>().enabled = true;
            clone.SetActive(true); // 활성화
            isDestroy = false;
            clone.tag = "Health";
        }
    }

    private void Start()
    {
        StartCoroutine(WaitForSpawn()); //isDestroy가 true가 될때까지 기다린다.
    }
}