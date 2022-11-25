using UnityEngine;

public class FailTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 6)
            return;

        GameManager.Instance.InvokeDeath();
    }
}
