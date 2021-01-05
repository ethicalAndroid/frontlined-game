using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{
    Transform heldPiece;
    LayerMask maskGrab;
    LayerMask maskDrop;
    LayerMask maskHand;
    UnitMaster unitMaster;
    Transform placementGrid;
    HandSpace handSpaceRed;
    HandSpace handSpaceBlue;

    void Awake() {
        maskGrab = LayerMask.GetMask("Grab");
        maskDrop = LayerMask.GetMask("Drop");
        maskHand = LayerMask.GetMask("Hand Space");
        unitMaster = FindObjectOfType<UnitMaster>();
        placementGrid = GameObject.FindWithTag("Placement Grid").transform;
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
        // Placer moves to Mouse position
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Test for clicking on new piece
        if (Input.GetMouseButtonDown(0) && heldPiece == null) {
            // Picking a piece up from a player's hand
            Collider2D foundCollider = Physics2D.OverlapPoint(transform.position, maskGrab);
            if (foundCollider != null && !foundCollider.isTrigger) {
                HandSpace playerHand = (foundCollider.transform.parent.tag == "HandRed") ? handSpaceRed : handSpaceBlue;
                foundCollider.transform.SetParent(transform);
                foundCollider.transform.localPosition = new Vector3(0,0,0);
                heldPiece = foundCollider.transform;
                playerHand.unitsInHand.Remove(heldPiece);
                playerHand.RefreshHand();
            }
        }
        else if (Input.GetMouseButtonDown(0) && heldPiece != null) {
            Collider2D foundCollider = Physics2D.OverlapPoint(transform.position, maskDrop);
            if (foundCollider != null) {
                // Placing a piece onto the game board
                Vector2Int foundPlace = new Vector2Int((int)foundCollider.transform.localPosition.x, (int)foundCollider.transform.localPosition.y);
                if (!unitMaster.fullSpaces[foundPlace.x, foundPlace.y]) {
                    unitMaster.fullSpaces[foundPlace.x, foundPlace.y] = true;
                    heldPiece.GetComponent<Collider2D>().isTrigger = true;
                    heldPiece.GetComponentInChildren<Unit>().Place(foundPlace, placementGrid);
                    Unit placedUnit = heldPiece.GetComponentInChildren<Unit>();
                    unitMaster.totalUnits.Add(placedUnit);
                    heldPiece = null;
                }
            }
            // Placing a piece back into a player's hand
            else {
                foundCollider = Physics2D.OverlapPoint(transform.position, maskHand);
                if (foundCollider != null) {
                    HandSpace playerHand = (foundCollider.tag == "HandRed") ? handSpaceRed : handSpaceBlue;
                    playerHand.unitsInHand.Add(heldPiece);
                    heldPiece.transform.SetParent(playerHand.transform);
                    playerHand.RefreshHand();
                    heldPiece = null;
                }
            }
        }
    }

    // on click
        // check if collided with pickup
        // pick up
    // on let go
        // check if holding a piece
        // check if over a square
        // place piece on square

}
