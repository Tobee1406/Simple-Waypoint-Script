using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint_Script : MonoBehaviour
{
    public Image img;
    public Transform target;
    public Vector3 offset;
    public GameObject Player;
    Vector3 dirToTarget;

    void Update()
    {
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

        dirToTarget = Vector3.Normalize(target.position - Player.transform.position);
        //print(Vector3.Dot(Player.transform.forward, dirToTarget));
        if (Vector3.Dot(Player.transform.forward, dirToTarget) < 0)
        {
            //Target is behind the player
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        img.transform.position = pos;
    }
}
