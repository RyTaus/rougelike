using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FloatVariable _speed;
    public FloatVariable _attacksPerSecond;

    private Rigidbody2D _rb;

    public GameObject projectilePrefab;
    public ProjectileData regularProjectile;
    public ProjectileData chargedProjectile;


    private Vector2 moveDirection;
    private bool isFiring = false;
    private bool isCharging = false;

    private float chargeDuration = 2f;
    private float currentChargeDuration = 0f;
    private float timeSinceLastFire = 0f;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveDirection = new Vector2(x, y).normalized;
        _rb.velocity = moveDirection * _speed.GetValue();

        if (Input.GetButton("Fire1")) {
            isFiring = true;
            isCharging = false;
        } else if (Input.GetButton("Fire2")) {
            Debug.Log("charge fire");
            isFiring = false;
            isCharging = true;
            currentChargeDuration += Time.deltaTime;
        } else {
            if (isCharging && currentChargeDuration > chargeDuration) {
                Debug.Log("Fire Charge Shot");
                GameObject gameObject = Instantiate(projectilePrefab);
                gameObject.transform.position = transform.position;
                Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 angle = target - new Vector2(transform.position.x, transform.position.y);
                gameObject.GetComponent<Projectile>().SetData(angle.normalized, chargedProjectile);
            }
            isFiring = false;
            isCharging = false;
            currentChargeDuration = 0f;
        }

        if (isFiring && timeSinceLastFire > (1 / _attacksPerSecond.GetValue())) {
            Debug.Log("Fire Normal");
            GameObject gameObject = Instantiate(projectilePrefab);
            gameObject.transform.position = transform.position;
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 angle = target - new Vector2(transform.position.x, transform.position.y);
            gameObject.GetComponent<Projectile>().SetData(angle.normalized, regularProjectile);
            timeSinceLastFire = 0;
        } else {
            timeSinceLastFire += Time.deltaTime;
        }
    }

}
