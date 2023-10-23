using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KiitchenObjectSO cutKitchenObjectSO;

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
            if (player.HasKitchenObject())
            {
                //player carrying
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            //Theres a kitchen object in ehre
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }

}
