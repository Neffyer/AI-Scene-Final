using UnityEngine;
using UnityEngine.AI;

public class Formation : MonoBehaviour
{
    public NavMeshAgent leader;
    public NavMeshAgent soldier1;
    public NavMeshAgent soldier2;
    public NavMeshAgent soldier3;
    public GameObject target;
    public Vector3 pos;
    public Quaternion rot;

    void Start()
    {
        transform.rotation = target.transform.rotation;
        transform.position = target.transform.TransformPoint(pos);
    }

    void Update()
    {
        leader.destination = target.transform.TransformPoint(pos);
        soldier1.destination = leader.transform.TransformPoint(pos);
        soldier2.destination = leader.transform.TransformPoint(pos);
        soldier3.destination = leader.transform.TransformPoint(pos);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camRay, out hit, 100))
            {
                target.transform.position = hit.point;
            }
        }
    }
}
