namespace ExpressionEvaluator.UI.Win
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox display;
        private TableLayoutPanel panel;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            display = new TextBox();
            panel = new TableLayoutPanel();
            SuspendLayout();
            //
            // display
            //
            display.BackColor = Color.FromArgb(0, 160, 0);
            display.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            display.BorderStyle = BorderStyle.FixedSingle;
            display.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            display.ForeColor = Color.White;
            display.Location = new Point(12, 14);
            display.Name = "display";
            display.ReadOnly = true;
            display.ScrollBars = ScrollBars.Horizontal;
            display.Size = new Size(536, 39);
            display.TabIndex = 0;
            display.Text = string.Empty;
            display.TextAlign = HorizontalAlignment.Right;
            display.WordWrap = false;
            //
            // panel
            //
            panel.BackColor = Color.Black;
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.ColumnCount = 6;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.42858F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.42858F));
            panel.Location = new Point(12, 72);
            panel.Name = "panel";
            panel.RowCount = 4;
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panel.Size = new Size(536, 441);
            panel.TabIndex = 1;

            AddButton("7", Color.WhiteSmoke, 0, 0, 1);
            AddButton("8", Color.WhiteSmoke, 1, 0, 1);
            AddButton("9", Color.WhiteSmoke, 2, 0, 1);
            AddButton("(", Color.DarkOrange, 3, 0, 1);
            AddButton(")", Color.DarkOrange, 4, 0, 1);
            AddButton("Delete", Color.DarkOrange, 5, 0, 1);
            AddButton("4", Color.WhiteSmoke, 0, 1, 1);
            AddButton("5", Color.WhiteSmoke, 1, 1, 1);
            AddButton("6", Color.WhiteSmoke, 2, 1, 1);
            AddButton("*", Color.DarkOrange, 3, 1, 1);
            AddButton("/", Color.DarkOrange, 4, 1, 1);
            AddButton("Clear", Color.DarkOrange, 5, 1, 1);
            AddButton("1", Color.WhiteSmoke, 0, 2, 1);
            AddButton("2", Color.WhiteSmoke, 1, 2, 1);
            AddButton("3", Color.WhiteSmoke, 2, 2, 1);
            AddButton("+", Color.DarkOrange, 3, 2, 1);
            AddButton("-", Color.DarkOrange, 4, 2, 1);
            AddButton("^", Color.DarkOrange, 5, 2, 1);
            AddButton("0", Color.WhiteSmoke, 0, 3, 2);
            AddButton(".", Color.WhiteSmoke, 2, 3, 1);
            AddButton("=", Color.DarkOrange, 3, 3, 3);
            //
            // Form1
            //
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(560, 525);
            Controls.Add(panel);
            Controls.Add(display);
            MinimumSize = new Size(520, 520);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Functions Evaluator";
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddButton(string text, Color backColor, int column, int row, int columnSpan)
        {
            var button = new Button();
            button.BackColor = backColor;
            button.Dock = DockStyle.Fill;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button.ForeColor = Color.Black;
            button.Margin = new Padding(5);
            button.Name = $"btn{text}";
            button.TabIndex = 0;
            button.Text = text;
            button.UseVisualStyleBackColor = false;
            button.Click += OnButtonClick;
            panel.Controls.Add(button, column, row);
            if (columnSpan > 1)
            {
                panel.SetColumnSpan(button, columnSpan);
            }
        }

        #endregion
    }
}
