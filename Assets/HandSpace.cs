using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSpace : MonoBehaviour
{

    public List<Transform> unitsInHand = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshHand() {
        foreach (Transform x in unitsInHand) {
            x.localPosition = new Vector3(unitsInHand.IndexOf(x), 0, 0);
        }
    }
}
