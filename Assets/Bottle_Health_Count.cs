using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bottle_Health_Count : MonoBehaviour
{
    public TextMeshProUGUI HealthCount; // Text 오브젝트 연결을 위한 public 변수
    public Player player; // Player 스크립트를 사용하기 위한 변수

    // Start is called before the first frame update
    void Start()
    {
        HealthCount.text = player.count.ToString(); // Enemy 스크립트의 static 변수인 score를 가져와서 Text에 반영
    }

    // Update is called once per frame
    void Update()
    {
        HealthCount.text = player.count.ToString(); // Enemy 스크립트의 static 변수인 score를 가져와서 Text에 반영
    }
}