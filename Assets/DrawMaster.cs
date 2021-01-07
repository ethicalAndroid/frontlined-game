using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMaster : MonoBehaviour
{

    [SerializeField] GameObject[] unitPrefabBoxRed;
    [SerializeField] GameObject[] unitPrefabBoxBlue;

    HandSpace handSpaceRed;
    HandSpace handSpaceBlue;

    void Awake() {
        handSpaceRed = GameObject.FindWithTag("HandRed").GetComponent<HandSpace>();
        handSpaceBlue = GameObject.FindWithTag("HandBlue").GetComponent<HandSpace>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawPieceFromCollection(int playerTeamIndex, int unitIndex) {
        GameObject[] playerBox = (playerTeamIndex == 0) ? unitPrefabBoxRed : unitPrefabBoxBlue;
        HandSpace playerHand = (playerTeamIndex == 0) ? handSpaceRed : handSpaceBlue;
        GameObject drawnPrefab = Instantiate(playerBox[unitIndex], transform.position, Quaternion.identity);
        drawnPrefab.transform.SetParent(playerHand.transform);
        playerHand.unitsInHand.Add(drawnPrefab.transform);
        playerHand.RefreshHand();
    }
}
