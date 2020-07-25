using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float baseSpeed = 1.0f;
    private float basecrosshairDistance = 1.0f;
    private float aimingPenalty = 0.5f;

    [SerializeField]
    private Vector2 movementDirection;
    private float movementSpeed;
    private bool isAiming;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject crosshair;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
        Animate();
        Aim();
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        isAiming = Input.GetButton("Fire2");
    }

    void Move()
    {
        if (isAiming)
        {
            movementSpeed *= aimingPenalty;
        }

        rb.velocity = movementDirection * movementSpeed * baseSpeed;
    }

    void Animate()
    {
        if(isMoving())
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Speed", movementSpeed);
    }

    void Aim()
    {
        if (isAiming)
        {
            crosshair.transform.localPosition = movementDirection * basecrosshairDistance;
        }
        crosshair.SetActive(isAiming);
    }

    bool isMoving()
    {
        if(movementDirection != Vector2.zero)
        {
            return true;
        } else {
            return false;
        }
    }
}
