using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour
{

    public int amount = 1;
    public Item item;

    private Player player;
    private Inventory playerInventory;

    private bool canBeCollected = false;

    private GameObject itemIn3d;

    private void Awake()
    {
        InstantiateItemIn3d();
    }

    public void InstantiateItemIn3d()
    {
        if (item != null)
        {
            itemIn3d = Instantiate(item.ItemIn3D, this.transform);
            itemIn3d.transform.parent = this.transform;

            itemIn3d.AddComponent<Rigidbody>();
            itemIn3d.AddComponent<BoxCollider>();
        }
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerInventory = player.getInventory();
        StartCoroutine(UpdateParent());
    }

    private void Update()
    {

        if (canBeCollected)
        {
            Debug.Log("Detected object ");

            InventoryManager.INSTANCE.setIOHelpBarItemName("Presione [E] para recoger: " + this.item.ItemName);
            InventoryManager.INSTANCE.setIOHelpBarItemAmount("Cantidad: " + this.amount);


        }

        getInput();

    }

    private void updateParentPosition()
    {
        if (item != null)
        {
            //TODO hacerlo
        }
    }

    private void getInput()
    {
        InteractiveObject io = null;
        if (InventoryManager.INSTANCE.getPlayerNearestCollider() != null) io = InventoryManager.INSTANCE.getPlayerNearestCollider().GetComponent<InteractiveObject>();
        bool isIOHelpBarOpen = InventoryManager.INSTANCE.getIsIOHelpBarOpen();

        if (canBeCollected && Input.GetKeyUp(KeyCode.E) && io == this && isIOHelpBarOpen)
        {
            bool canAddItemToInvetory = true;
            int insertedItems = 0;

            for (int i = 0; i < amount; i++)
            {
                canAddItemToInvetory = playerInventory.addItem(new ItemStack(item, 1));

                if (!canAddItemToInvetory)
                {
                    InventoryManager.INSTANCE.setIOHelpBarItemName("No se puede agregar objeto");
                    InventoryManager.INSTANCE.setIOHelpBarItemAmount("El inventario esta lleno!");
                    this.amount -= insertedItems;
                    break;
                }

                insertedItems++;
            }

            InventoryManager.INSTANCE.openContainer(new ContainerPlayerHotbar(null, playerInventory));
            InventoryManager.INSTANCE.resetInventoryStatus();

            InventoryManager.INSTANCE.toggleIOHelpBar(false);

            if (canAddItemToInvetory) Destroy(gameObject);

        }

        if (io != this) canBeCollected = false;
    }

    public void setCanBeCollected(bool canBeCollected)
    {
        this.canBeCollected = canBeCollected;
    }

    public string getItemName()
    {
        return (this.item != null) ? this.item.name : "null";
    }

    public Item getItem()
    {
        return this.item;
    }


    IEnumerator UpdateParent()
    {
        while (true)
        {
            updateParentPosition();

            yield return new WaitForSeconds(0.3f);
        }
    }


}
