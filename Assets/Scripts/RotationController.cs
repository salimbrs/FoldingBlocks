using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>();
    [SerializeField] GameObject cubePrefab;
    int cubesStartCount;
    [SerializeField] GameObject parentCubesRight;
    [SerializeField] GameObject parentCubesLeft;
    [SerializeField] GameObject parentCubesDown;
    [SerializeField] GameObject parentCubesUp;

    public bool work = true;



    public void CubeAdd()
    {
        cubesStartCount = cubes.Count;
        for (int i = 0; i < cubesStartCount; i++)
        {
            var _temp = Instantiate(cubePrefab);
            _temp.transform.position = cubes[i].transform.position;
            cubes.Add(_temp);
        }
    }

    public void RightButton()
    {

        CubeAdd();
        for (int i = cubesStartCount; i < cubes.Count; i++)
        {
            cubes[i].transform.parent = parentCubesRight.transform;

        }
        parentCubesRight.transform.DORotate(-Vector3.forward * 180, .8f).OnComplete(() =>
        {

            for (int i = cubesStartCount; i < cubes.Count; i++)
            {
                cubes[i].transform.parent = null;

            }
            parentCubesRight.transform.eulerAngles = Vector3.zero;
            var pos = parentCubesRight.transform.position;
            pos.x += (parentCubesRight.transform.position.x - parentCubesLeft.transform.position.x);
            parentCubesRight.transform.position = pos;
            work = true;

        }
            );



    }

    public void LeftButton()
    {


        CubeAdd();
        for (int i = cubesStartCount; i < cubes.Count; i++)
        {
            cubes[i].transform.parent = parentCubesLeft.transform;
        }
        parentCubesLeft.transform.DORotate(Vector3.forward * 180, .8f).OnComplete(() =>
        {
            for (int i = cubesStartCount; i < cubes.Count; i++)
            {
                cubes[i].transform.parent = null;
            }
            parentCubesLeft.transform.eulerAngles = Vector3.zero;
            var pos = parentCubesLeft.transform.position;
            pos.x += (parentCubesLeft.transform.position.x - parentCubesRight.transform.position.x);
            parentCubesLeft.transform.position = pos;
            work = true;

        }
        );





    }

    public void DownButton()
    {


        CubeAdd();

        for (int i = cubesStartCount; i < cubes.Count; i++)
        {
            cubes[i].transform.parent = parentCubesDown.transform;
        }
        parentCubesDown.transform.DORotateQuaternion(Quaternion.Euler(180, 0, 0), .8f).OnComplete(() =>
        {
            for (int i = cubesStartCount; i < cubes.Count; i++)
            {
                cubes[i].transform.parent = null;
            }
            parentCubesDown.transform.eulerAngles = Vector3.zero;
            var pos = parentCubesDown.transform.position;
            pos.z += (parentCubesDown.transform.position.z - parentCubesUp.transform.position.z);
            parentCubesDown.transform.position = pos;
            work = true;
        }
           );



    }

    public void UpButton()
    {

        CubeAdd();

        for (int i = cubesStartCount; i < cubes.Count; i++)
        {
            cubes[i].transform.parent = parentCubesUp.transform;
        }
        parentCubesUp.transform.DORotateQuaternion(Quaternion.Euler(-180, 0, 0), .8f).SetId("CubeUp").OnComplete(() =>
          {
              for (int i = cubesStartCount; i < cubes.Count; i++)
              {
                  cubes[i].transform.parent = null;

              }
              parentCubesUp.transform.eulerAngles = Vector3.zero;
              var pos = parentCubesUp.transform.position;
              pos.z += (parentCubesUp.transform.position.z - parentCubesDown.transform.position.z);
              parentCubesUp.transform.position = pos;
              work = true;
          }
           );
    }

    public void StopRotated()
    {

        DOTween.KillAll();
    }

    public void MoveParents(int parents)
    {


        switch (parents)
        {
            case 0:
                LeftButton();
                work = false;
                break;

            case 1:
                RightButton();
                work = false;
                break;

            case 2:
                UpButton();
                work = false;
                break;
            case 3:
                DownButton();
                work = false;
                break;
        }
    }



}
