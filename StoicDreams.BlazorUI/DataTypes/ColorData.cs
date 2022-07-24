using System.Text;

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

	public string RgbValue
	{
		get
		{
			(int r, int g, int b) = GetRgb;
			return $"{r},{g},{b}";
		}
	}

	private (int r, int g, int b) GetRgb
	{
		get
		{
			try
			{
				int r = Convert.ToInt32(HexR, 16);
				int g = Convert.ToInt32(HexG, 16);
				int b = Convert.ToInt32(HexB, 16);
				return (r,g,b);
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
			try
			{
				double h, s, l, dr, dg, db;
				{
					(int r, int g, int b) = GetRgb;
					dr = r / 255.0;
					dg = g / 255.0;
					db = b / 255.0;
				}
				double cmax = Math.Max(dr, Math.Max(dg, db));
				double cmin = Math.Min(dr, Math.Min(dg, db));

				l = (cmax + cmin) / 2.0;
				if (cmax == cmin)
				{
					s = 0.0;
					h = 0.0;
				}
				else
				{
					if (l < 0.5)
					{
						s = (cmax - cmin) / (cmax + cmin);
					}
					else
					{
						s = (cmax - cmin) / (2.0 - cmax - cmin);
					}
					double delta = cmax - cmin;

					if (dr == cmax)
					{
						h = (dg - db) / delta;
					}
					else if (dg == cmax)
					{
						h = 2.0 + (db - dr) / delta;
					}
					else
					{
						h = 4.0 + (dr - dg) / delta;
					}
					h /= 6.0;

					if (h < 0.0)
					{
						h += 1.0;
					}
				}
				return $"{(h*360):N0},{s:N2},{l:N2}";
			}
			catch (Exception ex)
			{
				Error = ex.Message;
			}
			return "0,0,1";
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
