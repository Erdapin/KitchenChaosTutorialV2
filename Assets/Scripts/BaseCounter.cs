using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    
    [SerializeField] private Transform topSection;

    private KitchenObject kitchenObject;
    public virtual void Interact(Player player) {
        Debug.LogError("BaseCounter.Interact()");
    }

    public Transform GetKitchenObjectFollowTransform()
    {
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

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}