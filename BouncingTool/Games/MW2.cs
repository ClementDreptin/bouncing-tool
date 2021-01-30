﻿namespace BouncingTool.Games
{
	public static class MW2
	{
		private static bool s_ElevatorsEnabled = false;

		private enum Addresses : uint
		{
			SV_GameSendServerCommand = 0x822548D8,
			ElevatorsBranch = 0x820D8310
		}

		public static void Init()
		{
			UpdateElevatorsLabel(false);
		}

		public static void OnKnockbackButtonClick(int strength)
		{
			if (!IsOnTheGame())
				return;

			XboxUtils.Call<uint>((uint)Addresses.SV_GameSendServerCommand, -1, 0, "s g_knockback \"" + strength + "\"");
		}

		public static void OnElevatorsButtonClick()
		{
			if (!IsOnTheGame())
				return;

			uint defaultValue = 0x409A0054;
			uint modifiedValue = 0x409A0094;
			bool elevatorsActuallyEnabled = XboxUtils.ReadUInt32((uint)Addresses.ElevatorsBranch) == modifiedValue;

			if (!s_ElevatorsEnabled && !elevatorsActuallyEnabled)
				XboxUtils.WriteUInt32((uint)Addresses.ElevatorsBranch, modifiedValue);
			else if (s_ElevatorsEnabled && elevatorsActuallyEnabled)
				XboxUtils.WriteUInt32((uint)Addresses.ElevatorsBranch, defaultValue);

			s_ElevatorsEnabled = !s_ElevatorsEnabled;
			UpdateElevatorsLabel(s_ElevatorsEnabled);
		}

		private static bool IsOnTheGame()
		{
			bool isOnTheGame = XboxUtils.GetCurrentTitleID() == (uint)XboxUtils.TitleIDs.MW2;
			
			if (!isOnTheGame)
				XboxUtils.ErrorMessage("It doesn't look like you are on MW2, make sure you are on the game before trying to infect!");

			return isOnTheGame;
		}

		private static void UpdateElevatorsLabel(bool status)
		{
			if (status)
			{
				BouncingTool.s_Form.GetMW2ElevatorsLabel().Text = "On";
				BouncingTool.s_Form.GetMW2ElevatorsLabel().ForeColor = System.Drawing.Color.Green;
			}
			else
			{
				BouncingTool.s_Form.GetMW2ElevatorsLabel().Text = "Off";
				BouncingTool.s_Form.GetMW2ElevatorsLabel().ForeColor = System.Drawing.Color.Red;
			}
		}
	}
}
