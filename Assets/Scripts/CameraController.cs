using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private float _smoothTime;

    private Vector3 _velocity;

    // LateUpdate is called after every Update is already called for the frame
    // PLEASE SEE THIS VERY USEFUL CHART: https://docs.unity3d.com/Manual/ExecutionOrder.html
    void LateUpdate()
    {
        // SmoothDamp gradually changes a vector toward a desired goal over time,
        // smoothed by a spring-damper function. _velocity here is a ref, so it's set in real time
        // each loop.
        transform.position = Vector3.SmoothDamp(transform.position, _player.position + _cameraOffset, ref _velocity, _smoothTime);
    }
}
