using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 movementDirection;//dat bien de lam huong vien dan bay ra
  void Start()
    {
        Destroy(gameObject,5f);
    }

    void Update()
    {
        if (movementDirection == Vector3.zero) return;
        transform.position += movementDirection * Time.deltaTime;
    }
        public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction;
    }
}
