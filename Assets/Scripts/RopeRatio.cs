
using UnityEngine;

public class RopeRatio : MonoBehaviour
{
    public Transform firePoint;
    public Vector3 grabPos;

    void Update()
    {
        float scaleX = Vector3.Distance(firePoint.position, grabPos);
        GetComponentInChildren<LineRenderer>().material.mainTextureScale = new Vector2(scaleX, 1f);
    }
}
