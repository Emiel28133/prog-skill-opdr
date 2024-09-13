using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float maxSpeed = 15f;
    public float acceleration = 1f;
    public float deceleration = 2f;
    public float timerDuration = 15f;

    private CharacterController controller;
    private Animator animator;
    private float currentSpeed;
    private bool isRunning;
    private float currentTime;

    public Text timerText; // UI Text for the timer
    public Transform cameraTransform;

    private bool gameEnded = false;
    private bool timerStarted = false; // New flag to track if the timer has started

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        currentSpeed = 0f;
        currentTime = timerDuration;
        UpdateTimerUI();
    }

    void Update()
    {
        if (gameEnded) return;

        // Tappen (of toets indrukken)
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) // Dit kan je aanpassen naar mobiel tap detectie
        {
            isRunning = true;
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);

            if (!timerStarted) // Start timer only once
            {
                StartTimer();
                timerStarted = true;
            }
        }
        else
        {
            isRunning = false;
            currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.deltaTime, 0f);
        }

        // Beweging
        Vector3 move = transform.forward * currentSpeed * Time.deltaTime;
        controller.Move(move);

        // Update animaties
        animator.SetFloat("speed", currentSpeed);

        // Timer blijft aftellen als hij gestart is
        if (timerStarted && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();

            if (currentTime <= 0)
            {
                GameLost();
            }
        }

        // Camera volgt speler
        if (cameraTransform != null)
        {
            cameraTransform.position = new Vector3(transform.position.x, cameraTransform.position.y, transform.position.z - 5);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish1") && !gameEnded)
        {
            GameWon();
        }
    }

    void StartTimer()
    {
        // Start de timer logica
        currentTime = timerDuration;
    }

    void UpdateTimerUI()
    {
        timerText.text = "Time: " + Mathf.Clamp(currentTime, 0, timerDuration).ToString("F1");
    }

    void GameWon()
    {
        gameEnded = true;
        currentSpeed = 0;
        animator.SetTrigger("Win");
        // Extra logica voor winnen (bijv. terug naar het menu, etc.)
    }

    void GameLost()
    {
        gameEnded = true;
        currentSpeed = 0;
        animator.SetTrigger("Lose");
        // Extra logica voor verliezen (bijv. terug naar het menu, etc.)
    }
}
