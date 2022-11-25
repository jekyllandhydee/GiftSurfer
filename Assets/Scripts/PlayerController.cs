using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, limitX, xSpeed;
    [SerializeField] DynamicJoystick dynamicJoystick;

    private void OnEnable()
    {
        GameManager.OnDeath += OnFail;
    }

    private void OnDisable()
    {
        GameManager.OnDeath -= OnFail;
    }

    private void Start()
    {
        dynamicJoystick = FindObjectOfType<DynamicJoystick>();

    }

    bool failed = false;
    bool started = true;

    void Update()
    {
        if (failed || !started )
            return;

        float newX = 0;
        float touchXDelta = 0;
        touchXDelta = dynamicJoystick.Horizontal;

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + speed * Time.deltaTime);
        transform.position = newPosition;
    }

    void OnFail() => failed = true;
}
