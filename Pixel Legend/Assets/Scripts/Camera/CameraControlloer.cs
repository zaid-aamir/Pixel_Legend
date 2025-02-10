using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllor : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        //Position of camera to player
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
