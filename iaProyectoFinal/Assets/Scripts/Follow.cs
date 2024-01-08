using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public float maxVelocity = 0.1f;
    public float angle;
    Vector3 direction;
    Vector3 movement;
    Vector3 inicio;

    [Header("Spawn Settings")]
    [Range(0.0f, 22.0f)] public float range;
    void Start()
    {
        inicio.x = Random.Range(-range, range);
        inicio.z = Random.Range(-range, range);
        inicio.y = 0.0f;
        this.transform.position = inicio;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;

        movement = direction.normalized * maxVelocity;

        gameObject.transform.position += movement;

        angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        gameObject.transform.rotation = rotation;

    }
}

