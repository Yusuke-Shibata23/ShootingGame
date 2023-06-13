using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    public float lifeTime = 2.0f;
    public GameObject explosionEffect;


    void Start()
    {
        // オブジェクトを一定時間後に削除する
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 弾の位置に爆発エフェクトを生成
            // Instantiate(explosionEffect, transform.position, Quaternion.identity);

            // 弾と敵オブジェクトを破壊する
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}


