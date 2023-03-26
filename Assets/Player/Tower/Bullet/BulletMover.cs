using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletMover : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb2d;
    private BulletData stats;
    private bool isInitialize = false;

    public void Initialize(Transform target, Rigidbody2D rb2d, BulletData stats)
    {
        this.target = target;
        this.rb2d = rb2d;
        this.stats = stats;
        isInitialize = true;
    }

    public void Movement()
    {
        if (!isInitialize)
            return;

        if (target != null)
        {
            var directionToGo = (Vector2)target.position - (Vector2)(gameObject.transform.position);

            var crossProduct = Vector3.Cross(gameObject.transform.up, directionToGo.normalized);
            var rotationResult = crossProduct.z >= 0 ? -1 : 1;
            var movementVector = new Vector2(rotationResult, 1);

            rb2d.velocity = (Vector2)transform.up * stats.Speed * Time.deltaTime;
            float angleZ = crossProduct.z * stats.RotationSpeed * Time.deltaTime;
            rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0f, 0f, angleZ));
        }
        else
            Destroy(gameObject);
    }
}
