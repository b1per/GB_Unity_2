
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] private Gate _gate;
    [SerializeField] private Rigidbody _player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>().Equals(_player))
        {
            _gate.Toggle();
        }
    }
}
