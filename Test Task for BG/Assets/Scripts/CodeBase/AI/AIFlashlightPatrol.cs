using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.AI
{
    public class AIFlashlightPatrol : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        protected void Update()
        {
            TrollPatrol();
        }

        private void TrollPatrol()
        {
            if (!_navMeshAgent.hasPath)
            {
                _navMeshAgent.SetDestination(SpawnLocation.Instance.GetRandomPoint());
            }
        }
    }
}