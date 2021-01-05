using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontLine : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    float linePosition = 3.5f;

    float baseXPosition = 0f;

    // Start is called before the first frame update
    void Start()
    {
        baseXPosition = transform.position.x - linePosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x != baseXPosition + linePosition) {
            if (transform.position.x - baseXPosition < linePosition) {
                transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
                if (transform.position.x - baseXPosition >= linePosition) {
                    transform.position = new Vector3(baseXPosition + linePosition, transform.position.y, transform.position.z);
                }
            }
            else {
                transform.Translate((-1) * moveSpeed * Time.deltaTime, 0f, 0f);
                if (transform.position.x - baseXPosition <= linePosition) {
                    transform.position = new Vector3(baseXPosition + linePosition, transform.position.y, transform.position.z);
                }
            }
        }
    }

    public float GetFrontLinePosition() {
        return linePosition;
    }
    public void PushRed() {
        linePosition += 1f;
        // ANIMATION
    }
    public void PushBlue() {
        linePosition -= 1f;
        // ANIMATION
    }
    public void PushTie() {
        // ANIMATION
    }

}
