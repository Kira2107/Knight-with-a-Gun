using DG.Tweening;
using UnityEngine;

public class BulletShellGenerator : ObjectPool
{
    [SerializeField] private float flyDuration = 0.3f;
    [SerializeField] private float flyStrength = 1f;



    public void SpawnBulletShell()
    {
        var shell = SpawnObject();
        MoveShellInRandomDirection(shell);
    }

    private void MoveShellInRandomDirection(GameObject shell)
    {
        shell.transform.DOComplete();
        var randomDirection = Random.insideUnitCircle;
        randomDirection = randomDirection.y > 0 ? new Vector2(randomDirection.x, -randomDirection.y) : randomDirection;
        shell.transform.DOMove(((Vector2)transform.position + randomDirection) * flyStrength, flyDuration).OnComplete(() => shell.GetComponent<AudioSource>().Play());
        shell.transform.DORotate(new Vector3(0, 0, Random.Range(0, 360f)), flyDuration);
    }
}
