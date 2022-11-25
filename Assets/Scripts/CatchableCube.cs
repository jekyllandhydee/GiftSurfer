using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CatchableCube : MonoBehaviour
{ //küplerin toplanýp toplanmadýðýný kontrol eden 
    private bool isAdded;
    private int index;
    [SerializeField] Catcher catcher;

    void Start()
    {
        isAdded = false;
    }

    void Update()
    {
        if (isAdded)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
    }

    public bool GetIsAdded()
    {
        return isAdded;
    } 

    public void MakeAdded()
    {
        isAdded = true;
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }
    //layer 6 trap
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            StartCoroutine(delay(other));
            PlayerAnimHandler.Instance.OnDamage();
        }
    }
    IEnumerator delay(Collider other)
    {
        this.transform.parent = null;
        GetComponent<BoxCollider>().enabled = false;
        other.gameObject.tag = "Untagged";
        yield return new WaitForSeconds(.5f);
        catcher.Height--;
    }
}
