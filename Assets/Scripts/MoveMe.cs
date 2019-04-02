using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour {

    public Transform placeToGo
    {
        get { return _placeToGo; }
        set
        {
            _placeToGo = value;
            StopCoroutine("Movement");
            StartCoroutine("Movement");
        }
    }
    private Transform _placeToGo;
    
    IEnumerator Movement()
    {
        while (Vector3.Distance(transform.position, placeToGo.position) > .02f)
        {
            transform.position = Vector3.Lerp(transform.position, placeToGo.position, .02f);
            yield return null;
        }

    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        if(hit.collider.gameObject.name == "Plane")
        {
            placeToGo.position = hit.point;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
