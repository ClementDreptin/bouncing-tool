
namespace BouncingTool
{
	partial class BouncingTool
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.connectButton = new System.Windows.Forms.Button();
			this.strengthValueInput = new System.Windows.Forms.NumericUpDown();
			this.infectButton = new System.Windows.Forms.Button();
			this.strengthLabel = new System.Windows.Forms.Label();
			this.notesLabel = new System.Windows.Forms.Label();
			this.minValueLabel = new System.Windows.Forms.Label();
			this.maxValueLabel = new System.Windows.Forms.Label();
			this.recommendedValueLabel = new System.Windows.Forms.Label();
			this.elevatorsButton = new System.Windows.Forms.Button();
			this.elevatorsLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.strengthValueInput)).BeginInit();
			this.SuspendLayout();
			// 
			// connectButton
			// 
			this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.connectButton.Location = new System.Drawing.Point(12, 12);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(357, 58);
			this.connectButton.TabIndex = 0;
			this.connectButton.Text = "Connect";
			this.connectButton.UseVisualStyleBackColor = true;
			this.connectButton.Click += new System.EventHandler(this.OnConnectButtonClick);
			// 
			// strengthValueInput
			// 
			this.strengthValueInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.strengthValueInput.Location = new System.Drawing.Point(231, 148);
			this.strengthValueInput.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.strengthValueInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.strengthValueInput.Name = "strengthValueInput";
			this.strengthValueInput.Size = new System.Drawing.Size(138, 27);
			this.strengthValueInput.TabIndex = 1;
			this.strengthValueInput.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
			// 
			// infectButton
			// 
			this.infectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.infectButton.Location = new System.Drawing.Point(13, 125);
			this.infectButton.Name = "infectButton";
			this.infectButton.Size = new System.Drawing.Size(213, 50);
			this.infectButton.TabIndex = 2;
			this.infectButton.Text = "Infect with Knockback";
			this.infectButton.UseVisualStyleBackColor = true;
			this.infectButton.Click += new System.EventHandler(this.OnInfectButtonClick);
			// 
			// strengthLabel
			// 
			this.strengthLabel.AutoSize = true;
			this.strengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.strengthLabel.Location = new System.Drawing.Point(232, 125);
			this.strengthLabel.Name = "strengthLabel";
			this.strengthLabel.Size = new System.Drawing.Size(67, 18);
			this.strengthLabel.TabIndex = 3;
			this.strengthLabel.Text = "Strength:";
			// 
			// notesLabel
			// 
			this.notesLabel.AutoSize = true;
			this.notesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.notesLabel.Location = new System.Drawing.Point(12, 187);
			this.notesLabel.Name = "notesLabel";
			this.notesLabel.Size = new System.Drawing.Size(64, 20);
			this.notesLabel.TabIndex = 4;
			this.notesLabel.Text = "Notes:";
			// 
			// minValueLabel
			// 
			this.minValueLabel.AutoSize = true;
			this.minValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.minValueLabel.Location = new System.Drawing.Point(31, 217);
			this.minValueLabel.Name = "minValueLabel";
			this.minValueLabel.Size = new System.Drawing.Size(248, 18);
			this.minValueLabel.TabIndex = 5;
			this.minValueLabel.Text = "- The min (and default) value is 1000.";
			// 
			// maxValueLabel
			// 
			this.maxValueLabel.AutoSize = true;
			this.maxValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.maxValueLabel.Location = new System.Drawing.Point(31, 245);
			this.maxValueLabel.Name = "maxValueLabel";
			this.maxValueLabel.Size = new System.Drawing.Size(183, 18);
			this.maxValueLabel.TabIndex = 6;
			this.maxValueLabel.Text = "- The max value is 999999.";
			// 
			// recommendedValueLabel
			// 
			this.recommendedValueLabel.AutoSize = true;
			this.recommendedValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.recommendedValueLabel.Location = new System.Drawing.Point(31, 273);
			this.recommendedValueLabel.Name = "recommendedValueLabel";
			this.recommendedValueLabel.Size = new System.Drawing.Size(243, 18);
			this.recommendedValueLabel.TabIndex = 7;
			this.recommendedValueLabel.Text = "- The recommended value is 30000.";
			// 
			// elevatorsButton
			// 
			this.elevatorsButton.Enabled = false;
			this.elevatorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.elevatorsButton.Location = new System.Drawing.Point(16, 330);
			this.elevatorsButton.Name = "elevatorsButton";
			this.elevatorsButton.Size = new System.Drawing.Size(179, 50);
			this.elevatorsButton.TabIndex = 8;
			this.elevatorsButton.Text = "Toggle Elevators";
			this.elevatorsButton.UseVisualStyleBackColor = true;
			this.elevatorsButton.Click += new System.EventHandler(this.OnElevatorButtonClick);
			// 
			// elevatorsLabel
			// 
			this.elevatorsLabel.AutoSize = true;
			this.elevatorsLabel.Enabled = false;
			this.elevatorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.elevatorsLabel.Location = new System.Drawing.Point(227, 345);
			this.elevatorsLabel.Name = "elevatorsLabel";
			this.elevatorsLabel.Size = new System.Drawing.Size(0, 20);
			this.elevatorsLabel.TabIndex = 9;
			// 
			// BouncingTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(381, 404);
			this.Controls.Add(this.elevatorsLabel);
			this.Controls.Add(this.elevatorsButton);
			this.Controls.Add(this.recommendedValueLabel);
			this.Controls.Add(this.maxValueLabel);
			this.Controls.Add(this.minValueLabel);
			this.Controls.Add(this.notesLabel);
			this.Controls.Add(this.strengthLabel);
			this.Controls.Add(this.infectButton);
			this.Controls.Add(this.strengthValueInput);
			this.Controls.Add(this.connectButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "BouncingTool";
			this.Text = "MW2 Bouncing Tool";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClose);
			((System.ComponentModel.ISupportInitialize)(this.strengthValueInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button connectButton;
		private System.Windows.Forms.NumericUpDown strengthValueInput;
		private System.Windows.Forms.Button infectButton;
		private System.Windows.Forms.Label strengthLabel;
		private System.Windows.Forms.Label notesLabel;
		private System.Windows.Forms.Label minValueLabel;
		private System.Windows.Forms.Label maxValueLabel;
		private System.Windows.Forms.Label recommendedValueLabel;
		private System.Windows.Forms.Button elevatorsButton;
		private System.Windows.Forms.Label elevatorsLabel;
	}
}

