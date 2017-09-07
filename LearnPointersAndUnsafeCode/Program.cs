using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnPointersAndUnsafeCode
{
	class Program
	{
		static void Main(string[] args)
		{
			/* 
			 * Possible C# operators:
			 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/multiplication-operator
			 * 
			 * Allowed Unsafe type variables 
			 * sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, or bool,
			 * Any enum type,
			 * Any pointer type,
			 * Any user-defined struct type that contains fields of unmanaged types only.
			 * https://stackoverflow.com/questions/42940040/why-is-pointer-to-generic-types-not-allowed
			 * 
			 */
			Intro();

			var pointerBasics = new PointerBasics();
			pointerBasics.Main();

			var arrayPointers = new ArrayPointers();
			arrayPointers.Main();

			var structPointers = new StructPointers();
			structPointers.Main();

			Console.ReadLine();
		}

		static void Intro()
		{
			Console.WriteLine("///////////////////////////////////////////////");
			Console.WriteLine("--- LEARNING ABOUT POINTERS AND UNSAFE CODE ---");
			Console.WriteLine("///////////////////////////////////////////////");
			Console.WriteLine();
			Console.WriteLine("Learned from youtube video:");
			Console.WriteLine("https://www.youtube.com/watch?v=oIqEBMw_Syk");
		}
	}
}
