using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D playerRb;
    public MovementSO movementSO;
    protected Vector2 movementDirection;
    public float currentSpeed;
    protected bool isKnockedBack = false;

    [field: SerializeField] public UnityEvent<float> OnVelocityChange { get; set; }

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentSpeed);
        if (!isKnockedBack)
        {
            // If the agent is knocked back, we don't apply normal movement
            playerRb.linearVelocity = currentSpeed * movementDirection;
        }
    }

    public void MoveAgent(Vector2 movementInput)
    {
        movementDirection = movementInput.normalized;
        currentSpeed = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            return Mathf.Clamp(currentSpeed + movementSO.acceleration * Time.deltaTime, 0, movementSO.maxSpeed);
        }
        else
        {
            return Mathf.Clamp(currentSpeed - movementSO.deceleration * Time.deltaTime, 0, movementSO.maxSpeed);
        }
    }

    public void StopMovement()
    {
        playerRb.linearVelocity = Vector2.zero;
        currentSpeed = 0f;
    }

    public void KnockBack(Vector2 knockbackDirection, float knockbackForce, float duration)
    {
        if (!isKnockedBack)
        {
            isKnockedBack = true;
            StartCoroutine(KnockBackCoroutine(knockbackDirection, knockbackForce, duration));
        }
    }

    private void ResetKnockBack()
    {
        StopCoroutine("KnockBackCoroutine");
        ResetKnockBackParameters();
    }

    IEnumerator KnockBackCoroutine(Vector2 knockbackDirection, float knockbackForce, float duration)
    {
        playerRb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        ResetKnockBackParameters();
    }

    private void ResetKnockBackParameters()
    {
        currentSpeed = 0f;
        playerRb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}
