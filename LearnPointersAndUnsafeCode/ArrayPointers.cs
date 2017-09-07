using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnPointersAndUnsafeCode
{
	class ArrayPointers
	{
		public ArrayPointers()
		{
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("//////////////////////////////////////////////");
			Console.WriteLine("--- POINTERS ARRAYS CLASS MAIN CALL BELOW ---");
			Console.WriteLine("//////////////////////////////////////////////");
			Console.WriteLine();
		}
		/* 
		 * To read arrays the user must pass the address of the first array postion. 
		 * The user must also tell the method the length of that array as code is 
		 * unable to tell the length of a array passed using a pointer.
		 */
		private unsafe void PrintArray(int* par, int len)
		{
			for (int i = 0; i < len; i++)
			{
				/*
				 * You can get the value of an array postion using either 
				 * "*(par+postionNumber)" or "par[postionNumber]"
				 * both operations have the same outcome
				 */
				Console.WriteLine("{0} {1}", *(par + i), par[i]);
			}
		}

		public void Main()
		{
			int[] ar = { 1, 2, 3, 4, 5 };

			// The code line below will not work because we are not passing the address of the array item 
			//PrintArray(ar, ar.Length);

			// The code lines below will also not work with arrays even though they would with intgers
			//PrintArray(&ar, ar.Length);
			//PrintArray(&ar[0], ar.Length);

			unsafe
			{

				/*
				 * HEAP METHOD
				 * -----------
				 * To fix the issue we have described above we would need to use the keyword "fixed".
				 * The "fixed" keyword tell visual studio not to garbage collect are array from the HEAP. 
				 * This will mean are pointer address will work and the garbage collector will not remove 
				 * or promote the array to a diffrent generation in the garbage colloector.
				 */
				Console.WriteLine("HEAP array");
				fixed (int* par = ar)
				{
					PrintArray(par, ar.Length);
				}

				/* 
				 * STACK METHOD
				 * ------------
				 * Another way to fix the issue is to create the array on the STACK using the keyword "stackallo".
				 * The downside to this method is that we lose the nice visual studio things such as the .length
				 * extension methods and such.
				 */
				Console.WriteLine("STACK array");
				int par1Length = 5;
				int* par1 = stackalloc int[par1Length];
				par1[0] = 1;
				par1[1] = 2;
				par1[2] = 3;
				par1[3] = 4;
				par1[4] = 5;
				PrintArray(par1, par1Length);

				/* 
				 * If you ask for array postion that does exsist / is bigger than the array length
				 * then the user will get a junk value back. This is why its always important to check
				 * your array lengths when using unsafe code because the compiler will not notice if
				 * its wrong. It will also not trow an out of bounds exception when running. Remmber
				 * unsafe code has no type check at runtime or compile time... any time!
				 */
				Console.WriteLine("Value returned when asking for a postion in the array that does not exist:");
				Console.WriteLine(par1[5]);
			}
			
		}

	}
}
