using System;
using System.Windows.Forms;
using BouncingTool.Games;

namespace BouncingTool
{
	public partial class BouncingTool : Form
	{
		public static BouncingTool s_Form = null;

		public BouncingTool()
		{
			InitializeComponent();
			s_Form = this;

			EnableUIElements(false);
			MW2.Init();
		}

		#region Global

		private void EnableUIElements(bool enabled)
		{
			Global_TabControl.Enabled = enabled;
		}

		private void OnFormClose(object sender, FormClosingEventArgs e)
		{
			if (!XboxUtils.IsConnected())
				return;

			try
			{
				string consoleName = XboxUtils.GetConsoleName();
				XboxUtils.Disconnect();
				XboxUtils.ConfirmMessage("Successfully disconnected from console: " + consoleName);
			}
			catch (Exception exception)
			{
				XboxUtils.ErrorMessage(exception.Message);
			}
		}

		private void OnConnectButtonClick(object sender, EventArgs e)
		{
			try
			{
				XboxUtils.Connect();
				XboxUtils.ConfirmMessage("Successfully connected to console: " + XboxUtils.GetConsoleName());
				EnableUIElements(true);
			}
			catch (Exception exception)
			{
				XboxUtils.ErrorMessage(exception.Message);
			}
		}

		#endregion

		#region MW2

		private void MW2_OnKnockbackButtonClick(object sender, EventArgs e)
		{
			MW2.OnKnockbackButtonClick((int)MW2_KnockbackStrengthInput.Value);
		}

		private void MW2_OnElevatorsButtonClick(object sender, EventArgs e)
		{
			MW2.OnElevatorsButtonClick();
		}

		#endregion

		#region Alpha

		private void Alpha_OnGameDropDownSelectedIndexChange(object sender, EventArgs e)
		{
			Alpha.OnGameDropDownSelectedIndexChange(Alpha_GameDropDownMenu.SelectedIndex);
		}

		private void Alpha_OnCmdButtonClick(object sender, EventArgs e)
		{
			Alpha.OnCmdButtonClick(Alpha_CmdInput.Text);
		}

		private void Alpha_OnSavePosButtonClick(object sender, EventArgs e)
		{
			Alpha.OnSavePosButtonClick();
		}

		#endregion
	}
}