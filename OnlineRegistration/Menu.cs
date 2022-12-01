using OnlineRegistration.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRegistration
{
	class Menu
	{

		private Doctor doctorCommand = new Doctor();
		private Person personCommand = new Person();

		public void runMenu()
		{
			showMenuOption();
		}


		private void showMenuOption()
		{
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				Console.WriteLine("Welcome to the Online Registration\n");
				Console.WriteLine("Please select an option:\n");
				Console.WriteLine("1) Work with Doctor");
				Console.WriteLine("2) Work with Person");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectShowMenuOption(userInput);
			}
		}

		private void selectShowMenuOption(char userInput)
		{
			switch (userInput)
			{
				case '1':
					showDoctorMenu();
					break;
				case '2':
					showPersonMenu();
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

		private void showDoctorMenu()
		{
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				doctorCommand.PrintAllDoctorCommand();
				Console.WriteLine();
				Console.WriteLine("1) Create doctor");
				Console.WriteLine("2) Edit doctor");
				Console.WriteLine("3) Delete doctor");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectDoctorMenuOption(userInput);
			}
		}

		private void selectDoctorMenuOption(char userInput)
		{
			switch (userInput)
			{
				case '1':
					AddDoctorMenu();
					break;
				case '2':
					ChangeDoctorMenu();
					break;
				case '3':
					DeleteDoctorMenu();
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

		private void DeleteDoctorMenu()
		{
			Console.Clear();
			int? doctorId = null;
			while (!(doctorId is int)) doctorId = TrySelectDoctorByIDMenu();

			doctorCommand.DeleteDoctorCommand((int)doctorId);
		}

		private int? TrySelectDoctorByIDMenu()
		{
			Console.Clear();
			doctorCommand.PrintAllDoctorCommand();

			int doctorId;

			Console.Write("\nSelect the doctor id : ");

			bool success = int.TryParse(Console.ReadLine(), out doctorId);
			return success ? (int?)doctorId : (int?)null;
		}

		private void ChangeDoctorMenu()
		{
			int? doctorId = null;
			while (!(doctorId is int)) doctorId = TrySelectDoctorByIDMenu();

			Console.Clear();
			Console.WriteLine("Enter a new specielization of the doctor : ");
			string specielization = Console.ReadLine();
			Console.WriteLine("Enter a new person Id of the doctor : ");
			int personId;
			int.TryParse(Console.ReadLine(), out personId);

			doctorCommand.EditDoctorCommand((int)doctorId, specielization, personId);
		}

		private void AddDoctorMenu()
		{
			Console.Clear();
			Console.WriteLine("Enter specielization of the doctor : ");
			string specielization = Console.ReadLine();
			Console.WriteLine("Enter person Id of the doctor : ");
			int personId;
			int.TryParse(Console.ReadLine(), out personId);

			doctorCommand.CreateDoctorCommand(specielization, personId);

		}

		private void showPersonMenu()
		{
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				personCommand.PrintAllPersonCommand();
				Console.WriteLine();
				Console.WriteLine("1) Create person");
				Console.WriteLine("2) Edit person");
				Console.WriteLine("3) Delete person");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectPersonMenuOption(userInput);
			}
		}

		private void selectPersonMenuOption(char userInput)
		{
			switch (userInput)
			{
				case '1':
					CreatePersonMenu();
					break;
				case '2':
					EditPersonMenu();
					break;
				case '3':
					DeletePersonMenu();
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

		private void DeletePersonMenu()
		{
			Console.Clear();
			int? personId = null;
			while (!(personId is int)) personId = TrySelectPersonByIDMenu();

			personCommand.DeletePersonCommand((int)personId);
		}

		private void CreatePersonMenu()
		{
			Console.Clear();
			Console.WriteLine("Enter a new name of the person : ");
			string name = Console.ReadLine();
			Console.WriteLine("Enter a new address of the person : ");
			string address = Console.ReadLine();
			Console.WriteLine("Enter a new phone of the person : ");
			string phone = Console.ReadLine();

			personCommand.CreatePersonCommand(name, address, phone);
		}

		private void EditPersonMenu()
		{
			int? personId = null;
			while (!(personId is int)) personId = TrySelectPersonByIDMenu();

			Console.Clear();
			Console.WriteLine("Enter a new name of the person : ");
			string name = Console.ReadLine();
			Console.WriteLine("Enter a new address of the person : ");
			string address = Console.ReadLine();
			Console.WriteLine("Enter a new phone of the person : ");
			string phone = Console.ReadLine();

			personCommand.EditPersonCommand((int)personId, name, address, phone);
		}

		private int? TrySelectPersonByIDMenu()
		{
			Console.Clear();
			personCommand.PrintAllPersonCommand();

			int personId;

			Console.Write("\nSelect the person id : ");

			bool success = int.TryParse(Console.ReadLine(), out personId);
			return success ? (int?)personId : (int?)null;
		}

		private void printDefaultSwitchStringMenu()
		{
			Console.WriteLine("\nWrong command selected");
		}
	}
}



