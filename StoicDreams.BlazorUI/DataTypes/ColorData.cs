using System.Text;
using static MudBlazor.Colors;

namespace StoicDreams.BlazorUI.DataTypes;

public class ColorData
{
	public string Name { get; set; } = string.Empty;

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

	public string Offset
	{
		get
		{
			(int red, int green, int blue) = GetRgb;
			if ((red * 0.299 + green * 0.587 + blue * 0.114) > 186) { return "var(--mud-palette-black)"; }
			return "var(--mud-palette-white)";
		}
	}

	public string RgbValue
	{
		get
		{
			(int red, int green, int blue) = GetRgb;
			return $"{red},{green},{blue}";
		}
	}

	private (int red, int green, int blue) GetRgb
	{
		get
		{
			try
			{
				int red = Convert.ToInt32(HexR, 16);
				int green = Convert.ToInt32(HexG, 16);
				int blue = Convert.ToInt32(HexB, 16);
				return (red,green,blue);
			}
			catch (Exception ex)
			{
				Error = ex.Message;
			}
			return (0,0,0);
		}
	}

	public string HslValue
	{
		get
		{
			double hue, saturation, luminance, red, green, blue;
			{
				(int r, int g, int b) = GetRgb;
				red = r / 255.0;
				green = g / 255.0;
				blue = b / 255.0;
			}
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

	private double Luminosity
	{
		get
		{
			double dr, dg, db;
			{
				(int r, int g, int b) = GetRgb;
				dr = r / 255.0;
				dg = g / 255.0;
				db = b / 255.0;
			}
			double cmax = Math.Max(dr, Math.Max(dg, db));
			double cmin = Math.Min(dr, Math.Min(dg, db));
			return (cmax + cmin) / 2.0;
		}
	}

	public override string ToString()
	{
		return HexValue;
	}

	public static ColorData Create(string name, string hexValue) => new() { Name = name, HexValue = hexValue };
	public static implicit operator ColorData(string hexValue) => new() { HexValue = hexValue };
	public static implicit operator string(ColorData color) => color.HexValue;
}
