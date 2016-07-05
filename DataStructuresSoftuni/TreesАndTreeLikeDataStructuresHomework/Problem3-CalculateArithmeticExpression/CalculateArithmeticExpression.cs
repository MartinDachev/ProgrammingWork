using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Problem3_CalculateArithmeticExpression
{
    class CalculateArithmeticExpression
    {
        static bool IsDigitOrDot(char token)
        {
            bool result = (token >= '0' && token <= '9' || token == '.');

            return result;
        }

        static bool IsNumber(string token)
        {
            double number;

            return double.TryParse(token, out number);
        }

        static bool IsOperator(char token)
        {
            bool result = (token == '+' || token == '-' || token == '*' || token == '/');

            return result;
        }

        static bool IsLeftParenthesis(char token)
        {
            bool result = (token == '(');

            return result;
        }

        static bool IsRightParenthesis(char token)
        {
            bool result = (token == ')');

            return result;
        }

        static bool IsUnaryMinus(string expression, int position)
        {
            bool result = false;

            if (expression[position] == '-')
            {
                if (position == 0 || IsOperator(expression[position - 1]) || IsLeftParenthesis(expression[position - 1]))
                {
                    result = true;
                }
            }

            return result;
        }

        static int GetOperatorPrecedence(char token)
        {
            switch (token)
            {
                case '+':
                case '-':
                    return 2;
                case '*':
                case '/':
                    return 3;
                default: return 0;
            }
        }

        static Queue<string> CovertInfixExpressionToRPN(string expression)
        {
            char currentToken;
            Queue<string> outputQueue = new Queue<string>();
            Stack<char> operatorsStack = new Stack<char>();
            StringBuilder numberStringBuilder = new StringBuilder();
            bool haveUnaryMinus = false;

            for (int position = 0; position < expression.Length; ++position)
            {
                currentToken = expression[position];

                if (IsDigitOrDot(currentToken))
                {
                    numberStringBuilder.Clear();
                    
                    if (haveUnaryMinus)
                    {
                        numberStringBuilder.Append('-');
                        haveUnaryMinus = false;
                    }

                    numberStringBuilder.Append(currentToken);
                    ++position;

                    while (position < expression.Length && IsDigitOrDot(expression[position]))
                    {
                        numberStringBuilder.Append(expression[position]);
                        ++position;
                    }

                    --position;
                    outputQueue.Enqueue(numberStringBuilder.ToString());
                }

                else if (IsOperator(currentToken))
                {
                    if (IsUnaryMinus(expression, position))
                    {
                        haveUnaryMinus = true;
                    }
                    else
                    {
                        while (operatorsStack.Count > 0 && (!IsLeftParenthesis(operatorsStack.Peek()) && GetOperatorPrecedence(currentToken) <= GetOperatorPrecedence(operatorsStack.Peek())))
                        {
                            outputQueue.Enqueue(operatorsStack.Pop().ToString());
                        }

                        operatorsStack.Push(currentToken);
                    }
                }

                else if (IsLeftParenthesis(currentToken))
                {
                    operatorsStack.Push(currentToken);
                }

                else if (IsRightParenthesis(currentToken))
                {
                    while (operatorsStack.Count > 0 && operatorsStack.Peek() != '(')
                    {
                        outputQueue.Enqueue(operatorsStack.Pop().ToString());
                    }

                    if (operatorsStack.Count > 0)
                    {
                        operatorsStack.Pop();
                    }
                }
            }

            while (operatorsStack.Count > 0)
            {
                outputQueue.Enqueue(operatorsStack.Pop().ToString());
            }

            return outputQueue;
        }

        static double CalculateRPN(Queue<string> rpnQueue)
        {
            string currentToken;
            Stack<double> numbersStack = new Stack<double>();
            double calculatedResult;

            while(rpnQueue.Count > 0)
            {
                currentToken = rpnQueue.Dequeue();

                if (IsNumber(currentToken))
                {
                    numbersStack.Push(double.Parse(currentToken));
                }
                else
                {
                    if(numbersStack.Count < 2)
                    {
                        throw new ArgumentException("The expression is not valid.");
                    }

                    double number1 = numbersStack.Pop();
                    double number2 = numbersStack.Pop();
                    double resultNumber = 0;

                    switch (currentToken)
                    {
                        case "+": resultNumber = number2 + number1;
                            break;
                        case "-": resultNumber = number2 - number1;
                            break;
                        case "*": resultNumber = number2 * number1;
                            break;
                        case "/": resultNumber = number2 / number1;
                            break;
                    }

                    numbersStack.Push(resultNumber);
                }
            }

            calculatedResult = numbersStack.Pop();

            return calculatedResult;
        }

        static double CalculateExpression(string expression)
        {
            double calculatedResult;
            expression = expression.Replace(" ", "");
            Queue<string> rpnQueue = CovertInfixExpressionToRPN(expression);

            calculatedResult = CalculateRPN(rpnQueue);

            return calculatedResult;
        }

        static void Main(string[] args)
        {
            //Setting invariant culture, or else Parsing methods may not work...
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string expression = Console.ReadLine();

            try
            {
                double calculatedResult = CalculateExpression(expression);
                Console.WriteLine("Result = {0}", calculatedResult);
            }
            catch(ArgumentException argumentEx)
            {
                Console.WriteLine("Error: " + argumentEx.Message);
            }
        }
    }
}
