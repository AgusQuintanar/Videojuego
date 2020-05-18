using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{

    public int amount = 1;
    public Item item;

    private Player player;
    private Inventory playerInventory;

    private bool canBeCollected = false;

    private void Awake()
    {
        InstantiateItemIn3d();
    }

    public void InstantiateItemIn3d()
    {
        if (item != null)
        {
            GameObject itemIn3d = Instantiate(item.ItemIn3D, this.transform);
            itemIn3d.transform.parent = this.transform;

            itemIn3d.AddComponent<Rigidbody>();
            itemIn3d.AddComponent<BoxCollider>();
        }
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerInventory = player.getInventory();
    }

    private void Update()
    {
        if (canBeCollected && Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("Detected object");

            // todo show gui

            for (int i = 0; i < amount; i++) playerInventory.addItem(new ItemStack(item, 1));

            InventoryManager.INSTANCE.openContainer(new ContainerPlayerHotbar(null, playerInventory));
            InventoryManager.INSTANCE.resetInventoryStatus();

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && item != null)
        {
            canBeCollected = true;
        }
        else
        {
            canBeCollected = false;
        }

        
    }
}
