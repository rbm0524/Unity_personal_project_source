using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Text 오브젝트 연결을 위한 public 변수

    // Text 오브젝트의 초기값 설정을 위한 Start 함수
    void Start()
    {
        scoreText.text = "Score: " + Enemy.score.ToString(); // Enemy 스크립트의 static 변수인 score를 가져와서 Text에 반영
    }

    // Enemy 스크립트의 static 변수인 score 변경시 Text 오브젝트에 업데이트 되도록 Update 함수에서 호출
    void Update()
    {
        scoreText.text = "Score: " + Enemy.score.ToString(); // Enemy 스크립트의 static 변수인 score를 가져와서 Text에 반영
    }
}



