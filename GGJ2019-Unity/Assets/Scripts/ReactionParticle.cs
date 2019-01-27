using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionParticle : MonoBehaviour {
    public float Lifetime;
    public float Speed;
    public float GravityScale;
    private float _startTime;
    private Vector2 _direction;
	// Use this for initialization
	void Start () {
        _startTime = Time.deltaTime;
        _direction = new Vector2(Random.value * 2 - 1, Random.value).normalized;
	}
	
	void Update () {
		if (Time.deltaTime - _startTime >= Lifetime)
        {
            Destroy(gameObject);
        }
        _direction.y -= 9.81f * GravityScale * Time.deltaTime;
        var randomX = Random.Range(-Speed, Speed);
        var rect = GetComponent<RectTransform>();
        rect.position = new Vector3(
            rect.position.x + _direction.x * Speed * Time.deltaTime,
            rect.position.y + _direction.y * Speed * Time.deltaTime,
            0
        );
    }
}
