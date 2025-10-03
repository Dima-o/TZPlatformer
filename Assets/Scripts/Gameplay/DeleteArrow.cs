using UnityEngine;

public class DeleteArrow : MonoBehaviour
{
    [SerializeField] private float timeDelete;

    private bool activeTime = true;

    private void Update()
    {
        if (activeTime)
        {
            timeDelete -= Time.deltaTime;

            if (timeDelete <= 0)
            {
                Destroy(gameObject);
                activeTime = false;
            }
        }
    }
}
