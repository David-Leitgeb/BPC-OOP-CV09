using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPC_OOP_CV09
{
    class Calculator
    {
        private enum State
        {
            FirstNumber,
            Operation,
            SecondNumber,
            Result
        };
        private State _state = State.FirstNumber;
        public string Display { get; set; }
        public string Memory { get; set; }
        private string currentNumber = "";
        private string firstNumber = "";
        private string secondNumber = "";
        private string memory = "";
        private string operation = "";
        public void Button(string button)
        {
            string value = "";

            switch (button)
            {
                case "0":
                    if (currentNumber == "0")
                    {

                    }
                    else
                    {
                        value = "0";
                    }
                    break;
                case "1":
                    value = "1";
                    break;
                case "2":
                    value = "2";
                    break;
                case "3":
                    value = "3";
                    break;
                case "4":
                    value = "4";
                    break;
                case "5":
                    value = "5";
                    break;
                case "6":
                    value = "6";
                    break;
                case "7":
                    value = "7";
                    break;
                case "8":
                    value = "8";
                    break;
                case "9":
                    value = "9";
                    break;
                case ".":
                    if (currentNumber.Contains(".")) { }
                    else
                    {
                        value = ".";
                    }
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    _state = State.Operation;
                    operation = button;
                    break;
                case "±":
                    currentNumber = Convert.ToString(Convert.ToDouble(currentNumber) * -1);
                    break;
                case "←":
                    if (currentNumber.Length != 0)
                    {
                        currentNumber = currentNumber.Remove(currentNumber.Length - 1, 1);
                    }
                    break;
                case "=":
                    _state = State.Result;
                    break;
                case "C":
                    currentNumber = "";
                    firstNumber = "";
                    secondNumber = "";
                    operation = "";
                    memory = "";
                    Memory = "";
                    _state = State.FirstNumber;

                    break;
                case "CE":
                    if (_state == State.FirstNumber)
                    {
                        firstNumber = "";
                        currentNumber = "";
                    }
                    else
                    {
                        operation = "";
                        secondNumber = "";
                        currentNumber = "";
                        Display = firstNumber;
                    }
                    break;
                case "MS":
                    if(_state == State.Result)
                    {
                        memory = Display;
                    }
                    else
                    {
                        memory = currentNumber;
                    }
                    Memory = "M";
                    break;
                case "MR":
                    currentNumber = memory;
                    break;
                case "MC":
                        memory = "";
                        Memory = "";
                    break;
                case "M+":
                    if (memory != "")
                    {
                        currentNumber = Convert.ToString(Convert.ToDouble(currentNumber) + Convert.ToDouble(memory));
                    }
                    break;
                case "M-":
                    if (memory != "")
                    {
                        currentNumber = Convert.ToString(Convert.ToDouble(currentNumber) - Convert.ToDouble(memory));
                    }
                    break;
            }
            switch (_state)
            {
                case State.FirstNumber:
                    currentNumber += value;
                    firstNumber = currentNumber;
                    Display = firstNumber;
                    break;
                case State.Operation:
                    currentNumber = "";
                    Display = firstNumber + operation;
                    _state = State.SecondNumber;
                    break;
                case State.SecondNumber:
                    currentNumber += value;
                    secondNumber = currentNumber;
                    Display = firstNumber + operation + secondNumber;
                    break;
                case State.Result:
                    if (firstNumber == "") { }
                    if ((firstNumber == "" || operation == "") && secondNumber == "")
                    {
                        Display = firstNumber;
                    }
                    else
                    {
                        Display = Convert.ToString(Calculate());
                        firstNumber = Display;                    
                    }
                    currentNumber = "";
                    operation = "";
                    _state = State.FirstNumber;
                    break;
            }
        }
        private double Calculate()
        {
            double operand1 = Convert.ToDouble(firstNumber);
            double operand2 = Convert.ToDouble(secondNumber);
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    if (operand2 == 0)
                    {
                        //throw new Exception("Dividing by zero!");
                        Display = "Math ERROR"; //Nějakým způsobem se mi podařilo úplně na konci cvičení tuhle podmínku rozbít
                    }
                    else
                    {
                        result = operand1 / operand2;
                    }
                    break;
            }
            return result;
        }

    }
}