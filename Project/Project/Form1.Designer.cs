namespace Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            Shapes = new ComboBox();
            ColorButton = new Button();
            UndoButton = new Button();
            redo = new Button();
            panel1 = new Panel();
            usedShape = new Label();
            usedCol = new Label();
            label2 = new Label();
            open = new Button();
            Save = new Button();
            ConfirmInput = new Button();
            sizeChanger = new TextBox();
            label1 = new Label();
            SideText = new Label();
            Area = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            undo = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Shapes
            // 
            Shapes.AutoCompleteMode = AutoCompleteMode.Suggest;
            Shapes.AutoCompleteSource = AutoCompleteSource.ListItems;
            Shapes.FormattingEnabled = true;
            Shapes.Items.AddRange(new object[] { "Square", "Triangle", "Hexagon" });
            Shapes.Location = new Point(2, 1);
            Shapes.Name = "Shapes";
            Shapes.Size = new Size(182, 33);
            Shapes.TabIndex = 0;
            Shapes.SelectedIndexChanged += Shapes_SelectedIndexChanged;
            // 
            // ColorButton
            // 
            ColorButton.Location = new Point(191, 1);
            ColorButton.Name = "ColorButton";
            ColorButton.Size = new Size(34, 33);
            ColorButton.TabIndex = 1;
            ColorButton.Text = "🎨";
            ColorButton.UseVisualStyleBackColor = true;
            ColorButton.Click += ColorButton_Click;
            // 
            // UndoButton
            // 
            UndoButton.Location = new Point(304, 1);
            UndoButton.Name = "UndoButton";
            UndoButton.Size = new Size(31, 33);
            UndoButton.TabIndex = 2;
            UndoButton.Text = "🗑️";
            UndoButton.UseVisualStyleBackColor = true;
            UndoButton.Click += Delete;
            // 
            // redo
            // 
            redo.Location = new Point(268, 1);
            redo.Name = "redo";
            redo.Size = new Size(30, 33);
            redo.TabIndex = 3;
            redo.Text = "↪️";
            redo.UseVisualStyleBackColor = true;
            redo.Click += RedoButton_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(usedShape);
            panel1.Controls.Add(usedCol);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(open);
            panel1.Controls.Add(Save);
            panel1.Controls.Add(ConfirmInput);
            panel1.Controls.Add(sizeChanger);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(SideText);
            panel1.Controls.Add(Area);
            panel1.Location = new Point(1198, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(358, 703);
            panel1.TabIndex = 4;
            // 
            // usedShape
            // 
            usedShape.AutoSize = true;
            usedShape.Location = new Point(19, 302);
            usedShape.Name = "usedShape";
            usedShape.Size = new Size(59, 25);
            usedShape.TabIndex = 14;
            usedShape.Text = "label3";
            // 
            // usedCol
            // 
            usedCol.AutoSize = true;
            usedCol.Location = new Point(19, 254);
            usedCol.Name = "usedCol";
            usedCol.Size = new Size(59, 25);
            usedCol.TabIndex = 13;
            usedCol.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 206);
            label2.Name = "label2";
            label2.Size = new Size(235, 25);
            label2.TabIndex = 12;
            label2.Text = "Most Used Shape and Color";
            // 
            // open
            // 
            open.Location = new Point(234, 11);
            open.Name = "open";
            open.Size = new Size(112, 35);
            open.TabIndex = 11;
            open.Text = "Load";
            open.UseVisualStyleBackColor = true;
            open.Click += Load_Click;
            // 
            // Save
            // 
            Save.Location = new Point(19, 11);
            Save.Name = "Save";
            Save.Size = new Size(112, 34);
            Save.TabIndex = 10;
            Save.Text = "save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // ConfirmInput
            // 
            ConfirmInput.Location = new Point(292, 152);
            ConfirmInput.Name = "ConfirmInput";
            ConfirmInput.Size = new Size(33, 32);
            ConfirmInput.TabIndex = 8;
            ConfirmInput.Text = "✅";
            ConfirmInput.UseVisualStyleBackColor = true;
            ConfirmInput.Click += ConfirmInput_Click;
            // 
            // sizeChanger
            // 
            sizeChanger.Location = new Point(177, 152);
            sizeChanger.Name = "sizeChanger";
            sizeChanger.Size = new Size(109, 31);
            sizeChanger.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 152);
            label1.Name = "label1";
            label1.Size = new Size(147, 25);
            label1.TabIndex = 6;
            label1.Text = "Type custom size";
            // 
            // SideText
            // 
            SideText.AutoSize = true;
            SideText.Location = new Point(19, 110);
            SideText.Name = "SideText";
            SideText.Size = new Size(59, 25);
            SideText.TabIndex = 1;
            SideText.Text = "label1";
            // 
            // Area
            // 
            Area.AutoSize = true;
            Area.Location = new Point(19, 68);
            Area.Name = "Area";
            Area.Size = new Size(59, 25);
            Area.TabIndex = 0;
            Area.Text = "label1";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // undo
            // 
            undo.Location = new Point(231, 1);
            undo.Name = "undo";
            undo.Size = new Size(30, 33);
            undo.TabIndex = 5;
            undo.Text = "↩";
            undo.UseVisualStyleBackColor = true;
            undo.Click += undo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1558, 899);
            Controls.Add(undo);
            Controls.Add(panel1);
            Controls.Add(redo);
            Controls.Add(UndoButton);
            Controls.Add(ColorButton);
            Controls.Add(Shapes);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            Paint += Painter;
            MouseDown += Mouse_Down;
            MouseMove += Mouse_Move;
            MouseUp += Mouse_Up;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox Shapes;
        private Button ColorButton;
        private Button UndoButton;
        private Button redo;
        private Panel panel1;
        private ContextMenuStrip contextMenuStrip1;
        private Label Area;
        private Label SideText;
        private Label label1;
        private TextBox sizeChanger;
        private Button ConfirmInput;
        private Button undo;
        private Button open;
        private Button Save;
        private Label usedCol;
        private Label label2;
        private Label usedShape;
    }
}