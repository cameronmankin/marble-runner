using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // FixedUpdate is called independently at framerate.
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _rigidbody.AddForce(new Vector3(horizontal, 0, vertical) * moveForce, ForceMode.Force);
    }

    // Called when collider has begun touching another rigidbody/collider.
    void OnCollisionEnter(Collision collision)
    {
        // InverseLerp finds where a value is between two points, outputting a float between 0 and 1.
        float relativeVel = Mathf.InverseLerp(0f, 20f, collision.relativeVelocity.magnitude);
        // Conveneniently volume is also a value between 0 and 1, so our volume scales with relative velocity.
        _audioSource.volume = relativeVel;

        _audioSource.Play();
    }
}
