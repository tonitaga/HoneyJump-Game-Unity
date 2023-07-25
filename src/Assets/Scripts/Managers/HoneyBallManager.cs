using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBallManager : MonoBehaviour
{
    [SerializeField]
    private GameManager GameManager;

    [SerializeField]
    private TrailRenderer TrailRenderer;
    public Vector3 StartPos { get; private set; }

    [SerializeField]
    private Rigidbody2D Rigidbody;

    public void ResetBall()
    {
        Activate(false);
        Invoke("ResetPositionAndSpeed", 0.1f);
    }

    // <summary>
    // јктивировать или деактивировать м€ч
    // </summary>
    // <param name="activation">True активирует, false деактивирует</param>
    public void Activate(bool activation = false)
    {
        if(activation)
            TrailRenderer.Clear();
        TrailRenderer.emitting = activation;
        Rigidbody.isKinematic = !activation;
    }

    private void ResetPositionAndSpeed()
    {
        gameObject.transform.position = StartPos;
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.angularVelocity = 0f;
    }

    private void Start()
    {
        StartPos = gameObject.transform.position;
        if (GameManager == null)
            GameManager = FindObjectOfType<GameManager>();
    }

    private void Awake()
    {
        Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        TrailRenderer = gameObject.GetComponent<TrailRenderer>();
    }

    void FixedUpdate()
    {
        if (gameObject.transform.position.y <= -10f)
        {
            GameManager.GameOver();
            ResetBall();
        }
    }
}
