using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Death", 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed); // move ≈∞∞° æ» ¥≠∑»¿ª ∂© 0

    }

    void Death()
    {
        DestroyImmediate(this.gameObject);
    }
}
