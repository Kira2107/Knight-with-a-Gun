using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimations : MonoBehaviour
{
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetWalkAnimation(bool IsWalking)
    {
        // Set the "isWalking" parameter in the Animator to control the walking animation
        animator.SetBool("IsWalking", IsWalking);
    }

    public void AnimatePlayer(float speed)
    {
        SetWalkAnimation(speed > 0f); // Set walking animation if velocity is greater than 0
    }

    public void PlayDeathAnimation()
    {
        // Trigger the death animation
        animator.SetTrigger("Death");
    }
}
