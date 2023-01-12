 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask GroundLayers;
    private Rigidbody rb;
    private float speed = 3f;
    private float sprint = 6f;
    public Vector3 input;
    private Vector2 look;
    private float jumpHeight = 1f;
    private float GroundedOffset = -0.14f;
    private bool Grounded = true;
    private float GroundedRadius = 0.28f;
    private GameObject mainCamera;
    private InputHandler inputHandler;
    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime = 0.12f;
    Vector2 move;
    // cinemachine
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    public GameObject CinemachineCameraTarget;
    private const float _threshold = 0.01f;
    public bool LockCameraPosition = false;
    public float CameraAngleOverride = 0.0f;
    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;
    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;
    private Animator anim;

    [SerializeField]
    private GameObject ik;
    float targetSpeed;
    public bool sprintActive;
    void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        rb = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponent<Animator>();
    }
    float targetRotation;
    private float _rotationVelocity;
    private void Update()
    {
        GroundedCheck();
    }
    void FixedUpdate()
    {
        rb.velocity += input;
        Move();
        Reducer();
        CameraRotation();
    }
    private void Reducer()
    {
        Vector3 reducer = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (input == Vector3.zero)
        {
            reducer = Vector3.MoveTowards(reducer, Vector3.zero, 0.2f);
            reducer.x = Mathf.MoveTowards(reducer.x, 0f, 0.1f);
            reducer.y = Mathf.MoveTowards(reducer.y, 0f, 0.1f);
        }

        if (reducer.magnitude > targetSpeed)
        {
            reducer.Normalize();
            reducer *= targetSpeed;
        }
        rb.velocity = new Vector3(reducer.x, rb.velocity.y, reducer.z);
        input.y = 0f;
    }
    public void OnMove(InputValue value)
    {
        move=value.Get<Vector2>();
    }
    void OnAnimatorIK(int layerIndex)
    {
      // float reach = anim.GetFloat("RightHandReach");
       // anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, reach);
        anim.SetIKPosition(AvatarIKGoal.RightFoot, ik.transform.position);
    }
    private void Move()
    {
        targetSpeed = sprintActive ? sprint : speed;
        Vector3 inputDirection = new Vector3(move.x, 0.0f, move.y).normalized;
        if (move != Vector2.zero)
        {
            targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                              mainCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref _rotationVelocity,
                RotationSmoothTime);

            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            Vector3 targetDirection = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;
           input = (mainCamera.transform.forward * move.y + mainCamera.transform.right * move.x);
            Walk();
        }
        else
        {
            input = Vector3.zero;
            Idle();
        }

        if (Grounded)
        {
            anim.SetBool("FreeFall", false);
            anim.SetBool("Jump", false);
        }
        else
            anim.SetBool("FreeFall", true);
    }
    public void OnLook(InputValue value)
    {
        look = value.Get<Vector2>();
    }
    public void CameraRotation()
    {
        if (look.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            float deltaTimeMultiplier = 2.0f;

            _cinemachineTargetYaw += look.x * deltaTimeMultiplier;
            _cinemachineTargetPitch += look.y * deltaTimeMultiplier;
        }
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);
    }
    public void OnJump(InputValue value)
    { 
        if (value.isPressed && Grounded)
        {
            input += Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight) * Vector3.up;
            anim.SetBool("Jump", true);
        }
    }
      public void OnSprint(InputValue value)
    {
        SprintInput(value.isPressed);
    }
    public void SprintInput(bool newSprintState)
    {
            sprintActive = newSprintState;
        if(sprintActive)
                Run();
    }
    private void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
            transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

            anim.SetBool("Grounded", Grounded);
    }
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }
}
