using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//생성되는 Zombie 복제체
public class Clone : MonoBehaviour
{
    public GameObject zombiePrefab;
    public GameObject player;
    void Start()
    {
        gameObject.SetActive(false); //원본 숨기기

        for (int i = 0; i < 10; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-40f, 40f), // x 좌표 범위 내에서 랜덤한 값 생성
                1.2f, // y 좌표를 고정
                Random.Range(-40f, 40f) // z 좌표 범위 내에서 랜덤한 값 생성
            );
            GameObject zombie = Instantiate(zombiePrefab, position, Quaternion.identity);
            zombie.GetComponent<Enemy>().target = player.transform;
            zombie.GetComponent<Enemy>().bottlePrefab = Resources.Load<GameObject>("Bottle_Health"); //Resources폴더의 Bottle_Health Prefab을 할당
            zombie.tag = "Zombie"; // 복제체의 tag를 설정
        }

        InvokeRepeating("SpawnZombie", 1f, 1f); // Zombie 1초마다 생성
    }
    void SpawnZombie()
    {
        Vector3 position = new Vector3(
            Random.Range(-40f, 40f), // x 좌표 범위 내에서 랜덤한 값 생성
            1.2f, // y 좌표를 고정
            Random.Range(-40f, 40f) // z 좌표 범위 내에서 랜덤한 값 생성
        );
        GameObject zombie = Instantiate(zombiePrefab, position, Quaternion.identity); //복제체 생성, zombie 변수에 정보 저장
        zombie.GetComponent<Enemy>().target = player.transform;
        zombie.GetComponent<Enemy>().bottlePrefab = Resources.Load<GameObject>("Bottle_Health"); //Resources폴더의 Bottle_Health Prefab을 할당
        zombie.tag = "Zombie"; // 복제체의 tag를 설정
    }
}



