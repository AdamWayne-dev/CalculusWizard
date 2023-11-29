using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegrelColour : MonoBehaviour
{
    [SerializeField] CycleSpells cycleSpells;
    [SerializeField] SpriteRenderer spriteRenderer;
    private int currentSpellIndex;

    public Color fireSpell;
    public Color waterSpell;
    public Color earthSpell;
    public Color lightningSpell;

    // Update is called once per frame
    void Update()
    {
        GetSpellIndex();
        SetIntegralColour();
    }

    private void SetIntegralColour() // Changes the colour of the Integral based on the curren spell index.
    {
        switch (currentSpellIndex)
        {
            case 0: spriteRenderer.color = fireSpell;
                    break;

            case 1: spriteRenderer.color = waterSpell;
                    break;

            case 2: spriteRenderer.color = earthSpell;
                    break;

            case 3: spriteRenderer.color = lightningSpell;
                    break;
        }
    }

    private void GetSpellIndex() // Retrieves the spell index from the cyclespells script.
    {
        currentSpellIndex = cycleSpells.GetSpellIndex();
    }
}
