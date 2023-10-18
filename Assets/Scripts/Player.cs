using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x,0f,inputVector.y);
        isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        transform.position += moveDir * Time.deltaTime * moveSpeed;
    }

    public bool IsWalking() { 
        return isWalking;
    }
}
