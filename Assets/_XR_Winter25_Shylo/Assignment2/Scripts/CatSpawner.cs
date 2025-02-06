using UnityEngine;
using UnityEngine.InputSystem;

public class CatSpawner : MonoBehaviour
{

    [SerializeField] InputActionReference SpawnInput;
    public GameObject KittyCat;
    public Transform targetTransform;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

     private void OnEnable()
    {
        SpawnInput.action.performed += Spawn;
    }

    private void OnDisable()
    {
        SpawnInput.action.performed -= Spawn;
    }

    private void Spawn(InputAction.CallbackContext context)
    {

        Vector3 spawnPosition = targetTransform.position + targetTransform.forward;
        Quaternion spawnRotation = Quaternion.Euler(0, -90, 0);
        Instantiate(KittyCat, spawnPosition, spawnRotation);
    }
}
