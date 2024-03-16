using UnityEngine;
using System.Collections;

//총알
public class BulletScript : MonoBehaviour {

	[Tooltip("Furthest distance bullet will look for target")]
	public float maxDistance = 1000000;
	RaycastHit hit;
	[Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitWall;
	[Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]
	public float floatInfrontOfWall;
	[Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
	public GameObject bloodEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;

	public int damage;

	/*
	* Uppon bullet creation with this script attatched,
	* bullet creates a raycast which searches for corresponding tags.
	* If raycast finds somethig it will create a decal of corresponding tag.
	*/
	void Update()
	{

		if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
		{ //raycast로 광선을 쏴서 맞는 물체
			if (decalHitWall)
			{
				if (hit.transform.tag == "Wall")
				{ //총알이 닿은 것이 벽일 때
					Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));

					Destroy(gameObject);
				}
				if (hit.transform.tag == "Zombie")
				{
					GameObject zombieObject = hit.transform.gameObject; // 충돌한 Zombie 오브젝트를 가져온다.
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));

					if (hit.collider == zombieObject.GetComponent<BoxCollider>())
					{
						Enemy zombie = zombieObject.GetComponent<Enemy>();
						zombie.currentHealth -= 1;
					}
					else if (hit.collider == zombieObject.GetComponent<SphereCollider>() )
					{
						Enemy zombie = zombieObject.GetComponent<Enemy>();
						zombie.currentHealth = 0;
						Enemy.headShot_Count += 1;
						Debug.Log(Enemy.headShot_Count);
					}

					Destroy(gameObject);
				}

				if (hit.transform.tag == "Box")
                {
					if(Enemy.headShot_Count >= 20) //20으로 수정
                    {
						GameObject boxObject = GameObject.Find("Box");
						Collider hitCollider = hit.collider; //충돌한 물체의 정보 저장
						MysteryBox mysterybox = hitCollider.GetComponent<MysteryBox>(); //mysterybox에 충돌한 물체 정보 저장
						mysterybox.boxHealth -= 1; //mysterybox 스크립트의 currentHealth에서 1을 뺌
						if(mysterybox.boxHealth <= 0)
                        {
							Enemy.headShot_Count = 0; //0을 할당해서 headshot을 20번 달성해야 상자를 열 수 있고 한 번 열면 다시 스택을 쌓을 수 있도록
                        }
						Destroy(gameObject);
					}
				}
			}
			Destroy(gameObject);
		}
		Destroy(gameObject, 0.1f);
	}
}