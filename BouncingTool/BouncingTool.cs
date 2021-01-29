using System;
using System.Windows.Forms;

namespace BouncingTool
{
	public partial class BouncingTool : Form
	{
		private bool m_ElevatorsEnabled = false;

		public BouncingTool()
		{
			InitializeComponent();

			EnableUIElements(false);
		}

		private void OnFormClose(object sender, FormClosingEventArgs e)
		{
			XboxUtils.Disconnect();
		}

		private void OnConnectButtonClick(object sender, EventArgs e)
		{
			if (XboxUtils.Connect())
				EnableUIElements(true);
		}

		private void OnInfectButtonClick(object sender, EventArgs e)
		{
			if (!(XboxUtils.GetCurrentTitleID() == (uint)XboxUtils.TitleIDs.MW2))
			{
				XboxUtils.DisplayErrorMessage("It doesn't look like you are on MW2, make sure you are on the game before trying to infect!");
				return;
			}

			// 0x822548D8 is the address of SV_GameSendServerCommand
			XboxUtils.Call<uint>(0x822548D8, -1, 0, "s g_knockback \"" + strengthValueInput.Value + "\"");
		}

		private void OnElevatorButtonClick(object sender, EventArgs e)
		{
			if (!(XboxUtils.GetCurrentTitleID() == (uint)XboxUtils.TitleIDs.MW2))
			{
				XboxUtils.DisplayErrorMessage("It doesn't look like you are on MW2, make sure you are on the game before trying to toggle elevators!");
				return;
			}

			uint branchAddress = 0x820D8310;
			uint defaultValue = 0x409A0054;
			uint modifiedValue = 0x409A0094;
			bool elevatorsActuallyEnabled = XboxUtils.ReadUInt32(branchAddress) == modifiedValue;

			if (!m_ElevatorsEnabled && !elevatorsActuallyEnabled)
				XboxUtils.WriteUInt32(branchAddress, modifiedValue);
			else if (m_ElevatorsEnabled && elevatorsActuallyEnabled)
				XboxUtils.WriteUInt32(branchAddress, defaultValue);

			m_ElevatorsEnabled = !m_ElevatorsEnabled;
			UpdateElevatorsLabel(m_ElevatorsEnabled);
		}

		private void EnableUIElements(bool enabled)
		{
			infectButton.Enabled = enabled;
			strengthLabel.Enabled = enabled;
			strengthValueInput.Enabled = enabled;
			notesLabel.Enabled = enabled;
			minValueLabel.Enabled = enabled;
			maxValueLabel.Enabled = enabled;
			recommendedValueLabel.Enabled = enabled;
			elevatorsButton.Enabled = enabled;
			elevatorsLabel.Enabled = enabled;

			UpdateElevatorsLabel(false);
		}

		private void UpdateElevatorsLabel(bool status)
		{
			if (status)
			{
				elevatorsLabel.Text = "On";
				elevatorsLabel.ForeColor = System.Drawing.Color.Green;
			}
			else
			{
				elevatorsLabel.Text = "Off";
				elevatorsLabel.ForeColor = System.Drawing.Color.Red;
			}
		}
	}
}