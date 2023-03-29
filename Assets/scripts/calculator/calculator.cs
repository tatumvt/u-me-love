using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Globalization;
using NCalc;

public class calculator : MonoBehaviour
{
    public string Calculate(string equation)
    {
        Expression expression = new Expression(equation);
        return expression.Evaluate().ToString();
    }
    /* #region Fields
     [SerializeField]
     TextMeshProUGUI InputField;

     string inputString;
     float[] number = new float[2];
     string operatorSymbol;
     int i;
     float result;
     int maxDigits = 11;
     bool isFirst = true;
     bool displayedResuls = false;
     #endregion Fields

     #region Methods
     public void ButtonPressed()
     {
         if (displayedResuls == true)
         {
             InputField.text = "";
             inputString = "";
             displayedResuls = false;
         }
         //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
         string buttonValue = EventSystem.current.currentSelectedGameObject.name;
         inputString += buttonValue;

         float arg;
         if(float.TryParse(buttonValue, out arg))
         {
             number[i] = float.Parse(number[i].ToString() + arg.ToString());

         } else
         {
             switch (buttonValue)
             {
                 case "+":
                     i = 1;
                     operatorSymbol = buttonValue;
                     break;
                 case "-":
                     i = 1;
                     operatorSymbol = buttonValue;
                     break;
                 case "*":
                     i = 1;
                     operatorSymbol = buttonValue;
                     break;
                 case "/":
                     i = 1;
                     operatorSymbol = buttonValue;
                     break;
                 case "=":
                     switch (operatorSymbol)
                     {
                         case "+":
                             Debug.Log("number 1: " + number[0]);
                             Debug.Log("number 2: " + number[1]);
                             result = number[0] + number[1];
                             break;
                         case "-":
                             result = number[0] - number[1];
                             break;
                         case "*":
                             Debug.Log("number 1: " + number[0]);
                             Debug.Log("number 2: " + number[1]);
                             result = number[0] * number[1];
                             break;
                         case "/":
                             result = number[0] / number[1];
                             break;

                     }
                     displayedResuls = true;
                     i = 0;
                     inputString = result.ToString();
                     number = new float[2];
                     Debug.Log(result);
                     break;
             }
         }

         InputField.text = inputString;
     }
 *//*    private void StoreCurrentNumberInReg(int regNumber)
     {
         number[regNumber] = int.Parse(inputString, CultureInfo.InvariantCulture.NumberFormat);
     }
     private void AppendNumber(string s)
     {
         if ((inputString == "0"))
             inputString = (s == ".") ? "0." : s;
         else
             if (inputString.Length < maxDigits)
             inputString += s;

         if (displayedResuls)
             displayedResuls = false;
         StoreCurrentNumberInReg(isFirst ? 0 : 1);
     }*//*
         public void ClearInput()
     {
             InputField.text = "";
             inputString = "";
             displayedResuls = false;
     }
     #endregion Methods

 */
}
