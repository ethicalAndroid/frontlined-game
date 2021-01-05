using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] int hitpoints = 1;
    [SerializeField] int push = 1;
    [SerializeField] int teamIndex = 0;
    [SerializeField] AttackSquare[] beforePushAttack;
    [SerializeField] AttackSquare[] afterPushAttack;
    Vector2Int myPos = new Vector2Int(0,0);

    bool alive = true;

    void Awake() {
        SetSquaresActive(beforePushAttack, false);
        SetSquaresActive(afterPushAttack, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Place(Vector2Int newPos, Transform newParent) {
        myPos = newPos;
        transform.parent.SetParent(newParent);
        transform.parent.localPosition = new Vector3(myPos.x, myPos.y, 0);
    }

    public void SetSquaresActive(AttackSquare[] targetSquares, bool activeToSet) {
        for (int i = 0; i < targetSquares.Length; i++) {
            targetSquares[i].gameObject.SetActive(activeToSet);
        }
    }

    public bool DeathCheck() {
        if (hitpoints <= 0) {
            // ANIMATION
            alive = false;
            return true;
        }
        return false;
    }

    public bool BeforePush() {
        if (alive && beforePushAttack.Length > 0) {
            for (int i = 0; i < beforePushAttack.Length; i++) {
                beforePushAttack[i].Attack();
            }
            // ANIMATION
            return true;
        }
        return false;
    }

    public bool AfterPush() {
        if (alive && afterPushAttack.Length > 0) {
            for (int i = 0; i < afterPushAttack.Length; i++) {
                afterPushAttack[i].Attack();
            }
            // ANIMATION
            return true;
        }
        return false;
    }

    public void TakeDamage(int damage) {
        hitpoints = hitpoints - damage;
        // ANIMATION
        if (hitpoints <= 0) {
            hitpoints = 0;
        }
    }

    public int GetPush() {
        if (alive) {
            // ANIMATION
            return push;
        }
        else {
            return 0;
        }
    }

    public int GetTeamIndex() {
        return teamIndex;
    }
}
