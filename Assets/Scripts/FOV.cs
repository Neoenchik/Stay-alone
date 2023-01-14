/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFOV
{
    float Radius { get; }
    float Angle { get; }
    Transform CurrectTargetTransform { get; }

    bool HasTargets();
    List<Transform> GetAllTargets();
    Transform GetNearestTarget();
    void ForceRecalculate();
}

internal class FOV : MonoBehaviour
{
    [Header("Field Of View parameters:")]
    [SerializeField] private float ViewRadius = 3f;
    [SerializeField][Range(0, 360)] private float ViewAngle = 90f;
    [SerializeField] private float DistanceToLostTarget = 2f;
    [SerializeField] private double UpdateTimer = 0.2;

    [Header("Layer Mask")]
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstructionMask;

    //Target Data
    private bool _hasTargets = false;
    private bool IsLostTargets = false;
    private Transform CurrentTarget = null; //текущая цель для объекта
    private List<Transform> TargetsList = new List<Transform>();
    private IDisposable searchTargets;

    public GameEvent<Transform> OnMainTargetChanged = new GameEvent<Transform>();
    public GameEvent OnTargentsFound = new GameEvent();
    public GameEvent OnTargetLost = new GameEvent();

    //public fields
    public float Radius => ViewRadius;
    public float Angle => ViewAngle;
    public Transform CurrectTargetTransform => CurrentTarget;

    private void Update()
    {
        StartCoroutine(HandleIt());
        FieldOfViewCheck();
    }
    private IEnumerator HandleIt()
    {
        yield return new WaitForSeconds(0.2f);
    }

    private void FieldOfViewCheck()
    {
        //check curreact FOV
        if (!_hasTargets || CurrentTarget = null)
        {
            TargetsList.Clear();

            Collider[] rangeChecks = Physics.OverlapSphere(transform.position, ViewRadius, targetMask);
            if (rangeChecks.Length > 0)
            {
                for (int i = 0; i < rangeChecks.Length; i++)
                {
                    bool IsSeeTarget = false;
                    Transform target = rangeChecks[i].transform; //write position founded object
                    Vector3 directionToTarget = (target.position - transform.position).normalized; //нормальная пути до объкта
                    if (Vector3.Angle(transform.forward, directionToTarget) < ViewAngle) //if object is in field of view
                    {
                        float distanceToTarget = Vector3.Distance(transform.position, target.position); //distance to the object
                        if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask) == false) //if obstacles isn't between the objects
                            IsSeeTarget = true;
                        else
                            IsSeeTarget = false;
                    }
                    else IsSeeTarget = false;

                    if (IsSeeTarget)
                        TargetsList.Add(target);
                }
            }
        }
        //Get Nearest target
        if (!_hasTargets && TargetsList.Count > 0)
        {
            Transform nearestTarget = GetNearestTarget();
            if (nearestTarget != null && nearestTarget != CurrentTarget)
            {
                _hasTargets = true;
                CurrentTarget = nearestTarget;
                OnMainTargetChanged?.Invoke(CurrentTarget); // ??? I don't know how this is being done
                OnTargentsFound?.Invoke();
            }
        }

        //check disctance to current target
        if (_hasTargets)
        {
            float distanceToTarget = Vector3.Distance(transform.position, CurrentTarget.position);
            if (distanceToTarget > DistanceToLostTarget) //If distance is big thet obgect doesn't have target
            {
                _hasTargets = false;
                CurrentTarget = null;
                return;
            }
            IsLostTargets = false;
        }

        if (!_hasTargets && TargetsList.Count < 1)
        {
            if (!IsLostTargets)
            {
                IsLostTargets = true;
                OnTargetLost?.Invoke();
            }
        }
    }

    public Transform GetNearestTarget()
    {
        Transform nearestTarget = null;
        float nearestDistance = 0f;

        if (TargetsList.Count < 1)
            return null;

        for (int i = 0; i < TargetsList.Count; i++)
        {
            float distanceToTarget = Vector3.Distance(transform.position, TargetsList[i].position);
            if (i == 0)
            {
                nearestDistance = distanceToTarget;
                nearestTarget = TargetsList[i];
            }
            else
            {
                if (nearestDistance > distanceToTarget)
                {
                    nearestDistance = distanceToTarget;
                    nearestTarget = TargetsList[i];
                }
            }
        }
        return nearestTarget;
    }

    public bool HasTarget()
    {
        return _hasTargets;
    }
    public void ForceRecalculate()
    {
        FieldOfViewCheck();
    }
    public List<Transform> GetAllTargets()
    {
        return TargetsList;
    }
}

*/