using System.Text;

namespace StoicDreams.BlazorUI.DataTypes;

public class ColorData
{
	public string UserDisplay { get; set; } = string.Empty;
	public string MemberName { get; set; } = string.Empty;

	public string HexValue { get => GetHexFromValue; set => SetValueFromHex(value); }

	public string Error { get; set; } = string.Empty;

	private void SetValueFromHex(string input)
	{
		try
		{
			StringBuilder value = new();
			input = input.Replace("#", "");
			foreach (char c in input)
			{
				try
				{
					int val = Convert.ToInt32($"{c}", 16);
					if (val == 0 && c != '0') { continue; }
					value.Append(c);
				}
				catch { }
			}
			if (value.Length == 3)
			{
				input = value.ToString();
				value.Clear();
				foreach (char c in input)
				{
					value.Append(c);
					value.Append(c);
				}
			}
			if (value.Length == 6)
			{
				value.Append("ff");
			}
			if (value.Length != 8) { return; }
			Value = value.ToString();
			SetRGB();
			SetIsDarkColor();
		}
		catch (Exception ex)
		{
			Error = ex.Message;
		}
	}
	private string GetHexFromValue => $"#{Value}";
	private string Value { get; set; } = "00DDFFFF";
	private string HexR => Value[0..2];
	private string HexG => Value[2..4];
	private string HexB => Value[4..6];
	private string Alpha => Value[6..8];

	public string Lighter
	{
		get
		{
			(int red, int green, int blue) = RGB;
			red = Math.Min(255, red + ShiftAmount);
			green = Math.Min(255, green + ShiftAmount);
			blue = Math.Min(255, blue + ShiftAmount);
			return $"#{red.ToBaseEncode(16, 1)}{green.ToBaseEncode(16, 1)}{blue.ToBaseEncode(16, 1)}ff";
		}
	}

	public string Darker
	{
		get
		{
			(int red, int green, int blue) = RGB;
			red = Math.Max(0, red - ShiftAmount);
			green = Math.Max(0, green - ShiftAmount);
			blue = Math.Max(0, blue - ShiftAmount);
			return $"#{red.ToBaseEncode(16, 1)}{green.ToBaseEncode(16,1)}{blue.ToBaseEncode(16,1)}ff";
		}
	}

	private int ShiftAmount = 50;

	private bool IsDarkColor { get; set; }
	private void SetIsDarkColor()
	{
		IsDarkColor = (RGB.Red * 0.299 + RGB.Green * 0.587 + RGB.Blue * 0.114) < 212;
	}

	public string Shifted => IsDarkColor ? Lighter : Darker;

	public string Offset => IsDarkColor ? "var(--mud-palette-white)" : "var(--mud-palette-black)";

	public string RgbValue
	{
		get
		{
			return $"{RGB.Red},{RGB.Green},{RGB.Blue}";
		}
	}

	private (int Red, int Green, int Blue) RGB { get; set; } = (0, 0, 0);
	private void SetRGB()
	{
		try
		{
			int red = Convert.ToInt32(HexR, 16);
			int green = Convert.ToInt32(HexG, 16);
			int blue = Convert.ToInt32(HexB, 16);
			RGB = (red,green,blue);
		}
		catch (Exception ex)
		{
			Error = ex.Message;
		}
	}

	public string HslValue
	{
		get
		{
			double hue, saturation, luminance;
			double red = RGB.Red / 255.0;
			double green = RGB.Green / 255.0;
			double blue = RGB.Blue / 255.0;
			double cmax = Math.Max(red, Math.Max(green, blue));
			double cmin = Math.Min(red, Math.Min(green, blue));

			luminance = (cmax + cmin) / 2.0;
			if (cmax == cmin)
			{
				saturation = 0.0;
				hue = 0.0;
			}
			else
			{
				if (luminance < 0.5)
				{
					saturation = (cmax - cmin) / (cmax + cmin);
				}
				else
				{
					saturation = (cmax - cmin) / (2.0 - cmax - cmin);
				}
				double delta = cmax - cmin;

				if (red == cmax)
				{
					hue = (green - blue) / delta;
				}
				else if (green == cmax)
				{
					hue = 2.0 + (blue - red) / delta;
				}
				else
				{
					hue = 4.0 + (red - green) / delta;
				}
				hue /= 6.0;

				if (hue < 0.0)
				{
					hue += 1.0;
				}
			}
			return $"{(hue * 360):N0},{saturation:N2},{luminance:N2}";
		}
	}

	public override string ToString()
	{
		return HexValue;
	}

	public static ColorData Create(string userDisplay, string memberName, string hexValue) => new() { UserDisplay = userDisplay, MemberName = memberName, HexValue = hexValue };
	public static implicit operator ColorData(string hexValue) => new() { HexValue = hexValue };
	public static implicit operator string(ColorData color) => color.HexValue;
}
