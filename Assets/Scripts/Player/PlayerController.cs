using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float baseSpeed = 1.0f;
    private float basecrosshairDistance = 1.0f;
    private float aimingPenalty = 0.0f;
    
    [SerializeField]
    private Vector2 movementDirection;
    private float movementSpeed;
    private bool isAiming;
    private bool canShoot = true;
    private bool alive = true;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private GameObject sakeProjectile;

    private Rigidbody2D rb;
    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            ProcessInputs();
            Move();
            Animate();
            Aim();
        }
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        isAiming = Input.GetButton("Fire2");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIController.Instance.PauseGame();
        }
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
        if (isAiming && isMoving())
        {
            crosshair.transform.localPosition = movementDirection * basecrosshairDistance;
            if (Input.GetButtonDown("Fire1") && canShoot)
            {
                ShootSake();
            }
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

    void ShootSake()
    {
        canShoot = false;
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        GameObject sake = Instantiate(sakeProjectile, transform.position, Quaternion.identity);
        sake.GetComponent<Rigidbody2D>().velocity = shootingDirection * 2;
        sake.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.x, shootingDirection.y) * Mathf.Rad2Deg);

        StartCoroutine("Cooldown");
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    public void SetLiveStatus(bool status)
    {
        alive = status;
        if (!status)
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetFloat("Speed", 0);
            Debug.Log("player dead");
        }
    }

    public bool IsAlive() {
        return alive;
    }
}
