using UnityEngine;
using UnityEngine.TerrainUtils;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KiitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform topSection;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T)) {
            if (kitchenObject != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter); 
            }
        }
    }

    public void Interact()
    {
        if(kitchenObject == null) { 
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, topSection);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
        }
    }

    public Transform GetKitchenObjectFollowTransform() {
        return topSection;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

}
