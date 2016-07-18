using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
    public GameObject self;
    public GameObject head;
    public GameObject gun;
    private TransformGameObject MoveGO;
    private float mousex, mousey;
    public float mousexSensitivity, mouseySensitivity;
    // Use this for initialization
    void Start () {
        MoveGO = self.AddComponent<TransformGameObject>();
        mousex = Input.GetAxisRaw("Mouse X");
        mousey = Input.GetAxisRaw("Mouse Y");

        Cursor.lockState = CursorLockMode.Locked;
    }
    void MovePlayer() {
        float movez = Input.GetAxis("Vertical");
        float movex = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(-movex, 0.0F, -movez);
        MoveGO.TransformGO(self, movement);
    }
    void PlayerLook() {
        Vector3 playerLook = new Vector2(mousex * mousexSensitivity, mousey * mouseySensitivity);
        MoveGO.LookGO(head, self, playerLook);
    }
	// Update is called once per frame
	void Update () {
        MovePlayer();
        PlayerLook();
        if (Input.GetKey(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
	}
    void LateUpdate() {
        mousex = Input.GetAxisRaw("Mouse X");
        mousey = Input.GetAxisRaw("Mouse Y");
    }


}
