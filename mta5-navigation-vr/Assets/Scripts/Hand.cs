using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    //Animation variables
    SkinnedMeshRenderer mesh;
    Animator animator;
    private float triggerTarget;
    private float gripTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string animatorGripPara = "Grip";
    private string animatortriggerPara = "Trigger";
    public float animationSpeed;

    //physics variables
    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform followTarget;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        //animation
        animator = GetComponent<Animator>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();

        //physics
        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        //Teleport hands
        body.position = followTarget.position;
        body.rotation = followTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        animateHand();
        PhysicsMove();
    }

    private void PhysicsMove() {
        //position
        var positionWithOffset = followTarget.position + positionOffset;
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        //rotation
        var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);

    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void setTrigger(float v)
    {
        triggerTarget = v;
    }

    void animateHand() {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorGripPara, gripCurrent);
        }
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatortriggerPara, triggerCurrent);
        }
    }

    public void ToggleVisibility()
    {
        mesh.enabled = !mesh.enabled;
    }
}
