using System;
using System.Windows.Forms;
using XDevkit;
using Microsoft.Test.Xbox.XDRPC;

public static class XboxUtils
{
	private static bool m_ActiveConnection = false;
	private static uint m_XboxConnection = 0;
	
	private static IXboxManager m_XboxManager = null;
	private static IXboxConsole m_XboxConsole = null;

	public enum TitleIDs : uint
	{
		COD4 = 0x415607E6,
		MW2 = 0x41560817,
		MW3 = 0x415608CB
	}

	public static bool Connect()
	{
		m_XboxManager = new XboxManager();
		m_XboxConsole = m_XboxManager.OpenConsole(m_XboxManager.DefaultConsole);

		string debuggerName = null;
		string userName = null;

		try
		{
			m_XboxConnection = m_XboxConsole.OpenConnection(null);
		}
		catch (Exception)
		{
			m_ActiveConnection = false;
			DisplayErrorMessage("Could not connect to console: " + m_XboxManager.DefaultConsole);
			return false;
		}

		if (m_XboxConsole.DebugTarget.IsDebuggerConnected(out debuggerName, out userName))
		{
			m_ActiveConnection = true;
			DisplayConfirmMessage("Successfully connected to console: " + m_XboxConsole.Name);
			return true;
		}
		else
		{
			m_XboxConsole.DebugTarget.ConnectAsDebugger("XboxTool", XboxDebugConnectFlags.Force);
			if (!m_XboxConsole.DebugTarget.IsDebuggerConnected(out debuggerName, out userName))
			{
				m_ActiveConnection = false;
				DisplayErrorMessage("Could not connect a debugger to console: " + m_XboxConsole.Name);
				return false;
			}
			else
			{
				m_ActiveConnection = true;
				DisplayConfirmMessage("Successfully connected to console: " + m_XboxConsole.Name);
				return true;
			}
		}
	}

	public static bool Disconnect()
	{
		if (!m_ActiveConnection)
			return true;

		try
		{
			if (m_XboxConsole.DebugTarget.IsDebuggerConnected(out string debuggerName, out string userName))
				m_XboxConsole.DebugTarget.DisconnectAsDebugger();

			if (m_XboxConnection != 0)
			{
				m_XboxConsole.CloseConnection(m_XboxConnection);
				DisplayConfirmMessage("Successfully disconnected from console: " + m_XboxConsole.Name);
				return true;
			}
		}
		catch (Exception)
		{
			DisplayErrorMessage("Could not disconnect from console: " + m_XboxConsole.Name);
			return false;
		}

		return true;
	}

	public static void DisplayErrorMessage(string message)
	{
		MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}

	public static void DisplayConfirmMessage(string message)
	{
		MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}

	public static T Call<T>(uint address, params object[] args) where T : struct
	{
		T returnValue = default;

		if (!IsConnected())
			return returnValue;

		try
		{
			returnValue = XDRPCMarshaler.ExecuteRPC<T>(m_XboxConsole, new XDRPCExecutionOptions(XDRPCMode.Title, address), args);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Error while calling the function!");
		}

		return returnValue;
	}

	public static T Call<T>(string moduleName, int ordinal, params object[] args) where T : struct
	{
		T returnValue = default;

		if (!IsConnected())
			return returnValue;

		try
		{
			returnValue = XDRPCMarshaler.ExecuteRPC<T>(m_XboxConsole, XDRPCMode.System, moduleName, ordinal, args);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Error while calling the function!");
		}

		return returnValue;
	}

	public static uint GetCurrentTitleID()
	{
		uint titleID = 0;

		if (!IsConnected())
			return titleID;

		try
		{
			titleID = m_XboxConsole.ExecuteRPC<uint>(XDRPCMode.System, "xam.xex", 463, new object[] { });
		}
		catch (Exception)
		{
			DisplayErrorMessage("Couldn't get current title ID");
		}

		return titleID;
	}

	public static void XNotify(string text)
	{
		if (!m_ActiveConnection)
			return;

		try
		{
			Call<uint>("xam.xex", 656, Convert.ToUInt32(14), 0, 2, StringToWideCharArray(text), 0);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Couldn't call XNotify!");
		}
	}

	public static bool IsConnected()
	{
		if (!m_ActiveConnection)
			DisplayErrorMessage("Not currently connected to a console!");

		return m_ActiveConnection;
	}

	public static uint ReadUInt32(uint address)
	{
		uint result = 0;

		try
		{
			byte[] memoryBuffer = new byte[4];
			m_XboxConsole.DebugTarget.GetMemory(address, (uint)memoryBuffer.Length, memoryBuffer, out uint bytesRead);
			m_XboxConsole.DebugTarget.InvalidateMemoryCache(true, address, (uint)memoryBuffer.Length);
			Array.Reverse(memoryBuffer, 0, memoryBuffer.Length);
			result = BitConverter.ToUInt32(memoryBuffer, 0);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Could not read a uint32 at 0x" + address.ToString("X"));
		}

		return result;
	}

	public static void WriteUInt32(uint address, uint input)
	{
		if (!IsConnected())
			return;

		try
		{
			byte[] memoryBuffer = new byte[4];
			BitConverter.GetBytes(input).CopyTo(memoryBuffer, 0);
			Array.Reverse(memoryBuffer, 0, memoryBuffer.Length);
			m_XboxConsole.DebugTarget.SetMemory(address, (uint)memoryBuffer.Length, memoryBuffer, out uint bytesWritten);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Could not write a uint32 at 0x" + address.ToString("X"));
		}
	}

	public static float ReadFloat(uint address)
	{
		float result = 0.0f;

		try
		{
			byte[] memoryBuffer = new byte[4];
			m_XboxConsole.DebugTarget.GetMemory(address, (uint)memoryBuffer.Length, memoryBuffer, out uint bytesRead);
			m_XboxConsole.DebugTarget.InvalidateMemoryCache(true, address, (uint)memoryBuffer.Length);
			Array.Reverse(memoryBuffer, 0, memoryBuffer.Length);
			result = BitConverter.ToSingle(memoryBuffer, 0);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Could not read a float at 0x" + address.ToString("X"));
		}

		return result;
	}

	public static void WriteFloat(uint address, float input)
	{
		if (!IsConnected())
			return;

		try
		{
			byte[] memoryBuffer = new byte[4];
			BitConverter.GetBytes(input).CopyTo(memoryBuffer, 0);
			Array.Reverse(memoryBuffer, 0, memoryBuffer.Length);
			m_XboxConsole.DebugTarget.SetMemory(address, (uint)memoryBuffer.Length, memoryBuffer, out uint bytesWritten);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Could not write a float at 0x" + address.ToString("X"));
		}
	}

	public static int ReadInt(uint address)
	{
		int result = 0;

		try
		{
			byte[] memoryBuffer = new byte[4];
			m_XboxConsole.DebugTarget.GetMemory(address, (uint)memoryBuffer.Length, memoryBuffer, out uint bytesRead);
			m_XboxConsole.DebugTarget.InvalidateMemoryCache(true, address, (uint)memoryBuffer.Length);
			Array.Reverse(memoryBuffer, 0, memoryBuffer.Length);
			result = BitConverter.ToInt32(memoryBuffer, 0);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Could not read a float at 0x" + address.ToString("X"));
		}

		return result;
	}

	public static void WriteInt(uint address, int input)
	{
		if (!IsConnected())
			return;

		try
		{
			byte[] memoryBuffer = new byte[4];
			BitConverter.GetBytes(input).CopyTo(memoryBuffer, 0);
			Array.Reverse(memoryBuffer, 0, memoryBuffer.Length);
			m_XboxConsole.DebugTarget.SetMemory(address, (uint)memoryBuffer.Length, memoryBuffer, out uint bytesWritten);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Could not write a float at 0x" + address.ToString("X"));
		}
	}

	public static float[] ReadVec3(uint address)
	{
		float[] result = { 0.0f, 0.0f, 0.0f };

		try
		{
			byte[] memoryBuffer = new byte[12];
			m_XboxConsole.DebugTarget.GetMemory(address, (uint)memoryBuffer.Length, memoryBuffer, out uint bytesRead);
			m_XboxConsole.DebugTarget.InvalidateMemoryCache(true, address, (uint)memoryBuffer.Length);
			Array.Reverse(memoryBuffer, 0, memoryBuffer.Length);
			Buffer.BlockCopy(memoryBuffer, 0, result, 0, memoryBuffer.Length);
			Array.Reverse(result);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Could not read a vec3 at 0x" + address.ToString("X"));
		}

		return result;
	}

	public static void WriteVec3(uint address, float[] input)
	{
		if (!IsConnected())
			return;

		if (input.Length != 3)
		{
			DisplayErrorMessage("The input needs to be an array of exactly 3 floats");
			return;
		}

		try
		{
			byte[] memoryBuffer = new byte[12];
			Array.Reverse(input);
			Buffer.BlockCopy(input, 0, memoryBuffer, 0, memoryBuffer.Length);
			Array.Reverse(memoryBuffer, 0, memoryBuffer.Length);
			m_XboxConsole.DebugTarget.SetMemory(address, (uint)memoryBuffer.Length, memoryBuffer, out uint bytesWritten);
		}
		catch (Exception e)
		{
			DisplayErrorMessage("Could not write a vec3 at 0x" + address.ToString("X"));
			Console.WriteLine(e.Message);
		}
	}

	public static short ReadShort(uint address)
	{
		short result = 0;

		try
		{
			byte[] memoryBuffer = new byte[2];
			m_XboxConsole.DebugTarget.GetMemory(address, (uint)memoryBuffer.Length, memoryBuffer, out uint bytesRead);
			m_XboxConsole.DebugTarget.InvalidateMemoryCache(true, address, (uint)memoryBuffer.Length);
			Array.Reverse(memoryBuffer, 0, memoryBuffer.Length);
			result = BitConverter.ToInt16(memoryBuffer, 0);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Could not read a float at 0x" + address.ToString("X"));
		}

		return result;
	}

	public static void WriteShort(uint address, short input)
	{
		if (!IsConnected())
			return;

		try
		{
			byte[] memoryBuffer = new byte[2];
			BitConverter.GetBytes(input).CopyTo(memoryBuffer, 0);
			Array.Reverse(memoryBuffer, 0, memoryBuffer.Length);
			m_XboxConsole.DebugTarget.SetMemory(address, (uint)memoryBuffer.Length, memoryBuffer, out uint bytesWritten);
		}
		catch (Exception)
		{
			DisplayErrorMessage("Could not write a float at 0x" + address.ToString("X"));
		}
	}

	private static byte[] StringToWideCharArray(string text)
	{
		byte[] buffer = new byte[(text.Length * 2) + 2];
		int index = 1;
		buffer[0] = 0;
		foreach (char ch in text)
		{
			buffer[index] = Convert.ToByte(ch);
			index += 2;
		}
		return buffer;
	}
}