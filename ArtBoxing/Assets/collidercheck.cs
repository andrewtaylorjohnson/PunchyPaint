using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidercheck : MonoBehaviour
{



    [SerializeField] Transform drawPartent;
    [SerializeField] GameObject paintPrefab;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, -0.135f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CanvasCollider")
        {
            List<Vector3> contactLists = new List<Vector3>();
            Debug.Log("Collide with pannel");
            if (collision.contacts.Length > 0)
            {
                foreach (var item in collision.contacts)
                {
                    contactLists.Add(item.point);
                }


                Vector3 averagePoint = Vector3.zero;
                for (int i = 0; i < contactLists.Count; i++)
                {
                    averagePoint += contactLists[i];
                }
                averagePoint /= contactLists.Count;
                Debug.Log("The point: " + averagePoint);

                GameObject paint = Instantiate(paintPrefab, averagePoint, Quaternion.identity, drawPartent);
  
                paint.transform.localRotation = Quaternion.identity;
            }
        }
    }
}
