using UnityEngine;
using UnityEngine.AI;

namespace StarterAssets
{
    public abstract class BaseInteraction : MonoBehaviour
    {
        #region FIELDS SERIALIZED
        
        [SerializeField] private GameObject _linePrefab;
        
        [SerializeField] private Transform _sourcePosition;
        [SerializeField] private Transform _targetPosition;
        
        [SerializeField] private float _height;

        #endregion

        #region FIELDS

        private NavMeshPath _path;
        
        private LineRenderer _lineRenderer;
        
        #endregion

        #region UNITY FUNCTION

        protected virtual void Awake()
        {
        }

        protected virtual void Start()
        {
            _path = new NavMeshPath();
            _lineRenderer = new LineRenderer();

            CreateWayPointer();
        }

        protected virtual void Update() =>
            WayPointer();

        #endregion

        #region METHODS

        protected virtual void CreateWayPointer()
        {
            GameObject newLine = Instantiate(_linePrefab);
            _lineRenderer = newLine.GetComponent<LineRenderer>();
        }

        protected virtual void WayPointer()
        {
            NavMesh.CalculatePath(_sourcePosition.position, _targetPosition.position, NavMesh.AllAreas,
                _path);

            _lineRenderer.positionCount = _path.corners.Length;

            for (int i = 0; i < _path.corners.Length; i++)
            {
                _lineRenderer.SetPosition(i, _path.corners[i] + Vector3.up * _height);
            }
        }

        #endregion
    }
}