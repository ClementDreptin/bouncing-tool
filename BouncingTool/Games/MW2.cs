using System;

namespace BouncingTool.Games
{
	public static class MW2
	{
		private static bool s_ElevatorsEnabled = false;

		private enum Addresses : uint
		{
			SV_GameSendServerCommand = 0x822548D8,
			ElevatorsBranch = 0x820D8360
		}

		public static void Init()
		{
			UpdateElevatorsLabel(false);
		}

		public static void OnKnockbackButtonClick(int strength)
		{
			if (!IsOnTheGame())
				return;

			try
			{
				XboxUtils.Call<uint>((uint)Addresses.SV_GameSendServerCommand, -1, 0, "s g_knockback \"" + strength + "\"");
			}
			catch (Exception exception)
			{
				XboxUtils.ErrorMessage(exception.Message);
			}
		}

		public static void OnElevatorsButtonClick()
		{
			if (!IsOnTheGame())
				return;

			try
			{
				ushort defaultValue = 0x419A;
				ushort modifiedValue = 0x4800;
				bool elevatorsActuallyEnabled = XboxUtils.ReadUShort((uint)Addresses.ElevatorsBranch) == modifiedValue;

				if (!s_ElevatorsEnabled && !elevatorsActuallyEnabled)
					XboxUtils.WriteUShort((uint)Addresses.ElevatorsBranch, modifiedValue);
				else if (s_ElevatorsEnabled && elevatorsActuallyEnabled)
					XboxUtils.WriteUShort((uint)Addresses.ElevatorsBranch, defaultValue);

				s_ElevatorsEnabled = !s_ElevatorsEnabled;
				UpdateElevatorsLabel(s_ElevatorsEnabled);
			}
			catch (Exception exception)
			{
				XboxUtils.ErrorMessage(exception.Message);
			}
		}

		private static bool IsOnTheGame()
		{
			bool isOnTheGame = false;
			
			try
			{
				isOnTheGame = XboxUtils.GetCurrentTitleID() == (uint)XboxUtils.TitleID.MW2;

				if (!isOnTheGame)
					XboxUtils.ErrorMessage("It doesn't look like you are on MW2, make sure you are on the game before trying to infect!");
			}
			catch (Exception exception)
			{
				XboxUtils.ErrorMessage(exception.Message);
			}

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
