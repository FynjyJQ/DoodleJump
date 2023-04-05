using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float smoothing = 0.5f;
    public List<GameObject> backgrounds = new List<GameObject>();
    private float multiplier = 0.02f;

    void Update()
    {
        if (player.transform.position.y > transform.position.y)
        {
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), new Vector3(player.transform.position.x, player.transform.position.y, -10), smoothing * Time.deltaTime);
        }

        multiplier = 0.02f;
        if (player.GetComponent<Rigidbody2D>() == null) return;
        foreach (var background in backgrounds)
        {
            background.transform.position = Vector3.Lerp(new Vector3(
                    background.transform.position.x,
                    background.transform.position.y,
                    background.transform.position.z
                    ),
                new Vector3(
                    background.transform.position.x,
                    (player.GetComponent<Rigidbody2D>().velocity.y * -multiplier) + transform.position.y,
                    background.transform.position.z
                    ),
                Time.deltaTime * 3
                );
            multiplier += 0.02f;
        }
    }
}
