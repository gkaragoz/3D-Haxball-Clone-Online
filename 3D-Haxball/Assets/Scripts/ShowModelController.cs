using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModelController : MonoBehaviour {

    private List<Transform> models;
    private void Awake()
    {
        models = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var model = transform.GetChild(i);
            models.Add(model);
            model.gameObject.SetActive(i == 0);
        }
    }
    public void EnableModel(Transform modelTransform)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var transformChild = transform.GetChild(i);
            bool shouldBeActive = transformChild == modelTransform;

            transformChild.gameObject.SetActive(shouldBeActive);
        }
    }
    public List<Transform> GetModels()
    {
        return new List<Transform>(models);
    }
   
}
