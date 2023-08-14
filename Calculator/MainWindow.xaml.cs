using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string firstVal = "";
        private string secondVal = "";
        private char? operand = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void intButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                string content = clickedButton.Content.ToString();

                if (operand == null)
                {
                    UpdateValue(ref firstVal, content);
                }
                else
                {
                    UpdateValue(ref secondVal, content);
                }
            }
        }

        private void UpdateValue(ref string currentValue, string newValue)
        {
            if (currentValue.Length < 10)
            {
                if (!(newValue == "." && currentValue.Contains(".")))
                {
                    currentValue += newValue;
                    input.Text = currentValue;
                }
            }
        }

        private void OperandSet_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                operand = Convert.ToChar(clickedButton.Content.ToString());
                input.Text = "0";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            firstVal = "";
            secondVal = "";
            operand = null;
            input.Text = "0";
        }

        private void PerformOperation(char operation)
        {
            if (firstVal != "" && secondVal != "")
            {
                try
                {
                    decimal num1 = decimal.Parse(firstVal, CultureInfo.InvariantCulture);
                    decimal num2 = decimal.Parse(secondVal, CultureInfo.InvariantCulture);
                    decimal result = 0;

                    switch (operation)
                    {
                        case '+':
                            result = num1 + num2;
                            break;
                        case '-':
                            result = num1 - num2;
                            break;
                        case '%':
                            result = num1 % num2;
                            break;
                        case '⨯':
                            result = num1 * num2;
                            break;
                        case '÷':
                            result = num1 / num2;
                            break;
                    }

                    input.Text = result.ToString(CultureInfo.InvariantCulture);
                    firstVal = result.ToString(CultureInfo.InvariantCulture);
                    secondVal = "";
                    operand = null;
                }
                catch (Exception)
                {
                    ClearAll();
                }
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            if (operand.HasValue)
            {
                PerformOperation(operand.Value);
            }
        }
    }
}
