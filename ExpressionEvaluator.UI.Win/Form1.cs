using System.Globalization;
using ExpressionEvaluator.Core;

namespace ExpressionEvaluator.UI.Win
{
    public partial class Form1 : Form
    {
        private string currentExpression = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            switch (button.Text)
            {
                case "Delete":
                    DeleteLastCharacter();
                    break;
                case "Clear":
                    ClearDisplay();
                    break;
                case "=":
                    EvaluateExpression();
                    break;
                default:
                    AppendInput(button.Text);
                    break;
            }
        }

        private void AppendInput(string value)
        {
            if (display.Text.Contains('='))
            {
                currentExpression = string.Empty;
                display.Text = string.Empty;
            }

            currentExpression += value;
            display.Text = currentExpression;
        }

        private void DeleteLastCharacter()
        {
            if (display.Text.Contains('='))
            {
                ClearDisplay();
                return;
            }

            if (currentExpression.Length == 0)
            {
                return;
            }

            currentExpression = currentExpression[..^1];
            display.Text = currentExpression;
        }

        private void ClearDisplay()
        {
            currentExpression = string.Empty;
            display.Text = string.Empty;
        }

        private void EvaluateExpression()
        {
            if (string.IsNullOrWhiteSpace(currentExpression))
            {
                return;
            }

            try
            {
                var result = Evaluator.Evaluate(currentExpression);
                display.Text = $"{currentExpression}={result.ToString(CultureInfo.InvariantCulture)}";
                currentExpression = result.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                display.Text = "Sintax error.";
                currentExpression = string.Empty;
            }
        }
    }
}
