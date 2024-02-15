using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barel : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
            player.transform.position.z);
    }
}
