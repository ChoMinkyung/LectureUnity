using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour // 일정 시간 단위로 object 생성
{
    public GameObject wallPrefab;
    public float interval = 2.0f;
    private Vector3 wallPos;


    private FlappyBird flappyBird;

    private void Start()
    {
        flappyBird = FindObjectOfType<FlappyBird>(); // FlappyBird 게임 오브젝트를 찾아서 할당

        if (flappyBird != null)
        {
            StartCoroutine(SpawnWalls());
        }
        else
        {
            Debug.LogError("FlappyBird not found!");
        }
    }

    private IEnumerator SpawnWalls()
    {

        while (true)
        {
            wallPos = transform.position;
            wallPos.z -= 2;

            if (flappyBird.GetStart()) Instantiate(wallPrefab, wallPos, transform.rotation);

            yield return new WaitForSeconds(interval);
        }
    }


    void Update()
    {
    }
}
