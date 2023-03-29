using UnityEngine;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using System.IO;
using TMPro;

public class Calc : MonoBehaviour
{
    public TextMeshProUGUI somDisplay;
    public string som;
    public void AddCharacter(string value)
    {
        som += value;
        somDisplay.text = som;
    }

    public void ClearSom()
    {
        som = "";
        somDisplay.text = som;
    }

    public void CheckSom()
    {
        string answer = Evaluate(som);
        if (answer == "Error")
        {
            somDisplay.text = answer;
            som = "";
        }
        else
        {
            som = answer;
            somDisplay.text = som;
        }
    }

    public string Evaluate(string expression)
    {
        var xsltExpression =
            string.Format("number({0})",
                new Regex(@"([\+\-\*])").Replace(expression, " ${1} ")
                                        .Replace("/", " div ")
                                        .Replace("%", " mod "));

        double temp = (double)new XPathDocument
            (new StringReader("<r/>"))
                .CreateNavigator()
                .Evaluate(xsltExpression);

        bool test = double.IsNaN(temp);
        if (test)
        {
            return "Error";
        }
        else
        {
            return temp.ToString();
        }
    }
}
