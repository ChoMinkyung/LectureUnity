using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragonFlight
{
    public class BackgroundScroll : MonoBehaviour
    {
        public float speed;
        public Transform[] backgrounds;
        // 배경 이미지의 SpriteRenderer 컴포넌트 가져오기
        SpriteRenderer spriteRenderer;

        // 이미지의 크기 구하기
        float imageSize;
        // 배경의 끝과 시작 X 좌표
        float leftPosX = 0f;

        // 게임 화면 좌표
        float xScreenHalfSize;
        float yScreenHalfSize;

        // Start is called before the first frame update
        void Start()
        {
            yScreenHalfSize = Camera.main.orthographicSize;
            xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

            leftPosX = -(xScreenHalfSize * 2);

            spriteRenderer = backgrounds[0].GetComponent<SpriteRenderer>();
            imageSize = spriteRenderer.bounds.size.x;

            for(int i=0; i<backgrounds.Length; i++)
            {
                backgrounds[i].position = new Vector3 (imageSize * i, 0, 0);
            }
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {

                backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;

                if (backgrounds[i].position.x + xScreenHalfSize < -xScreenHalfSize * 2)
                {
                    int pre;
                    if (i == 0) pre = backgrounds.Length - 1;
                    else pre = i - 1;
                    Vector3 nextPos = backgrounds[i].position;
                    nextPos.x = nextPos.x + imageSize * backgrounds.Length;
                    //nextPos = new Vector3(nextPos.x + imageSize, nextPos.y, nextPos.z);
                    backgrounds[i].position = nextPos;
                }
            }
        }
    }
}