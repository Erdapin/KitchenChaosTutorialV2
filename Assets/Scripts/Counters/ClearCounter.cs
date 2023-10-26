using UnityEngine;
using UnityEngine.TerrainUtils;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KiitchenObjectSO kitchenObjectSO;
    

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //Grab
            if (player.HasKitchenObject())
            {
                //player Carring
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //player not carrying
            }
        }
        else
        {
            if(player.HasKitchenObject())
            {
                //player carrying
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    
}
