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


    LayerMask maskUnits;
    Collider2D myCollider;

    void Awake() {
        maskUnits = LayerMask.GetMask("Units");
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
        Collider2D foundCollider = Physics2D.OverlapPoint(transform.position, maskUnits);
        if (foundCollider != null) {
            Unit hitUnit = foundCollider.GetComponent<Unit>();
            if (hitUnit.GetTeamIndex() != teamIndex || hitUnit.GetTeamIndex() == 2) {
                hitUnit.TakeDamage(baseDamage);
            }
        }
    }
}
