using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace compiler_phase1
{

    public partial class Form2 : Form
    {
        List<string> declaredintvariables = new List<string>();
        List<string> declaredfloatvariables = new List<string>();
        List<string> declaredcharvariables = new List<string>();
        List<string> declareddoubblevariables = new List<string>();
        List<string> declaredboolvariables = new List<string>();
        // Dictionary to store variable values
        public Dictionary<string, List<string>> memory = new Dictionary<string, List<string>>();
        string identifierspattern;
        string variablespattern;
        string operatorspattern;
        string symbolspattern;
        string reservedpattern;
        int ct = 0, ct2 = 0, ct3 = 0, ct4 = 0, ct5 = 0, ct6 = 0, ct7 = 0, ct8 = 0, ct9 = 0;
        int i, k, t;
        //char[] y=new char[200000];
        public Form2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = System.Drawing.Image.FromFile(@"D:\MSA\Compiler Design\Phase 1 compiler design\write black.png");
        }

        public void button1_Click(object sender, EventArgs e)
        {
            // regular expression for identifiers //
            identifierspattern = @"\b(int|float|double|bool|char|string)\s+([a-zA-Z_][a-zA-Z0-9_]*)\b";
            // regular expression for variables and being one or more because if varibale consists of one or more letter //
            variablespattern = @"[a-zA-Z]+";
            // regullar expression for symbols //
            symbolspattern = @"[\+\-\*\/\%\]";
            // regular expression for operators bas && w || mesh shaghalen //
            operatorspattern = @"[\(\)\{\}\,\;\|\|\&\&\<\>\!\=]+";
            // regular expression for reserverd words //
            reservedpattern = @"\b(for|while|if|do|return|break|continue|end)\b";
            MatchCollection m = Regex.Matches(richTextBox1.Text, identifierspattern + "|" + variablespattern + "|" + symbolspattern + "|" + operatorspattern + "|" + reservedpattern);
            string[] lines = richTextBox1.Text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (Match m2 in m)
            {

                if (m2.Groups[1].Success)
                {
                    listBox1.Items.Add("i found an identifier" + " " + m2.Groups[1].Value + Environment.NewLine);
                }
                if (m2.Groups[2].Success)
                {
                    listBox1.Items.Add("i found a variable" + " " + m2.Groups[2].Value + Environment.NewLine);
                }
                if (m2.Value == "+" || m2.Value == "-" || m2.Value == "*" || m2.Value == "/" || m2.Value == "%" || m2.Value == "--" || m2.Value == "++")
                {
                    listBox1.Items.Add("i found a symbol" + " " + m2.Value + Environment.NewLine);
                }
                if (m2.Value == "(" || m2.Value == ")" || m2.Value == "{" || m2.Value == "}" || m2.Value == "," || m2.Value == ";" || m2.Value == "||" || m2.Value == "&&" || m2.Value == "<" || m2.Value == ">" || m2.Value == "!" || m2.Value == "=" || m2.Value == "==" || m2.Value == ">=" || m2.Value == "<=")
                {
                    listBox1.Items.Add("i found an operator" + " " + m2.Value + Environment.NewLine);
                }
                if (m2.Value == "for" || m2.Value == "if" || m2.Value == "while" || m2.Value == "do" || m2.Value == "dowhile" || m2.Value == "else if" || m2.Value == "return" || m2.Value == "break" || m2.Value == "continue" || m2.Value == "end")
                {
                    listBox1.Items.Add("i found a reserved word" + " " + m2.Value + Environment.NewLine);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            richTextBox1.Clear();
            memory.Clear();
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // int pattern
            string intPattern = @"^(int)\s*(?<name>[a-zA-Z_]\w*)\s*(==|!=|>=|<=|=)\s*(?<value>\d+)\s*;$";
            string intPattern2 = @"^(int)\s*(?<name>[a-zA-Z_]\w*)\s*(==|!=|>=|<=)\s*(?<value>\d+)\s*$";
            Regex intRegex = new Regex(intPattern);
            Regex intRegex2 = new Regex(intPattern2);


            // float pattern
            string floatPattern = @"^(float)\s+(?<name>[a-zA-Z_]\w*)\s*=\s*(?<value>\d+(\.\d+)?)\s*;$";
            string floatPattern2 = @"^(float)\s+(?<name>[a-zA-Z_]\w*)\s*(==|!=|>=|<=)\s*(?<value>\d+)\s*$";
            Regex floatRegex = new Regex(floatPattern);
            Regex floatRegex2 = new Regex(floatPattern2);


            // char pattern
            string charPattern = @"^(char)\s+(?<name>[a-zA-Z_]\w*)\s*=\s*'(?<value>[a-z])'\s*;$";
            string charPattern2 = @"^(char)\s+(?<name>[a-zA-Z_]\w*)\s*(==|!=|>=|<=)\s*(?<value>\d+)\s*$";
            Regex charRegex = new Regex(charPattern);
            Regex charRegex2 = new Regex(charPattern2);


            // double pattern
            string doublePattern = @"^(double)\s+(?<name>[a-zA-Z_]\w*)\s*=\s*(?<value>\d+(\.\d+)?)\s*;$";
            string doublePattern2 = @"^(double)\s+(?<name>[a-zA-Z_]\w*)\s*(==|!=|>=|<=)\s*(?<value>\d+)\s*$";
            Regex doubleRegex = new Regex(doublePattern);
            Regex doubleRegex2 = new Regex(doublePattern2);


            // bool pattern
            string boolPattern = @"^(bool)\s+(?<name>[a-zA-Z_]\w*)\s*=\s*(?<value>true|false)\s*;$";
            string boolPattern2 = @"^(bool)\s+(?<name>[a-zA-Z_]\w*)\s*(==|!=|>=|<=)\s*(?<value>\d+)\s*$";
            Regex boolRegex = new Regex(boolPattern);
            Regex boolRegex2 = new Regex(boolPattern2);


            // declaring variables without assining a value in them
            string patternwithoutassinignvalue = @"^(int|float|double|char|bool)\s+(?<name>[a-zA-Z_]\w*)\s*;$";
            string patternwithoutassinignvalue2 = @"^(int|float|double|char|bool)\s+(?<name>[a-zA-Z_]\w*)\s*;$";
            Regex woutaasign = new Regex(patternwithoutassinignvalue);
            Regex woutaasign2 = new Regex(patternwithoutassinignvalue2);


            //string pattern = "(" + intPattern + ")|(" + floatPattern + ")|(" + charPattern + ")|(" + doublePattern + ")|(" + boolPattern + ")";
            string input = richTextBox1.Text;
            string[] lines = richTextBox1.Text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (richTextBox1.Text.Contains("int") || richTextBox1.Text.Contains("float") || richTextBox1.Text.Contains("char") || richTextBox1.Text.Contains("double") || richTextBox1.Text.Contains("bool")) ;
            {
                foreach (string line in lines)
                {
                    // checks the variable is declared correctly or not for "int" //
                    Match intMatch = intRegex.Match(line);
                    Match intMatch2 = intRegex2.Match(line);
                    if (intMatch.Success)
                    {
                        // check if the variable has already been declared
                        string name = intMatch.Groups["name"].Value;
                        string value = intMatch.Groups["value"].Value;
                        listBox1.Items.Add($"i found an integer variable {name} with value {value}");
                    }
                    // checks the variable is declared correctly or not for "float" //
                    Match floatMatch = floatRegex.Match(line);
                    Match floatMatch2 = floatRegex2.Match(line);
                    if (floatMatch.Success)
                    {
                        string name = floatMatch.Groups["name"].Value;
                        string value = floatMatch.Groups["value"].Value;
                        listBox1.Items.Add($"i found a float variable {name} with value {value}");
                        ct2++;
                    }
                    // checks the variable is declared correctly or not for "char" //
                    Match charMatch = charRegex.Match(line);
                    Match charMatch2 = charRegex2.Match(line);
                    if (charMatch.Success)
                    {
                        string name = charMatch.Groups["name"].Value;
                        string value = charMatch.Groups["value"].Value;
                        listBox1.Items.Add($"i found a char variable {name} with value {value}");
                        ct3++;
                    }
                    // checks the variable is declared correctly or not for "double" //
                    Match doubleMatch = doubleRegex.Match(line);
                    Match doubleMatch2 = doubleRegex2.Match(line);
                    if (doubleMatch.Success)
                    {
                        string name = doubleMatch.Groups["name"].Value;
                        string value = doubleMatch.Groups["value"].Value;
                        listBox1.Items.Add($"i found a double variable {name} with value {value}");
                        ct4++;
                    }
                    // checks the variable is declared correctly or not for "bool" //
                    Match boolMatch = boolRegex.Match(line);
                    Match boolMatch2 = boolRegex2.Match(line);
                    if (boolMatch.Success)
                    {
                        string name = boolMatch.Groups["name"].Value;
                        string value = boolMatch.Groups["value"].Value;
                        listBox1.Items.Add($"i found a boolean variable {name} with value {value}");
                        ct5++;
                    }
                    // checks the variable is declared correctly or not for not assigned variables "with no number only created" //
                    Match withoutassign = woutaasign.Match(line);
                    Match withoutassign2 = woutaasign2.Match(line);
                    if (withoutassign.Success)
                    {
                        string name = boolMatch.Groups["name"].Value;
                        listBox1.Items.Add($"i found a declared variable {name}");
                    }
                }
            }


            if (richTextBox1.Text.Contains("if") && !richTextBox1.Text.Contains("else")) // if the richbox text start with if and not contain else then it's if statement only
            {
                ct7++;
            }
            else if (richTextBox1.Text.Contains("else")) // if the richbox text start with if and contain else then it's if-else statement 
            {
                ct8++;
            }

            if (ct7 == 1)
            {
                //if statement check 
                string ifstatement =@"^(if)\s*\(((int|float|char|double|bool)\s*(?<name>[a-zA-Z_]\w*)\s*(=|<=|>=|!=|==|\+=)\s*(\d+(\.\d+)?|'?[a-zA-Z]'?|true|false))?\)\s*\{(\s*(int|float|char|double|bool)\s*(?<name>[a-zA-Z_]\w*)\s*(=|<=|>=|!=|==|\+=)\s*(\d+(\.\d+)?|'?[a-zA-Z]'?|true|false)\s*;\s*)\s*\}$";

                Regex ifstat = new Regex(ifstatement);
                foreach (string line in lines)
                {
                    Match ifstatemen = ifstat.Match(line);
                    if (ifstatemen.Success)
                    {
                        listBox1.Items.Add("i found a correct if statement");  // found a correct if logic
                    }
                    else
                    {
                        listBox1.Items.Add("invalid if statement");  // found a wrong if logic
                    }
                }
                ct7 = 0;
            }

            if (ct8 == 1)
            {
                //if-else statement check
                string ifelse = @"^(if)\s*\((int|float|char|double|bool)\s+(?<name>[a-zA-Z_]\w*)(\s*(=|<=|>=|!=|==|++|--|+=)\s*(\d+(\.\d+)?|'?[a-zA-Z]'?|true|false))?\)\s*\{(\s*(int|float|char|double|bool)\s+(?<name>[a-zA-Z_]\w*)\s*(=|<=|>=|!=|==)\s*(\d+(\.\d+)?|'?[a-zA-Z]'?|true|false)\s*;\s*)*\s*\}\s*(else)\s*{\s*((char|double|float|int|bool)\s+(?<name>[a-zA-Z_]\w*)\s*(=|==|<=|>=|!=)?\s*(?<value>\d+(\.\d+)?|'?[a-zA-Z]'?|true|false)?\s*;)\s*}";
                Regex ifelsest = new Regex(ifelse);

                foreach (string line in lines)
                {
                    Match ifelsestatemen = ifelsest.Match(line);
                    if (ifelsestatemen.Success)
                    {
                        listBox1.Items.Add("I found a correct if-else statement"); // found a correct if-else logic
                    }
                    else
                    {
                        listBox1.Items.Add("invalid if-else statement"); // found a wrong if-else logic
                    }
                }
                ct8 = 0;
            }

            if (richTextBox1.Text.StartsWith("do") && richTextBox1.Text.Contains("while"))
            {
                ct9++;
            }
            if (ct9 == 1)
            {
                string dowhile = @"^do\s*\{(\s*((int|float|double|char|bool)\s+(?<var1>[a-zA-Z_]\w*)(\s*(=|<=|>=|!=|==)\s*\d+)?|([a-zA-Z](?=(_?\w))\w*))\s*(=|<=|>=|!=|==)\s*((int|float|double|char|bool)\s+(?<var2>[a-zA-Z_]\w*)|(?<var2>[a-zA-Z_]\w*)|(\d+(\.\d+)?|'?[a-zA-Z]'?|true|false))\s*;\s*)*\s*\}\s*while\s*\(\s*((int|float|double|char|bool)\s+[a-zA-Z_]\w*|(?<var3>[a-zA-Z_]\w*))\s*(=|<=|>=|!=|==)\s*((?<var4>[a-zA-Z_]\w*)|(\d+(\.\d+)?|'?[a-zA-Z]'?|true|false))\s*\)\s*";
                Regex dowhilee = new Regex(dowhile);
                foreach (string line in lines)
                {
                    Match dowhil = dowhilee.Match(line);
                    if (dowhil.Success)
                    {
                        listBox1.Items.Add("i found a correct do-while loop");
                    }
                    else
                    {
                        listBox1.Items.Add("invalid do-while loop");
                    }
                }
                ct9 = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Get the code from the text box
            string text = richTextBox1.Text;

            // Update the memory with variable assignments and expressions
            UpdateMemory(text);

            // Display the value history for variables "x" and "y"
            DisplayValueHistory();
        }




        // Update the memory with variable assignments and expressions
        private void UpdateMemory(string code)
        {
            // Regular expression patterns for variable assignments and expressions
            string assignmentPattern = @"(\w+)\s*=\s*(\d+|[a-zA-Z]\w*|'[^']*')\s*;";
            string expressionPattern = @"(\w+)\s*=\s*((\d+|[a-zA-Z]\w*)\s*([+\-*\/]\s*(\d+|[a-zA-Z]\w*)\s*)+)\s*;";

            // Match variable assignments in the text and update the memory
            MatchCollection assignments = Regex.Matches(code, assignmentPattern);
            foreach (Match match in assignments)
            {
                string varName = match.Groups[1].Value;
                string varValue = match.Groups[2].Value;

                // Check if the variable already exists in the memory
                if (memory.ContainsKey(varName))
                {
                    // Add the new value to the existing variable's value list
                    memory[varName].Add(varValue);
                }
                else
                {
                    // Create a new value list for the variable and add the value
                    memory[varName] = new List<string> { varValue };
                }
            }

            // Match expressions in the richboxtext and update the memory
            MatchCollection expressions = Regex.Matches(code, expressionPattern);
            foreach (Match match in expressions)
            {
                string varName = match.Groups[1].Value;
                string expression = match.Groups[2].Value;

                // Evaluate the expression and get the result
                string result = EvaluateExpression(expression);

                // Check if the variable already exists in the memory
                if (memory.ContainsKey(varName))
                {
                    // Add the new result to the existing variable's value list
                    memory[varName].Add(result);
                }
                else
                {
                    // Create a new value list for the variable and add the result
                    memory[varName] = new List<string> { result };
                }
            }
        }


        // Evaluate the expression and return the result
        private string EvaluateExpression(string expression)
        {
            // Replace variable names with their corresponding values in the expression
            foreach (var entry in memory)
            {
                expression = expression.Replace(entry.Key, entry.Value[entry.Value.Count - 1]);
            }

            // Use the DataTable.Compute method to evaluate the expression and get the result
            return new DataTable().Compute(expression, null).ToString();
        }


        // Display the value history for the specified variable
        private void DisplayValueHistory()
        {

            foreach (string variableName in memory.Keys)
            {
                listBox1.Items.Add($"history of {variableName}");
                List<string> variableHistory = memory[variableName];
                foreach (string value in variableHistory)
                {
                    listBox1.Items.Add($"{value} ");
                }
                listBox1.Items.Add(Environment.NewLine);
            }
        }
    }
}
