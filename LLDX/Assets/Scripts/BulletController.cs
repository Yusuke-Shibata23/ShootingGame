using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    public float lifeTime = 2.0f;
    public GameObject explosionEffect;


    void Start()
    {
        // �I�u�W�F�N�g����莞�Ԍ�ɍ폜����
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // �e�̈ʒu�ɔ����G�t�F�N�g�𐶐�
            // Instantiate(explosionEffect, transform.position, Quaternion.identity);

            // �e�ƓG�I�u�W�F�N�g��j�󂷂�
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}


