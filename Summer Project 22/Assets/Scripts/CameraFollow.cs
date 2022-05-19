using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;

    [SerializeField]
    private float minX, minY, maxX, maxY;

    private Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        minY = -2.3f;
        minX = -2.45f;
        maxX = 10.23f;
        maxY = 2.2f;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }
        if (tempPos.y < minY)
        {
            tempPos.y = minY;
        }
        if (tempPos.y > maxY)
        {
            tempPos.y = maxY;
        }

        transform.position = tempPos;
    }
}
