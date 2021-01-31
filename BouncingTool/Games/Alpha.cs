using System;

namespace BouncingTool.Games
{
	public struct GameInfo
	{
		// Gobal info
		public string Name;
		public XboxUtils.TitleID TitleID;
		public XboxUtils.MPStringAddr MPStringAddr;

		// Function addresses
		public uint SV_GameSendServerCommand;
		public uint G_GetClientState;
		public uint Dvar_GetBool;
		public uint Cbuf_AddText;

		// Struct pointers
		public uint XenonUserDataPtr;

		// Struct sizes and offsets
		public uint nameOffset; // offset of name in clientState_s
	}

	public enum GameDropDownIndex
	{
		COD4,
		MW2
	}

	public static class Alpha
	{
		private static int s_ClientIndex = -1;
		private static string s_Gamertag = null;
		private static bool s_CheatsEnabled = false;

		private static GameInfo s_COD4 = new GameInfo()
		{
			Name = "COD4 Alpha 328",
			TitleID = XboxUtils.TitleID.COD4,
			MPStringAddr = XboxUtils.MPStringAddr.COD4_ALPHA,

			SV_GameSendServerCommand = 0x82234490,
			G_GetClientState = 0x821C81E0,
			Dvar_GetBool = 0x82269EA8,
			Cbuf_AddText = 0x821FDFA8,

			XenonUserDataPtr = 0x85E03418,

			nameOffset = 0x3C
		};

		private static GameInfo s_MW2 = new GameInfo()
		{
			Name = "MW2 Alpha 482",
			TitleID = XboxUtils.TitleID.MW2,
			MPStringAddr = XboxUtils.MPStringAddr.MW2_ALPHA,

			SV_GameSendServerCommand = 0x822B6140,
			G_GetClientState = 0x8222C0F0,
			Dvar_GetBool = 0x82303B00,
			Cbuf_AddText = 0x8226F590,

			XenonUserDataPtr = 0x837FE078,

			nameOffset = 0x44
		};

		private static GameInfo s_CurrentGame;

		public static void OnGameDropDownSelectedIndexChange(int selectedIndex)
		{
			switch (selectedIndex)
			{
				case (int)GameDropDownIndex.COD4:
					s_CurrentGame = s_COD4;
					break;
				case (int)GameDropDownIndex.MW2:
					s_CurrentGame = s_MW2;
					break;
			}

			Init();
		}

		public static void OnSavePosButtonClick()
		{
			if (!IsValidToProcess())
				return;

			uint playerStatePtr = GetPlayerStatePtr(s_ClientIndex);
			float[] pos = XboxUtils.ReadVec3(playerStatePtr + 0x1C);
			Console.WriteLine("x: " + pos[0]);
			Console.WriteLine("y: " + pos[1]);
			Console.WriteLine("z: " + pos[2]);
		}

		public static void OnCmdButtonClick(string command)
		{
			if (command == "")
				return;

			if (!IsValidToProcess())
				return;

			try
			{
				XboxUtils.Call<uint>(s_CurrentGame.Cbuf_AddText, 0, command);
			}
			catch (Exception)
			{
				XboxUtils.ErrorMessage("Couldn't execute command!");
			}
		}

		#region Utility methods

		private static void Init()
		{
			bool isOnGame = IsOnTheGame();
			if (isOnGame)
				s_Gamertag = XboxUtils.GetXenonUserGamertag(s_CurrentGame.XenonUserDataPtr);

			BouncingTool.s_Form.GetAlphaCmdLabel().Enabled = isOnGame;
			BouncingTool.s_Form.GetAlphaCmdInput().Enabled = isOnGame;
			BouncingTool.s_Form.GetAlphaCmdButton().Enabled = isOnGame;
			BouncingTool.s_Form.GetAlphaSavePosButton().Enabled = isOnGame;
			BouncingTool.s_Form.GetAlphaLoadPosButton().Enabled = isOnGame;
			BouncingTool.s_Form.GetAlphaBindLabel().Enabled = isOnGame;
			BouncingTool.s_Form.GetAlphaButtonsDropDownMenu().Enabled = isOnGame;
			BouncingTool.s_Form.GetAlphaSavedPosLabel().Enabled = isOnGame;
			BouncingTool.s_Form.GetAlphaBindButton().Enabled = isOnGame;
			BouncingTool.s_Form.GetAlphaFallDamageButton().Enabled = isOnGame;
			BouncingTool.s_Form.GetAlphaUfoButton().Enabled = isOnGame;
		}

		private static uint GetPlayerStatePtr(int clientIndex)
		{
			uint playerStatePtr = 0;

			try
			{
				if (s_CurrentGame.TitleID == XboxUtils.TitleID.COD4)
				{
					uint level_locals_t = 0x831A5EE0;
					uint clientsPtr = XboxUtils.ReadUInt32(level_locals_t);
					playerStatePtr = (uint)(clientsPtr + (clientIndex * 0x2FB8));
				}
				else if (s_CurrentGame.TitleID == XboxUtils.TitleID.MW2)
				{
					uint getPlayerStateAddr = 0x8222C108;
					playerStatePtr = XboxUtils.Call<uint>(getPlayerStateAddr, clientIndex);
				}
			}
			catch (Exception exception)
			{
				XboxUtils.ErrorMessage(exception.Message);
			}

			return playerStatePtr;
		}

		public static void SV_GameSendServerCommand(int clientIndex, string command)
		{
			if (clientIndex == -1)
				return;

			try
			{
				XboxUtils.Call<uint>(s_CurrentGame.SV_GameSendServerCommand, clientIndex, 0, command);
			}
			catch (Exception)
			{
				XboxUtils.ErrorMessage("Couldn't call SV_GameSendServerCommand");
			}
		}

		private static void CheckClientIndexValidity()
		{
			try
			{
				bool isInMatch = XboxUtils.Call<bool>(s_CurrentGame.Dvar_GetBool, "cl_ingame");
				if (!isInMatch)
				{
					s_ClientIndex = -1;
					XboxUtils.ErrorMessage("It doesn't look like you're in a match, make sure you are in a match before trying to use anything!");
					return;
				}

				if (s_ClientIndex != -1)
				{
					uint clientStatePtr = XboxUtils.Call<uint>(s_CurrentGame.G_GetClientState, s_ClientIndex);
					string gtFromClientState = XboxUtils.ReadString(clientStatePtr + s_CurrentGame.nameOffset);
					if (gtFromClientState == s_Gamertag)
						return;
				}

				for (int i = 0; i < 18; i++)
				{
					uint clientStatePtr = XboxUtils.Call<uint>(s_CurrentGame.G_GetClientState, i);
					string currentClientGT = XboxUtils.ReadString(clientStatePtr + s_CurrentGame.nameOffset);
					
					if (currentClientGT == s_Gamertag)
					{
						s_ClientIndex = i;
						return;
					}
				}
			}
			catch (Exception exception)
			{
				XboxUtils.ErrorMessage(exception.Message);
			}
		}

		private static void EnableCheatsIfNeeded()
		{
			if (!s_CheatsEnabled && s_CurrentGame.TitleID == XboxUtils.TitleID.COD4 && s_ClientIndex != -1)
			{
				SV_GameSendServerCommand(s_ClientIndex, "v sv_cheats \"1\"");
				s_CheatsEnabled = true;
				Console.WriteLine("enabled cheats");
			}
		}

		private static bool IsValidToProcess()
		{
			if (!IsOnTheGame())
				return false;

			CheckClientIndexValidity();
			EnableCheatsIfNeeded();

			return true;
		}

		private static bool IsOnTheGame()
		{
			bool isOnTheGame = false;

			try
			{
				isOnTheGame = XboxUtils.IsOnGame(s_CurrentGame.TitleID, s_CurrentGame.MPStringAddr);

				if (!isOnTheGame)
					XboxUtils.ErrorMessage("It doesn't look like you are on " + s_CurrentGame.Name + ", make sure you are on the game before trying to use anything!");
			}
			catch (Exception exception)
			{
				XboxUtils.ErrorMessage(exception.Message);
			}

			return isOnTheGame;
		}

		#endregion
	}
}
