using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null && collision.collider.tag == "deadZone")
        {
            float randX = Random.Range(-Settings.xSpawnRange, Settings.xSpawnRange);
            float randY = Random.Range(
                transform.position.y + 50f + Settings.ySpawnRangeStart,
                transform.position.y + 50f + Settings.ySpawnRangeEnd
                );

            transform.position = new Vector3(randX, randY, 0);
        }
    }
}
