using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSquare : MonoBehaviour
{
    [SerializeField] int baseDamage = 1;
    [SerializeField] int teamIndex = 0;
    [SerializeField] SpriteRenderer mySpriteRenderer;
    [SerializeField] TextMesh myTextMesh;
    [SerializeField] Color[] colorBox;

    Collider2D myCollider;
    void Awake() {
        myCollider = GetComponent<Collider2D>();
        RefreshSprites();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RefreshSprites() {
        mySpriteRenderer.color = colorBox[teamIndex];
        myTextMesh.color = colorBox[teamIndex];
        myTextMesh.text = baseDamage.ToString();
    }

    public void Attack() {
        // ANIMATION
        Collider2D[] results = new Collider2D[1];
        if (myCollider.OverlapCollider((new ContactFilter2D()).NoFilter(), results) > 0) {
            Unit hitUnit = results[0].GetComponent<Unit>();
            if (hitUnit.GetTeamIndex() != teamIndex || hitUnit.GetTeamIndex() == 2) {
                hitUnit.TakeDamage(baseDamage);
            }
        }
    }
}
