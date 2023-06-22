using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    RotationController control;
    

    private void Start()
    {
        control = GameObject.FindWithTag("control").GetComponent<RotationController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DOTween.Kill("CubeUp");
            control.StopRotated();
            other.transform.parent.DORotateQuaternion(Quaternion.Euler(0, 0, 0),0.3F).OnComplete(() =>
            {
            
                var parent = other.transform.parent;
              
                parent.DetachChildren();

                other.gameObject.SetActive(false);
                control.work = true;
            }

            );
           
        }
    }
}
