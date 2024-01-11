using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntegrelColour : MonoBehaviour
{
    [SerializeField] CycleSpells cycleSpells;
    [SerializeField] SpriteRenderer spriteRenderer;
    private int currentSpellIndex;

    public Color fireSpell;
    public Color waterSpell;
    public Color earthSpell;
    public Color lightningSpell;
    public Color spell_5;
    public Color spell_6;
    public Color spell_7;

    // Update is called once per frame
    void Update()
    {
        GetSpellIndex();
        SetIntegralColour();
    }

    private void SetIntegralColour() // Changes the colour of the Integral based on the curren spell index.
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1: case 2:
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

                    case 4: spriteRenderer.color = spell_5;
                        break;

                    case 5: spriteRenderer.color = spell_6;
                        break;

                    case 6: spriteRenderer.color = spell_7;
                        break;
                }
            break;
            case 3:
                break;
    }
    }

    private void GetSpellIndex() // Retrieves the spell index from the cyclespells script.
    {
        currentSpellIndex = cycleSpells.GetSpellIndex();
    }
}
