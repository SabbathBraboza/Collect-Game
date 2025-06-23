using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("V A L U E S:")]
    [SerializeField] private float Speed = 5f;

    [Header("R E F E N E C E S:")]
    [SerializeField] private Joystick joystick;

    private Rigidbody _rb;

    private void Awake() => _rb = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
         Vector3 direction = new(joystick.Horizontal,0f,joystick.Vertical);

        if(direction.magnitude > 0.1f)
        {
            direction.Normalize();

            Vector3 MovePlayer = Speed * Time.fixedDeltaTime * direction;
            _rb.MovePosition(_rb.position + MovePlayer);

            Quaternion TargetRotation = Quaternion.LookRotation(direction);
            _rb.MoveRotation(Quaternion.Slerp(_rb.rotation, TargetRotation, 10f * Time.deltaTime));
        }
    }
}
