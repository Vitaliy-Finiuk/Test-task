using CodeBase.AI;
using CodeBase.Character;
using UnityEngine;
using UnityEngine.AI;

public class Flashlight : MonoBehaviour
{
    #region FIELDS SERIALIZED

    [SerializeField] private ThirdPersonController _playerControls;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private TriggerObserver TriggerObserverPlayerOne;
    [SerializeField] private TriggerObserver TriggerObserverPlayerTwo;
    [SerializeField] private SpawnLocation _spawnLocation;
    [SerializeField] private ParticleSystem Laser;
    [SerializeField] private GameObject _linePrefab;
    [SerializeField] private Transform sourcePos;
    [SerializeField] private float FollowSpeed = 20f;
    [SerializeField] private GameObject _spawnPrefab;

    #endregion

    #region FIELDS

    private LineRenderer _lineRenderer;

    private Transform _lightTransform;

    private GameObject _newLine;
    private GameObject _newLight;

    //private Vector3 _point;

    private bool _destroy;

    #endregion


    private void Start()
    {
        TriggerObserverPlayerTwo.TriggerEnter += TriggerEnter;
        TriggerObserverPlayerOne.TriggerExit += TriggerExit;
        _lineRenderer = new LineRenderer();

        CreateWayPointer();
        CreatePrefab();

        _lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        FollowToLight();

        if (_destroy)
        {
            _navMeshAgent.destination = _newLight.transform.position;
        }
    }

    private void CreateWayPointer()
    {
        _newLine = Instantiate(_linePrefab);
        _lineRenderer = _newLine.GetComponent<LineRenderer>();
    }

    private void CreatePrefab()
    {
        if (_spawnLocation.GetRandomPoint() != default)
            _newLight = Instantiate(_spawnPrefab, _spawnLocation.GetRandomPoint(), Quaternion.identity);
    }

    private void FollowToLight()
    {
        Quaternion rotTar = Quaternion.LookRotation(_newLight.transform.position - this.transform.position);
        this.transform.rotation =
            Quaternion.RotateTowards(this.transform.rotation, rotTar, FollowSpeed * Time.deltaTime);

        if (!_lineRenderer.enabled)
        {
            _lineRenderer.enabled = true;
            Laser.Play();
        }

        _lineRenderer.SetPosition(0, _newLight.transform.position);
        _lineRenderer.SetPosition(1, sourcePos.position);

        Laser.transform.position = _newLight.transform.position;
    }

    private void TriggerEnter(Collider collider)
    {
        SwitchControlOn();

        Debug.Log("asdas");
    }

    private void TriggerExit(Collider collider)
    {
        SwitchControlOff();

        Destroy(this.gameObject);
        Destroy(_newLine);
        Destroy(_newLight);
        Debug.Log("TriggerExit");
    }
    
    private void SwitchControlOn()
    {
        PlayerOff();
        AgentOn();
        _destroy = true;
    }

    private void SwitchControlOff()
    {
        PlayerOn();
        AgentOff();
        _destroy = false;
    }

    private bool PlayerOn()
    {
        return _playerControls.enabled = true;
    }

    private bool PlayerOff()
    {
        return _playerControls.enabled = false;
    }

    private bool AgentOn()
    {
        return _navMeshAgent.enabled = true;
    }

    private bool AgentOff()
    {
        return _navMeshAgent.enabled = false;
    }
}