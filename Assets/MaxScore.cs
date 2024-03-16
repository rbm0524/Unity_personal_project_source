using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScore : MonoBehaviour
{
    public TextMeshProUGUI maxscoreText; // Text 오브젝트 연결을 위한 public 변수
    // Start is called before the first frame update
    void Start()
    {
        maxscoreText.text = "Max Score : " + PlayerPrefs.GetInt("MaxScore").ToString(); // Enemy 스크립트의 static 변수인 score를 가져와서 Text에 반영
    }

    // Enemy 스크립트의 static 변수인 score 변경시 Text 오브젝트에 업데이트 되도록 Update 함수에서 호출
    void Update()
    {
        maxscoreText.text = "Max Score : " + PlayerPrefs.GetInt("MaxScore").ToString(); // Enemy 스크립트의 static 변수인 score를 가져와서 Text에 반영
    }
}
