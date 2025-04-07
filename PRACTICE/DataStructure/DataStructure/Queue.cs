using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructure
{
	public class Queue<T>
	{
		private T[] Data;
		public int Size
		{
			get
			{
				return Data.Length;
			}
		}

		public Queue()
		{
			Data = Array.Empty<T>();
		}

		public bool IsEmpty()
		{
			return Data.Length == 0;
		}

		public T OnFront()
		{
			if (IsEmpty())
			{
				throw new Exception("Queue is Empty");
			}
			return Data[0];
		}

		public T Attention()
		{
			if (IsEmpty())
			{
				throw new Exception("Queue is Empty");
			}
			T answer = Data[0];
			Data = Data[1..];
			return answer;
		}

		public void Arrive(T item)
		{
			Data = [.. Data, item];
		}

		public void MoveToEnd()
		{
			T element = Attention();
			if (element != null)
			{
				this.Arrive(element);
			}
		}

		public void Barrido()
		{
			Console.WriteLine("Barrido: ");
			for (int i = 0; i < Size; i++)
			{
				Console.Write(OnFront() + " ");
				MoveToEnd();
			}
			Console.WriteLine();
		}

		public static void Barrido(Queue<T> queue)
		{
			Console.WriteLine("Barrido: ");
			for (int i = 0; i < queue.Size; i++)
			{
				Console.Write(queue.OnFront() + " ");
				queue.MoveToEnd();
			}
			Console.WriteLine();
		}
	}
}
