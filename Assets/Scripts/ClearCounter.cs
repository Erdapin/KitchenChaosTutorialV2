using UnityEngine;
using UnityEngine.TerrainUtils;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KiitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform topSection;

    private KitchenObject kitchenObject;

    public void Interact(Player player)
    {
        if(kitchenObject == null) { 
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, topSection);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            //give object to the player
            kitchenObject.SetKitchenObjectParent(player);
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
