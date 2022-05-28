using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    Rigidbody2D rb;

    //TODO: pass this in from the weapon
    readonly float speed = .1f;
    /// <summary>
    /// true = right
    /// false = left
    /// </summary>
    private bool direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.direction = true;
    }

    void Update()
    {
        //FIXME: dividing by 2 so I don't have to figure out the camera yet and can see it destroyed
        float horizon = GetCameraXMax() / 2;
        if (rb.position.x  > -horizon && rb.position.x < horizon)
        {
            float newX = direction ? rb.position.x + speed : rb.position.x - speed;
            Vector2 nextPosition = new Vector2(newX, rb.position.y);
            rb.MovePosition(nextPosition);
        }
        else
        {
            //Remove Prefab when offscreen
            Destroy(transform.parent.gameObject);
        }
    }
    
    private float GetCameraXMax()
    {
        return Camera.main.orthographicSize * Screen.width / Screen.height;
    }
}