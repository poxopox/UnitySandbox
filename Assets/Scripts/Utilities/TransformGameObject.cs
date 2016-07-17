using UnityEngine;
using System.Collections;

public class TransformGameObject : MonoBehaviour {

    public void TransformGO (GameObject go, Vector3 movement) {
        go.transform.Translate(movement);
    }
    public void LookGO(GameObject head, GameObject body, Vector2 mousePosition) {

        body.transform.Rotate(Vector3.up * mousePosition.x);
        head.transform.Rotate(Vector3.right * mousePosition.y);
            
        

    }
}
