using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class MultipleTargetCamera : MonoBehaviour
{
    private GameManager gameManager;

    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime;

    public float minZoom;
    public float maxZoom;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;

    public bool hasMovement;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnPlayerJoinedNotice += GameManager_OnPlayerJoinedNotice;
    }
    private void Start()
    {
        if (cam == null)
            cam = GetComponentInChildren<Camera>();
    }

    private void GameManager_OnPlayerJoinedNotice(Player player)
    {
        targets.Add(player.transform);
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        if(hasMovement)
            Move();

        zoom();
       
    }

    private void zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

    }

    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
