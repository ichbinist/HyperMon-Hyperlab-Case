using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballController : MonoBehaviour
{
    public int PokeballIncreaseRate = 100;
    public GameObject PokeballPickUpEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Base.Runner.CharacterSettings>())
        {
            Base.Runner.CharacterManager.Instance.CurrentCharacter.PokeballCount += PokeballIncreaseRate;
            GameObject effect = Instantiate(PokeballPickUpEffect, transform.position, Quaternion.identity);
            effect.transform.parent = transform;
            effect.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
