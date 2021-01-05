using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMaster : MonoBehaviour
{

    public List<Unit> totalUnits = new List<Unit>();
    public bool[,] fullSpaces = new bool[10,8];

    [SerializeField] float attackSpeed = 1f;
    [SerializeField] float deathSpeed = 1f;
    [SerializeField] float countSpeed = 0.5f;
    [SerializeField] float pushSpeed = 2f;

    FrontLine frontLine;

    void Awake() {
        frontLine = FindObjectOfType<FrontLine>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CombatTurn() {
        // Attack Before Push
        foreach (Unit x in totalUnits) {
            if (x.BeforePush()) {
              yield return new WaitForSeconds(attackSpeed);
            }
        }
        // Death Check
        foreach (Unit x in totalUnits) {
            if (x.DeathCheck()) {
                yield return new WaitForSeconds(deathSpeed);
            }
        }
        // Push
        int[] pushTeamTotals = {0,0};
        foreach (Unit x in totalUnits) {
            if (x.GetTeamIndex() != 2) {
                pushTeamTotals[x.GetTeamIndex()] += x.GetPush();
                yield return new WaitForSeconds(countSpeed);
            }
        }
        if (pushTeamTotals[0] > pushTeamTotals[1]) {
            frontLine.PushRed();
        }
        else if (pushTeamTotals[0] < pushTeamTotals[1]) {
            frontLine.PushBlue();
        }
        else {
            frontLine.PushTie();
        }
        yield return new WaitForSeconds(pushSpeed);
        // Attack After Push
        foreach (Unit x in totalUnits) {
            if (x.AfterPush()) {
                yield return new WaitForSeconds(attackSpeed);
            }
        }
        // Death Check
        foreach (Unit x in totalUnits) {
            if (x.DeathCheck()) {
                yield return new WaitForSeconds(deathSpeed);
            }
        }

    }
}
