using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    private int placeTurn = 0;
    private int firstColorIndex = 0;
    private bool combatNow = false;
    [SerializeField] int[] unitIndexDeckRed;
    [SerializeField] int[] unitIndexDeckBlue;

    Vector3 playerHandPos = new Vector3(0f, -4.25f, -3f);
    Vector3 hiddenHandPos = new Vector3(0f, -30f, 0f);

    HandSpace handSpaceRed;
    HandSpace handSpaceBlue;
    DrawMaster drawMaster;
    UnitMaster unitMaster;

    void Awake() {
        handSpaceRed = GameObject.FindWithTag("HandRed").GetComponent<HandSpace>();
        handSpaceBlue = GameObject.FindWithTag("HandBlue").GetComponent<HandSpace>();
        drawMaster = FindObjectOfType<DrawMaster>();
        unitMaster = FindObjectOfType<UnitMaster>();
    }


    // Start is called before the first frame update
    void Start()
    {
        ContinuePlaceTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetCombat() {
        return combatNow;
    }

    public void ContinuePlaceTurn() {
        if (placeTurn == 4) {
            combatNow = true;
            placeTurn = 0;
            handSpaceBlue.transform.parent.transform.position = hiddenHandPos;
            handSpaceRed.transform.parent.transform.position = hiddenHandPos;
            firstColorIndex = (firstColorIndex == 0) ? 1 : 0;
            StartCoroutine(unitMaster.CombatTurn());
        }
        else {
            combatNow = false;
            if (placeTurn == 0) {
                drawMaster.DrawPieceFromCollection(0, unitIndexDeckRed[Random.Range(0, unitIndexDeckRed.Length)]);
                drawMaster.DrawPieceFromCollection(0, unitIndexDeckRed[Random.Range(0, unitIndexDeckRed.Length)]);
                
                drawMaster.DrawPieceFromCollection(1, unitIndexDeckBlue[Random.Range(0, unitIndexDeckBlue.Length)]);
                drawMaster.DrawPieceFromCollection(1, unitIndexDeckBlue[Random.Range(0, unitIndexDeckBlue.Length)]);
            }
            if ((placeTurn + firstColorIndex) % 2 == 0) {
                handSpaceBlue.transform.parent.transform.position = hiddenHandPos;
                handSpaceRed.transform.parent.transform.position = playerHandPos;
            }
            else {
                handSpaceBlue.transform.parent.transform.position = playerHandPos;
                handSpaceRed.transform.parent.transform.position = hiddenHandPos;
            }
            placeTurn++;
        }
        // wait for place piece
        // switch to blue hand
        // wait for place piece
        // switch to red hand
        // wait for place piece
        // switch to blue hand
        // wait for place piece

        // wait for button press
        // start combat turn
    }
}
