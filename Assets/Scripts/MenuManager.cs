using UnityEngine;

public class MenuManager : MonoBehaviour
{

    private Camera sceneCamera;

    void Start() {
        sceneCamera = GameObject.Find("SceneCamera").GetComponent<Camera>();
        sceneCamera.enabled = false;
    }

}
