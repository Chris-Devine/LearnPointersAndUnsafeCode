using System;
namespace LearnPointersAndUnsafeCode
{
	class PointerBasics
	{
		public PointerBasics()
		{
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("/////////////////////////////////////////////");
			Console.WriteLine("--- POINTERS BASICs CLASS MAIN CALL BELOW ---");
			Console.WriteLine("/////////////////////////////////////////////");
			Console.WriteLine();
		}

		private int Square(int n)
		{
			return n * n;
		}

		// To use unsafe code in the paramaters of a method you must use the keyword "unsafe" unless the unsafe keyword has been used at the class level 
		private unsafe void Square(int* pn)
		{
			/*
			 * A "*" beore the variable name means take value at the memory address passed in the variable. In the line below we saying 
			 * "Take the value of pn (wich is a memory address), got to the memory address location and retrive the value, do the square function and save the new value back to that address"
			 * So bear in mind the value of "pn", which is and memory address is diffrent to the value of stored in memory wich can be seen using "*pn"
			 */
			*pn = *pn * *pn;
		}

		public void Main()
		{
			// Setup 
			int n;
			n = 10;

			// Using normale method and no pointers
			int nonePointer;
			nonePointer = Square(n);
			WriteOutputforNonePointer(n, nonePointer);
			

			// Using pointers method
			// to use unsafe code code with a safe method you must use and unsafe keyword code block
			// To pass the address space of the variable n, you need to use an ampersand "&" before the variable name
			Console.WriteLine("with pointers and no return value");
			unsafe
			{
				// "&" means "address of". In line below we are passing the memory address of variable "n"
				Square(&n);
			}
			Console.WriteLine("n = {0}", n);
		}

		// Just to clean up main clode block to make it easier to read
		private void WriteOutputforNonePointer(int n, int nonePointer)
		{
			Console.WriteLine();
			Console.WriteLine("without pointers");
			Console.WriteLine("n = {0}", n);
			Console.WriteLine("none pointer method return value = {0}", nonePointer);
			Console.WriteLine();
		}

		// The main benefit of pointers is a better performace 
	}
}
