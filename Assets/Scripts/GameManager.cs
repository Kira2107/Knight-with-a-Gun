using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    void Start()
    {
        SetCursorIcon();
    }

    private void SetCursorIcon()
    {
        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.Auto); // Set the cursor icon with the texture provided
        }
        else
        {
            Debug.LogWarning("Cursor texture is not assigned. Please assign a Texture2D in the inspector.");
        }
    }

    public void RestartLevel()
    {
        DOTween.KillAll(); // Kill all active tweens to reset animations
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
