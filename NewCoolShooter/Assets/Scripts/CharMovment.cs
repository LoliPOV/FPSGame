using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class CharMovment : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 7.5f;
    [SerializeField] private float runningSpeed = 11.5f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 90.0f;
    [SerializeField] Slider _staminaSlider;
    [SerializeField] int _dashSpeed = 20;
    private bool _isDash = false;


    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    float previousMousSpeed;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        previousMousSpeed = lookSpeed;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftAlt);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftAlt) && _staminaSlider.value != 0 && characterController.isGrounded)
        {
            playerCamera.transform.localPosition = new Vector3(0f, 0.3f, 0);
            //_staminaSlider.value -= 0.005f;
            lookXLimit = 15f;
            lookSpeed = 0.5f;
            playerCamera.transform.position = transform.position;
        }
        else
        {
            playerCamera.transform.localPosition = new Vector3(0f, 0.7f, 0f);
            lookSpeed = previousMousSpeed;
            lookXLimit = 90f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && _staminaSlider.value != 0 && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            int direction = Input.GetKey(KeyCode.D) ? 1 : (Input.GetKey(KeyCode.A) ? -1 : 0);
            Dash(right, direction);
        }
        if (_staminaSlider.value == 0)
        {
            _isDash = false;
        }

        if (_staminaSlider.value < 1 && !_isDash)
        {
            StartCoroutine(FillStamina());
        }
        else
        {
            StopAllCoroutines();
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    private void Dash(Vector3 right, int direction)
    {
        _isDash = true;
        _staminaSlider.value -= 0.005f;
        moveDirection = (right * _dashSpeed * direction);
    }

    IEnumerator FillStamina()
    {
        yield return new WaitForSeconds(2f);
        _staminaSlider.value += 0.003f;
    }
}
