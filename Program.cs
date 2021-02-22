using System;
using System.Linq;
using System.Text;

namespace compressbin
{
	class Program
	{
		/*

		BinCompress:
			44  	> 11110000
			2222	> 11001100
			0101	> 0101
			1010	> 1010

		StrCompress
			aaaaabbbbbbb => ab
	
		Decompress
			aaaabbb => (4 * a)(3 * b)
			1111000 => (4 * 1)(3 * 0)

		*/
		
		static void Main(string[] args)
		{
			foreach (string str in args)
			{
				Console.WriteLine(BinCompress(str));
				//Console.WriteLine(StrCompress(str));
				//Console.WriteLine($"{DeCompress(str)} ");
			}
		}

		static string BinCompress(string str)
		{
			StringBuilder sb = new StringBuilder();
			bool isZero = (str[0] == '0') ? true : false;

			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] != '1' && str[i] != '0')
				{
					if (isZero)
						for (int j = 0; j < str[i] - 48; j++)
							sb.Append('0');
					else
						for (int j = 0; j < str[i] - 48; j++)
							sb.Append('1');
				}
				else
				{
					if (isZero)
						sb.Append('0');
					else
						sb.Append('1');
				}

				isZero = !isZero;
			}

			return new string(sb.ToString());
		}

		static string StrCompress(string str)
		{
			StringBuilder sb = new StringBuilder();
			char current = str[0];
			int count = 1;

			for (int i = 0; i < str.Length; i++)
			{
				if (i != 0)
				{
					if (str[i] == str[i - 1])
					{
						count++;
					}
					else
					{
						sb.Append(str[i]);
						count = 1;
					}
				}
				else
				{
					sb.Append(str[i]);
				}
			}

			return sb.ToString() + ' ';
		}

		static string DeCompress(string str)
		{
			StringBuilder sb = new StringBuilder();

			int count = 1;
			char current = str[0];
			char next = str[1];

			for (int i = 0; i < str.Length; i++)
			{
				current = str[i];
				if (i < str.Length - 1)
					next = str[i + 1];
				else
					next = '/';

				if (current != next)
				{
					if (count == 1)
					{
						sb.Append(current);
					}
					else
					{
						sb.Append($"({count} * {current})");
						count = 1;
					}
				}
				else
					count++;
			}

			return sb.ToString();
		}
	}
}
