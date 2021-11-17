using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    SkinnedMeshRenderer mesh;
    Animator animator;
    private float triggerTarget;
    private float gripTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string animatorGripPara = "Grip";
    private string animatortriggerPara = "Trigger";
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animateHand();
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
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripPara, gripCurrent);
        }
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatortriggerPara, triggerCurrent);
        }
    }

    public void ToggleVisibility()
    {
        mesh.enabled = !mesh.enabled;
    }
}
