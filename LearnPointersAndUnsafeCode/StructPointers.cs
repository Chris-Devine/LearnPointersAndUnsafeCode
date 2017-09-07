using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnPointersAndUnsafeCode
{
	/*
	 * Unsafe code can also work with stuctures but note unsafe code does not work with classes.
	 * There are some rules to uses structures with unsafe code tho, such as only working with unmanaged
	 * value types, except arrays. This is because it does not work with HEAP memory only stack. So 
	 * refferance types such as string will not work as that uses HEAP memory. 
	 */
	struct Demo
	{
		public int M, N;
	}
	class StructPointers
	{
		public StructPointers()
		{
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("///////////////////////////////////////////////");
			Console.WriteLine("--- POINTERS ADVANCED CLASS MAIN CALL BELOW ---");
			Console.WriteLine("///////////////////////////////////////////////");
			Console.WriteLine();
		}

		private unsafe void PrintDemo(Demo* pDemo)
		{
			/*
			 * The first way to access the properties of the struct is to use the "*" followed by the stuct pointer
			 * contained in brackets. Then you simply use dot notation like you would a normal struct. As seen below.
			 */
			Console.WriteLine((*pDemo).N + " " + (*pDemo).M);

			/*
			 * The second way to access the value is to use the arrow function. As seen below
			 */
			Console.WriteLine(pDemo->N + " " + pDemo->M);
		}

		public void Main()
		{
			Demo d;
			d.M = 10;
			d.N = 20;
			unsafe
			{
				PrintDemo(&d);
			}
		}

	}
}
