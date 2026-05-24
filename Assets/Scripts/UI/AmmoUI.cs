using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText = null;

    public void UpdateBulletText(int bulletCount)
    {
        if (bulletCount == 0)
        {
            ammoText.color = Color.red;
        }
        else
        {
            ammoText.color = Color.white;
        }
        ammoText.SetText(bulletCount.ToString());
    }
}
