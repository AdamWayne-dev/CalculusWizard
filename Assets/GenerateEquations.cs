using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR;

public class GenerateEquations : MonoBehaviour
{
    List<string> diff_LeftHand_Equations = new List<string>();
    List<string> diff_RightHand_Equations = new List<string>();
    HashSet<string> diff_LeftHand_To_Return = new HashSet<string>();
    HashSet<string> diff_RightHand_To_Return = new HashSet<string>();

    List<string> integral_LeftHand_Equations = new List<string>();
    List<string> integral_RightHand_Equations = new List<string>();
    HashSet<string> integral_LeftHand_To_Return = new HashSet<string>();
    HashSet<string> integral_RightHand_To_Return = new HashSet<string>();

    void Start()
    {
        Populate_Diff_LeftHand_Equations();
        Populate_Diff_RightHand_Equations();
        Populate_Integral_LeftHand_Equations();
        Populate_Integral_RightHand_Equations();
        Set_Diff_Equations();
        Set_Integral_Equations();
    }

    
    void Update()
    {
        
    }

    private void Populate_Diff_LeftHand_Equations() // Add left-hand differential equations to this list
    {
        diff_LeftHand_Equations.Add("1 + 2");
        diff_LeftHand_Equations.Add("2 + 3");
        diff_LeftHand_Equations.Add("3 + 4");
        diff_LeftHand_Equations.Add("4 + 5");
        diff_LeftHand_Equations.Add("5 + 6");
        diff_LeftHand_Equations.Add("6 + 7");
        diff_LeftHand_Equations.Add("7 + 8");
        diff_LeftHand_Equations.Add("8 + 9");
        diff_LeftHand_Equations.Add("9 + 10");
        diff_LeftHand_Equations.Add("10 + 11");
        diff_LeftHand_Equations.Add("11 + 12");
        diff_LeftHand_Equations.Add("12 + 13");
        diff_LeftHand_Equations.Add("13 + 14");
        diff_LeftHand_Equations.Add("14 + 15");
    }

    private void Populate_Diff_RightHand_Equations() // Add right-hand equations to this list (remember to match with same left-hand counterpart index)
    {
        diff_RightHand_Equations.Add("= 3");
        diff_RightHand_Equations.Add("= 5");
        diff_RightHand_Equations.Add("= 7");
        diff_RightHand_Equations.Add("= 9");
        diff_RightHand_Equations.Add("= 11");
        diff_RightHand_Equations.Add("= 13");
        diff_RightHand_Equations.Add("= 15");
        diff_RightHand_Equations.Add("= 17");
        diff_RightHand_Equations.Add("= 19");
        diff_RightHand_Equations.Add("= 21");
        diff_RightHand_Equations.Add("= 23");
        diff_RightHand_Equations.Add("= 25");
        diff_RightHand_Equations.Add("= 27");
        diff_RightHand_Equations.Add("= 29");

    }

    private void Populate_Integral_LeftHand_Equations() // Add left-hand integral equations to this list
    {
        integral_LeftHand_Equations.Add("30 - 1");
        integral_LeftHand_Equations.Add("29 - 2");
        integral_LeftHand_Equations.Add("28 - 3");
        integral_LeftHand_Equations.Add("27 - 4");
        integral_LeftHand_Equations.Add("26 - 5");
        integral_LeftHand_Equations.Add("25 - 6");
        integral_LeftHand_Equations.Add("24 - 7");
        integral_LeftHand_Equations.Add("23 - 8");
        integral_LeftHand_Equations.Add("22 - 9");
        integral_LeftHand_Equations.Add("21 - 10");
        integral_LeftHand_Equations.Add("20 - 11");
        integral_LeftHand_Equations.Add("19 - 12");
        integral_LeftHand_Equations.Add("18 - 13");
        integral_LeftHand_Equations.Add("17 - 14");
    }

    private void Populate_Integral_RightHand_Equations() // Add right-hand equations to this list (remember to match with same left-hand counterpart index)
    {
        integral_RightHand_Equations.Add("= 29");
        integral_RightHand_Equations.Add("= 27");
        integral_RightHand_Equations.Add("= 25");
        integral_RightHand_Equations.Add("= 23");
        integral_RightHand_Equations.Add("= 21");
        integral_RightHand_Equations.Add("= 19");
        integral_RightHand_Equations.Add("= 17");
        integral_RightHand_Equations.Add("= 15");
        integral_RightHand_Equations.Add("= 13");
        integral_RightHand_Equations.Add("= 11");
        integral_RightHand_Equations.Add("= 9");
        integral_RightHand_Equations.Add("= 7");
        integral_RightHand_Equations.Add("= 5");
        integral_RightHand_Equations.Add("= 3");
    }
    private void Set_Diff_Equations()
    {
        while (diff_LeftHand_To_Return.Count != 7)
        {
            int rand = Random.Range(0, diff_LeftHand_Equations.Count);
            diff_LeftHand_To_Return.Add(diff_LeftHand_Equations[rand]);
            diff_RightHand_To_Return.Add(diff_RightHand_Equations[rand]);
        }
        
    }

    private void Set_Integral_Equations()
    {
        while (integral_LeftHand_To_Return.Count != 7)
        {
            int rand = Random.Range(0, integral_LeftHand_Equations.Count);
            integral_LeftHand_To_Return.Add(integral_LeftHand_Equations[rand]);
            integral_RightHand_To_Return.Add(integral_RightHand_Equations[rand]);
        }
    }

    public HashSet<string> Get_LeftHand_Diff_Equations()
    {
        return diff_LeftHand_To_Return;
    }

    public HashSet<string> Get_RightHand_Diff_Equations()
    {
        return diff_RightHand_To_Return;
    }

    public HashSet<string> Get_LeftHand_Int_Equations()
    {
        return integral_LeftHand_To_Return;
    }

    public HashSet<string> Get_RightHand_Int_Equations()
    {
        return integral_RightHand_To_Return;
    }
   
}
