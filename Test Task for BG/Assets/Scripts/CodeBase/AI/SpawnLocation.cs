using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.AI
{
    public class SpawnLocation : MonoBehaviour
    {
        #region FIELDS SERIALIZED

        /*[Header("Spawn Object")] 
        [SerializeField]
        private GameObject _spawnPrefab;*/

        [SerializeField] private float _spawnRange;

        #endregion

        #region FIELDS

        private Vector3 _point;

        public static SpawnLocation Instance;

        #endregion

        #region UNITY FUNCTION

        private void Awake()
        {
            //CreatePrefab();

            Instance = this;
        }

        #endregion

        #region METHODS

        public Vector3 GetRandomPoint(Transform point = null, float radius = 0)
        {
            if (RandomPoint(point == null ? transform.position : point.position, radius == 0 ? _spawnRange : radius,
                    out _point))
            {
                return _point;
            }

            return point == null ? Vector3.zero : point.position;
        }

        private bool RandomPoint(Vector3 center, float range, out Vector3 result)
        {
            for (var i = 0; i < 30; i++)
            {
                Vector3 randomPoint = center + Random.insideUnitSphere * range;
                NavMeshHit hit;

                if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
                {
                    result = hit.position;
                    return true;
                }
            }

            result = Vector3.zero;
            return false;
        }

        /*private void CreatePrefab()
        {
            if (GetRandomPoint() != default) 
                Instantiate(_spawnPrefab, _point, Quaternion.identity);
        }
        */
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _spawnRange);
        }

        #endregion

    }
}