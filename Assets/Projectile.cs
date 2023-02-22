using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float aliveTime = 0f;

    public void SetData(Vector2 direction, ProjectileData data) {
        GetComponent<Rigidbody2D>().velocity = direction *  data.speed;
        //spriteRenderer.color = data.color;
        transform.localScale = new Vector3(data.scale, data.scale, data.scale);
    }

    private void Update() {
        aliveTime += Time.deltaTime;
        if (aliveTime > 100f) {
            Destroy(gameObject);
        }
    }
}
