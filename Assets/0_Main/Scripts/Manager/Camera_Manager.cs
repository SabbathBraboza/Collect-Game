using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    [Header("V A L U E S:")]
    [SerializeField] private float SmoothSpeed = 5f;

    [Space(5f)]
    [Header("R E F E R E N C E:")]
    [SerializeField] private Transform Player;

    [Space(5f)]
    [Header("O F F S E T")]
    [SerializeField] private float RotationX = 45f;
    [SerializeField] private float RotationY = 45f;
    [SerializeField] private Vector3 Offsets = new (0, 10, -7);


    private void FixedUpdate()
    {
        if (!Player) return;

        Vector3 DesiredPosition = Player.position + Offsets;
        transform.SetPositionAndRotation(Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed * Time.deltaTime)
            , Quaternion.Euler(RotationX, RotationY, 0f));
    }
}
