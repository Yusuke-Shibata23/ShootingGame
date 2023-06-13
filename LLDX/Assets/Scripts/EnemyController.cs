using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public float bottomY = -10.0f;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;

        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
        }
    }
}
