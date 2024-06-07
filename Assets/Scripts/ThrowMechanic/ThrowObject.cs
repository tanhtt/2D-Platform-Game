using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField]
    Transform startPoint = null, endPoint = null;
    [SerializeField]
    int angle = 0, trajectory_num = 100;
    [SerializeField]
    float V = 0, config = 0.1f;
    float angle_rad = 0;
    [SerializeField]
    GameObject bullet = null;

    public void Fire()
    {
        CalV();
        GameObject B = Instantiate(bullet, startPoint.transform.position, Quaternion.identity);
        Vector3 Force = Vector3.zero;
        Force.x = V * 50 * Mathf.Cos(angle_rad);
        Force.y = V * 50 * Mathf.Sin(angle_rad);
        B.GetComponent<Rigidbody2D>().AddForce(Force);
    }

    void CalV()
    {

        float Y = endPoint.transform.position.y - startPoint.transform.position.y;
        float X = endPoint.transform.position.x - startPoint.transform.position.x;

        if (X < 0)
        {
            angle_rad = -Mathf.Abs(angle) * Mathf.Deg2Rad;
            config = -Mathf.Abs(config);
        }
        else
        {
            angle_rad = Mathf.Abs(angle) * Mathf.Deg2Rad;
            config = Mathf.Abs(config);
        }


        float v2 = (10 / ((Mathf.Tan(angle_rad) * X - Y) / (X * X))) / (2 * Mathf.Cos(angle_rad) * Mathf.Cos(angle_rad));
        v2 = Mathf.Abs(v2);
        V = Mathf.Sqrt(v2);
    }

    void OnDrawGizmosSelected()
    {

        CalV();

        Gizmos.color = Color.red;

        for (int i = 0; i < trajectory_num; i++)
        {
            float time = i * config;
            float X = V * Mathf.Cos(angle_rad) * time;
            float Y = V * Mathf.Sin(angle_rad) * time - 0.5f * (10 * time * time);

            Vector3 pos1 = startPoint.transform.position + new Vector3(X, Y, 0);

            time = (i + 1) * config;
            X = V * Mathf.Cos(angle_rad) * time;
            Y = V * Mathf.Sin(angle_rad) * time - 0.5f * (10 * time * time);

            Vector3 pos2 = startPoint.transform.position + new Vector3(X, Y, 0);

            Gizmos.DrawLine(pos1, pos2);
        }
    }
}
