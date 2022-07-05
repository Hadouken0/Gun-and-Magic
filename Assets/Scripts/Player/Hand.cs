using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private IUsable _usableItemInHand;
    [SerializeField] private float _rotationY;
    [SerializeField] private Transform _itemPivot;
    [SerializeField] private MeshRenderer _meshRenderer;

    public void UseItem()
    {
        if (_usableItemInHand == null)
            return;

        _usableItemInHand.Use();
    }

    public void TakeItem(Wearable item)
    {
        if (item == null)
            return;

        if(item.TryGetComponent(out IUsable usable))
        {
            _usableItemInHand = usable;
        }

        item.transform.SetParent(_itemPivot);
        item.transform.localPosition = new Vector3(0f, 0f, 0f);
        item.transform.localRotation = Quaternion.Euler(new Vector3(0f, _rotationY, 0f));
        _meshRenderer.enabled = true;
    }

    public void DropItem()
    {
        _usableItemInHand = null;
        _meshRenderer.enabled = false;
        foreach (Transform child in _itemPivot)
        {
            child.parent = null;
        }
    }
}
