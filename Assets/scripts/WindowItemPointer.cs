using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowItemPointer : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Transform target2;
    [SerializeField] private float HideDistance;

    private void Update()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Item closestEnemy = null;
        Item[] allEnemies = GameObject.FindObjectsOfType<Item>();

        foreach (Item currentEnemy in allEnemies)
        {
            float distanceToEnemy = (this.transform.position).sqrMagnitude;

            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                target2 = currentEnemy.gameObject.transform;
            }
        }

        var dir = target2.transform.position - transform.position;

        if (dir.magnitude < HideDistance || target2 == null)
        {
            SetChildrenActive(false);
        }
        else
        {
            SetChildrenActive(true);

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }

}
