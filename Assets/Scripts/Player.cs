using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float padding = 0.5f;
    float paddingBot=2f;
    Shooter shooter;

    float xMin, xMax, yMin, yMax;
   
    Vector2 rawInput;


    private void Awake()
    {
        shooter = gameObject.GetComponent<Shooter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;

        if (transform.position.x < xMin)
            transform.position = new Vector3(xMin,transform.position.y,transform.position.z);
        else if (transform.position.x > xMax)
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);

        if (transform.position.y < yMin)
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
        else if (transform.position.y > yMax)
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);

    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddingBot;
        yMax = gameCamera.ViewportToWorldPoint(new Vector2(0.5f, 0.5f)).y;
    }

    void OnMove(InputValue value)
    {
        rawInput=value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        shooter.isFiring = value.isPressed;
        Debug.Log(value);
    }
}
