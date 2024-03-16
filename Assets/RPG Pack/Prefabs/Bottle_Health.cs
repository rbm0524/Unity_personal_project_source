using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle_Health : MonoBehaviour //왜 인지는 모르겠으나 prefab을 inspector에서 할당하는 것이 불가 그래서 Resources.load로 해결
{

    public enum Type {Health }; //업데이트 시 Coin이나 다른 장비들을 추가해서 업데이트 가능하게, 타입 열거
    public Type type;
    public int value; //아이템 식별값, 다른 아이템을 추가할 경우 value를 다르게 설정
}
