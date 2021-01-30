
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
			this.Global_ConnectButton = new System.Windows.Forms.Button();
			this.MW2_ElevatorsButton = new System.Windows.Forms.Button();
			this.MW2_ElevatorsLabel = new System.Windows.Forms.Label();
			this.Global_TabControl = new System.Windows.Forms.TabControl();
			this.Global_MW2Tab = new System.Windows.Forms.TabPage();
			this.MW2_RecommendedValueLabel = new System.Windows.Forms.Label();
			this.MW2_MaxValueLabel = new System.Windows.Forms.Label();
			this.MW2_MinValueLabel = new System.Windows.Forms.Label();
			this.MW2_NotesLabel = new System.Windows.Forms.Label();
			this.MW2_StrengthLabel = new System.Windows.Forms.Label();
			this.MW2_KnockbackButton = new System.Windows.Forms.Button();
			this.MW2_KnockbackStrengthInput = new System.Windows.Forms.NumericUpDown();
			this.Global_AlphaTab = new System.Windows.Forms.TabPage();
			this.Global_TabControl.SuspendLayout();
			this.Global_MW2Tab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MW2_KnockbackStrengthInput)).BeginInit();
			this.SuspendLayout();
			// 
			// Global_ConnectButton
			// 
			this.Global_ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Global_ConnectButton.Location = new System.Drawing.Point(12, 12);
			this.Global_ConnectButton.Name = "Global_ConnectButton";
			this.Global_ConnectButton.Size = new System.Drawing.Size(357, 58);
			this.Global_ConnectButton.TabIndex = 0;
			this.Global_ConnectButton.Text = "Connect";
			this.Global_ConnectButton.UseVisualStyleBackColor = true;
			this.Global_ConnectButton.Click += new System.EventHandler(this.OnConnectButtonClick);
			// 
			// MW2_ElevatorsButton
			// 
			this.MW2_ElevatorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MW2_ElevatorsButton.Location = new System.Drawing.Point(14, 224);
			this.MW2_ElevatorsButton.Name = "MW2_ElevatorsButton";
			this.MW2_ElevatorsButton.Size = new System.Drawing.Size(179, 53);
			this.MW2_ElevatorsButton.TabIndex = 8;
			this.MW2_ElevatorsButton.Text = "Toggle Elevators";
			this.MW2_ElevatorsButton.UseVisualStyleBackColor = true;
			this.MW2_ElevatorsButton.Click += new System.EventHandler(this.MW2_OnElevatorsButtonClick);
			// 
			// MW2_ElevatorsLabel
			// 
			this.MW2_ElevatorsLabel.AutoSize = true;
			this.MW2_ElevatorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MW2_ElevatorsLabel.Location = new System.Drawing.Point(224, 240);
			this.MW2_ElevatorsLabel.Name = "MW2_ElevatorsLabel";
			this.MW2_ElevatorsLabel.Size = new System.Drawing.Size(0, 20);
			this.MW2_ElevatorsLabel.TabIndex = 9;
			// 
			// Global_TabControl
			// 
			this.Global_TabControl.Controls.Add(this.Global_MW2Tab);
			this.Global_TabControl.Controls.Add(this.Global_AlphaTab);
			this.Global_TabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Global_TabControl.Location = new System.Drawing.Point(12, 91);
			this.Global_TabControl.Multiline = true;
			this.Global_TabControl.Name = "Global_TabControl";
			this.Global_TabControl.SelectedIndex = 0;
			this.Global_TabControl.Size = new System.Drawing.Size(361, 338);
			this.Global_TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.Global_TabControl.TabIndex = 10;
			// 
			// Global_MW2Tab
			// 
			this.Global_MW2Tab.Controls.Add(this.MW2_RecommendedValueLabel);
			this.Global_MW2Tab.Controls.Add(this.MW2_ElevatorsLabel);
			this.Global_MW2Tab.Controls.Add(this.MW2_MaxValueLabel);
			this.Global_MW2Tab.Controls.Add(this.MW2_MinValueLabel);
			this.Global_MW2Tab.Controls.Add(this.MW2_NotesLabel);
			this.Global_MW2Tab.Controls.Add(this.MW2_StrengthLabel);
			this.Global_MW2Tab.Controls.Add(this.MW2_KnockbackButton);
			this.Global_MW2Tab.Controls.Add(this.MW2_KnockbackStrengthInput);
			this.Global_MW2Tab.Controls.Add(this.MW2_ElevatorsButton);
			this.Global_MW2Tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Global_MW2Tab.Location = new System.Drawing.Point(4, 29);
			this.Global_MW2Tab.Name = "Global_MW2Tab";
			this.Global_MW2Tab.Padding = new System.Windows.Forms.Padding(3);
			this.Global_MW2Tab.Size = new System.Drawing.Size(353, 305);
			this.Global_MW2Tab.TabIndex = 0;
			this.Global_MW2Tab.Text = "MW2";
			this.Global_MW2Tab.UseVisualStyleBackColor = true;
			// 
			// MW2_RecommendedValueLabel
			// 
			this.MW2_RecommendedValueLabel.AutoSize = true;
			this.MW2_RecommendedValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MW2_RecommendedValueLabel.Location = new System.Drawing.Point(29, 168);
			this.MW2_RecommendedValueLabel.Name = "MW2_RecommendedValueLabel";
			this.MW2_RecommendedValueLabel.Size = new System.Drawing.Size(243, 18);
			this.MW2_RecommendedValueLabel.TabIndex = 15;
			this.MW2_RecommendedValueLabel.Text = "- The recommended value is 30000.";
			// 
			// MW2_MaxValueLabel
			// 
			this.MW2_MaxValueLabel.AutoSize = true;
			this.MW2_MaxValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MW2_MaxValueLabel.Location = new System.Drawing.Point(29, 140);
			this.MW2_MaxValueLabel.Name = "MW2_MaxValueLabel";
			this.MW2_MaxValueLabel.Size = new System.Drawing.Size(183, 18);
			this.MW2_MaxValueLabel.TabIndex = 14;
			this.MW2_MaxValueLabel.Text = "- The max value is 999999.";
			// 
			// MW2_MinValueLabel
			// 
			this.MW2_MinValueLabel.AutoSize = true;
			this.MW2_MinValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MW2_MinValueLabel.Location = new System.Drawing.Point(29, 112);
			this.MW2_MinValueLabel.Name = "MW2_MinValueLabel";
			this.MW2_MinValueLabel.Size = new System.Drawing.Size(248, 18);
			this.MW2_MinValueLabel.TabIndex = 13;
			this.MW2_MinValueLabel.Text = "- The min (and default) value is 1000.";
			// 
			// MW2_NotesLabel
			// 
			this.MW2_NotesLabel.AutoSize = true;
			this.MW2_NotesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MW2_NotesLabel.Location = new System.Drawing.Point(10, 82);
			this.MW2_NotesLabel.Name = "MW2_NotesLabel";
			this.MW2_NotesLabel.Size = new System.Drawing.Size(64, 20);
			this.MW2_NotesLabel.TabIndex = 12;
			this.MW2_NotesLabel.Text = "Notes:";
			// 
			// MW2_StrengthLabel
			// 
			this.MW2_StrengthLabel.AutoSize = true;
			this.MW2_StrengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MW2_StrengthLabel.Location = new System.Drawing.Point(230, 20);
			this.MW2_StrengthLabel.Name = "MW2_StrengthLabel";
			this.MW2_StrengthLabel.Size = new System.Drawing.Size(67, 18);
			this.MW2_StrengthLabel.TabIndex = 11;
			this.MW2_StrengthLabel.Text = "Strength:";
			// 
			// MW2_KnockbackButton
			// 
			this.MW2_KnockbackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MW2_KnockbackButton.Location = new System.Drawing.Point(11, 20);
			this.MW2_KnockbackButton.Name = "MW2_KnockbackButton";
			this.MW2_KnockbackButton.Size = new System.Drawing.Size(213, 50);
			this.MW2_KnockbackButton.TabIndex = 10;
			this.MW2_KnockbackButton.Text = "Infect with Knockback";
			this.MW2_KnockbackButton.UseVisualStyleBackColor = true;
			this.MW2_KnockbackButton.Click += new System.EventHandler(this.MW2_OnKnockbackButtonClick);
			// 
			// MW2_KnockbackStrengthInput
			// 
			this.MW2_KnockbackStrengthInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MW2_KnockbackStrengthInput.Location = new System.Drawing.Point(229, 43);
			this.MW2_KnockbackStrengthInput.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.MW2_KnockbackStrengthInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.MW2_KnockbackStrengthInput.Name = "MW2_KnockbackStrengthInput";
			this.MW2_KnockbackStrengthInput.Size = new System.Drawing.Size(114, 27);
			this.MW2_KnockbackStrengthInput.TabIndex = 9;
			this.MW2_KnockbackStrengthInput.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
			// 
			// Global_AlphaTab
			// 
			this.Global_AlphaTab.Location = new System.Drawing.Point(4, 29);
			this.Global_AlphaTab.Name = "Global_AlphaTab";
			this.Global_AlphaTab.Padding = new System.Windows.Forms.Padding(3);
			this.Global_AlphaTab.Size = new System.Drawing.Size(353, 305);
			this.Global_AlphaTab.TabIndex = 1;
			this.Global_AlphaTab.Text = "Alpha";
			this.Global_AlphaTab.UseVisualStyleBackColor = true;
			// 
			// BouncingTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(389, 447);
			this.Controls.Add(this.Global_TabControl);
			this.Controls.Add(this.Global_ConnectButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "BouncingTool";
			this.Text = "MW2 Bouncing Tool";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClose);
			this.Global_TabControl.ResumeLayout(false);
			this.Global_MW2Tab.ResumeLayout(false);
			this.Global_MW2Tab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MW2_KnockbackStrengthInput)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		#region UI elements getters

		public System.Windows.Forms.Label GetMW2ElevatorsLabel()
		{
			return MW2_ElevatorsLabel;
		}

		#endregion

		private System.Windows.Forms.Button Global_ConnectButton;
		private System.Windows.Forms.Button MW2_ElevatorsButton;
		private System.Windows.Forms.Label MW2_ElevatorsLabel;
		private System.Windows.Forms.TabControl Global_TabControl;
		private System.Windows.Forms.TabPage Global_MW2Tab;
		private System.Windows.Forms.TabPage Global_AlphaTab;
		private System.Windows.Forms.Label MW2_RecommendedValueLabel;
		private System.Windows.Forms.Label MW2_MaxValueLabel;
		private System.Windows.Forms.Label MW2_MinValueLabel;
		private System.Windows.Forms.Label MW2_NotesLabel;
		private System.Windows.Forms.Label MW2_StrengthLabel;
		private System.Windows.Forms.Button MW2_KnockbackButton;
		private System.Windows.Forms.NumericUpDown MW2_KnockbackStrengthInput;
	}
}

