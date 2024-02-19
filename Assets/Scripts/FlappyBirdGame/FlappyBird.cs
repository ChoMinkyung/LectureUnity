using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlappyBird : MonoBehaviour
{
    public GameObject bird;
    public float jumpPower = 5.0f;
    private int health = 3;
    private Vector3 initialBirdPosition;
    enum State { Wait, Idle, Hurt, Die }
    private State state = State.Wait;
    private bool die = false;
    Rigidbody rigidbody;
    BoxCollider boxCollider;

    private float hurtDuration = 3.0f;
    private float hurtTimer = 0.0f;

    private float StartDuration = 5.4f;
    private float StartTimer = 0.0f;
    private bool start = false;
    private bool end = false;
    public TextMeshProUGUI textStartTimer;
    public TextMeshProUGUI textGameOver;

    private int score = 0;
    public TextMeshProUGUI textScore;
    // Start is called before the first frame update
    void Start()
    {

        rigidbody = bird.GetComponent<Rigidbody>();
        boxCollider = bird.GetComponent<BoxCollider>();

        // 초기 위치 저장
        initialBirdPosition = bird.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = score.ToString();



        if (!start)
        {
            textStartTimer.text = (StartDuration - StartTimer).ToString("0");

            if (StartTimer > StartDuration - 1) textStartTimer.text = "START";
            StartTimer += Time.deltaTime;
        }

        if (StartTimer >= StartDuration)
        {
            rigidbody.useGravity = true;
            start = true;
            state = State.Idle;
            StartTimer = 0.0f;
            textStartTimer.enabled = false;
        }


        if (state == State.Idle)
        {

            print("현재 상태 : " + state);

            if (Input.GetKeyDown(KeyCode.Space))
            {

                rigidbody.velocity = new Vector3(0, jumpPower, 0);
            }
            transform.rotation = Quaternion.Euler(0f, 0f, rigidbody.velocity.y * 3);

        }
        else if (state == State.Hurt)
        {
            hurtTimer += Time.deltaTime;

            transform.Rotate(Time.deltaTime * Vector3.up * 45);
            boxCollider.isTrigger = true;
            textGameOver.text = "GAME OVER";
            if (hurtTimer >= hurtDuration)
            {

                state = State.Die;
            }
        }
        else if (state == State.Die)
        {
            GameManager.Instance.SetScore(score);
            GameManager.Instance.ChangeScene("FlappyBirdEnd");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;

        hurtTimer = 0.0f; // Hurt 상태 진입 시 타이머 초기화
        state = State.Hurt;

        print("Collider 충돌, 현재 상태 : " + state);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        if (state == State.Idle) score++;
    }

    public bool GetStart()
    {
        return start;
    }

    public int GetScore()
    {
        return score;
    }

}
