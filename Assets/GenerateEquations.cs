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

    private void Populate_Diff_LeftHand_Equations() // Add left-hand differential equations to this list. Beware of using two equations with the same answer.
    {
        diff_LeftHand_Equations.Add("(x<sup>2</sup>)");
        diff_LeftHand_Equations.Add("(x<sup>3</sup>)");
        diff_LeftHand_Equations.Add("(x<sup>4</sup>)");
        diff_LeftHand_Equations.Add("(x<sup>5</sup>)");
        diff_LeftHand_Equations.Add("2x");
        diff_LeftHand_Equations.Add("(3x + 2)");
        diff_LeftHand_Equations.Add("(x<sup>2</sup> - 2x)");
        diff_LeftHand_Equations.Add("(5 + x<sup>3</sup>)");
        diff_LeftHand_Equations.Add("(4x - 1)");
        diff_LeftHand_Equations.Add("(1 - x<sup>2</sup>)");
        diff_LeftHand_Equations.Add("(-2x<sup>2</sup>)");
        diff_LeftHand_Equations.Add("(5)");
        diff_LeftHand_Equations.Add("(-3x)");
        diff_LeftHand_Equations.Add("(xe<sup>x</sup>)");
        diff_LeftHand_Equations.Add("(x ln x)");
        diff_LeftHand_Equations.Add("(e<sup>2x</sup>)");
        diff_LeftHand_Equations.Add("(e<sup>2<sup>2</sup></sup>)");
       
    }

    private void Populate_Diff_RightHand_Equations() // Add right-hand equations to this list (remember to match with same left-hand counterpart index)
    {
        diff_RightHand_Equations.Add("= 2x");
        diff_RightHand_Equations.Add("= 3x<sup>2</sup>");
        diff_RightHand_Equations.Add("= 4x<sup>3</sup>");
        diff_RightHand_Equations.Add("= 5x<sup>4</sup>");
        diff_RightHand_Equations.Add("= 2");
        diff_RightHand_Equations.Add("= 3");
        diff_RightHand_Equations.Add("= 2x - 2");
        diff_RightHand_Equations.Add("= 3x<sup>2</sup>");
        diff_RightHand_Equations.Add("= 4");
        diff_RightHand_Equations.Add("= -2x");
        diff_RightHand_Equations.Add("= -4x");
        diff_RightHand_Equations.Add("= 0");
        diff_RightHand_Equations.Add("= -3");
        diff_RightHand_Equations.Add("= e<sup>x</sup> + xe<sup>x</sup>");
        diff_RightHand_Equations.Add("= ln x + 1");
        diff_RightHand_Equations.Add("= 2e<sup>2x</sup>");
        diff_RightHand_Equations.Add("= 2xe<sup>x<sup>2</sup></sup>");

    }

    private void Populate_Integral_LeftHand_Equations() // Add left-hand integral equations to this list. Beware of using two equations with the same answer.
    {
        integral_LeftHand_Equations.Add("x<sup>2</sup> dx");
        integral_LeftHand_Equations.Add("x<sup>3</sup> dx");
        integral_LeftHand_Equations.Add("x<sup>4</sup> dx");
        integral_LeftHand_Equations.Add("x<sup>5</sup> dx");
        integral_LeftHand_Equations.Add("2x dx");
        integral_LeftHand_Equations.Add("3x<sup>2</sup> dx");
        integral_LeftHand_Equations.Add("sin(x) dx");
        integral_LeftHand_Equations.Add("cos(x) dx");
        integral_LeftHand_Equations.Add("sin(2x) dx");
        integral_LeftHand_Equations.Add("e<sup>x</sup> dx");
        integral_LeftHand_Equations.Add("e<sup>2x</sup> dx");
        integral_LeftHand_Equations.Add("e<sup>-x</sup> dx");
        integral_LeftHand_Equations.Add("ln(x) dx");
        integral_LeftHand_Equations.Add("ln(2x) dx");
    }

    private void Populate_Integral_RightHand_Equations() // Add right-hand equations to this list (remember to match with same left-hand counterpart index)
    {
        integral_RightHand_Equations.Add("= (1/3)x<sup>3</sup> + C");
        integral_RightHand_Equations.Add("= (1/4)x<sup>4</sup> + C");
        integral_RightHand_Equations.Add("= (1/5)x<sup>5</sup> + C");
        integral_RightHand_Equations.Add("= (1/6)x<sup>6</sup> + C");
        integral_RightHand_Equations.Add("= x<sup>2</sup> + C");
        integral_RightHand_Equations.Add("= x<sup>3</sup> + C");
        integral_RightHand_Equations.Add("= -cos(x) + C");
        integral_RightHand_Equations.Add("= sin(x) + C");
        integral_RightHand_Equations.Add("= (-1/2)cos(2x)<br> + C");
        integral_RightHand_Equations.Add("= e<sup>x</sup> + C");
        integral_RightHand_Equations.Add("= (1/2)e<sup>2x</sup><br> + C");
        integral_RightHand_Equations.Add("= -e<sup>-x</sup> + C");
        integral_RightHand_Equations.Add("= x ln(x) - x<br> + C");
        integral_RightHand_Equations.Add("= (x ln(2x) - x)<br> + C");
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
