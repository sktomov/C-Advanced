using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ParkingLot
{
	class Parking
	{
		static void Main(string[] args)
		{
			var matrixDimension = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			var rows = matrixDimension[0];
			var cols = matrixDimension[1];
			var parking = new Dictionary<int, bool[]>();
			



			var cmd = Console.ReadLine();
			while (cmd != "stop")
			{
				var arr = cmd.Split(' ').Select(int.Parse).ToArray();
				var entryRow = arr[0];
				var parkingRow = arr[1];
				var parkingCol = arr[2];
				if (!parking.ContainsKey(parkingRow))
				{
					parking[parkingRow] = new bool[cols];
				}
				FindPlace(parking, entryRow, parkingRow, parkingCol);
				cmd = Console.ReadLine();
			}

		}

		private static void FindPlace(Dictionary<int, bool[]> parking, int entryRow, int parkingRow, int parkingCol)
		{
			var check = parking[parkingRow].Skip(1).ToArray();
			if (check.All(b => b == true))
			{
				Console.WriteLine($"Row {parkingRow} full");
			}
			else
			{
				var moveUpDown = Math.Abs(entryRow - parkingRow);
				var moves = 0;
				var allMoves = 0;
				if (parking[parkingRow][parkingCol] == false)
				{
					moves = parkingCol + 1;
					allMoves = moveUpDown + moves;
					parking[parkingRow][parkingCol] = true;
					Console.WriteLine(allMoves);
				}
				else
				{
					//find near place
					var leftIndex = 0;
					var rightIndex = 0;
					bool findLeft = false;
					bool findRight = false;
					//left from lot
					for (int i = parkingCol - 1; i >= 1; i--)
					{
						if (parking[parkingRow][i] == false)
						{
							findLeft = true;
							leftIndex = i;
							break;
						}
					}
					
					for (int i = parkingCol + 1; i <= parking[parkingRow].Length - 1; i++)
					{
						if (parking[parkingRow][i] == false)
						{
							findRight = true;
							rightIndex = i;
							break;
						}
					}


					if (findLeft && findRight)
					{
						if (parkingCol - leftIndex <= rightIndex - parkingCol)
						{
							parking[parkingRow][leftIndex] = true;
							moves = leftIndex + 1 + moveUpDown;
							Console.WriteLine(moves);
						}
						else
						{
							parking[parkingRow][rightIndex] = true;
							moves = rightIndex + 1 + moveUpDown;
							Console.WriteLine(moves);
						}
					}
					if (findLeft && !findRight)
					{
						parking[parkingRow][leftIndex] = true;
						moves = leftIndex + 1 + moveUpDown;
						Console.WriteLine(moves);
					}
					if (!findLeft && findRight)
					{
						parking[parkingRow][rightIndex] = true;
						moves = rightIndex + 1 + moveUpDown;
						Console.WriteLine(moves);
					}


				}
			}
		}
	}
}

