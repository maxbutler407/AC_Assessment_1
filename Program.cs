// This program will help analyse Network Traffic data.

// System imports.
using System;

// Main program.
class Program
{
    public static int[] Net_1_256, Net_2_256, Net_3_256, Net_1_2048, Net_2_2048, Net_3_2048; // Defines the arrays that store the data.

    // This section defines all the methods that will be used.
    // Method performs a linear search on any given array.
    public static int LinearSearch(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++) // For loop iterates from the start of the array, across the length of the array.
        {
            if (array[i] == target) // Once the iterator hits the 'target' value in the array, the method returns i
                return i;
        }
        return -1;
    }

    // Method moves every line in each .txt file to its own array.
    static int[] CopyFileToArray(string filename) // Integer array, takes in filename as an argument (ie. .txt file name)
    {
        string[] lines = File.ReadAllLines(filename); // The string array reads the number of lines of text each file has.
        int[] values = new int[lines.Length]; // An integer array is also created, taking in the number of lines of each text file

        for (int i = 0; i < lines.Length; i++) // For loop then iterates across the number of lines in the file.
        {
            values[i] = int.Parse(lines[i]); // For each line, an integer is assigned to the line.
        }

        return values; // Returns the result in the 'values' variable.
    }

    static void Main(string[] args)
    {
        int Counter1 = 0;
        // Method uses the ReadFileToArray method to convert any .txt files into their own arrays.
        static void LoadData()
        {
            Net_1_256 = CopyFileToArray("Net_1_256.txt");
            Net_2_256 = CopyFileToArray("Net_2_256.txt");
            Net_3_256 = CopyFileToArray("Net_3_256.txt");
            Net_1_2048 = CopyFileToArray("Net_1_2048.txt");
            Net_2_2048 = CopyFileToArray("Net_2_2048.txt");
            Net_3_2048 = CopyFileToArray("Net_3_2048.txt");
        }
        // Calls the LoadData() method.
        LoadData();

        // Menu either selects which indvidual Array is to be analysed or which are to be merged and then analysed.
        Console.WriteLine("--------------------------------------------------------------- ");
        Console.WriteLine("Please enter the filename of the array you wish to be analysed: ");
        Console.WriteLine("\nOptionally, you can choose from one of the following:");
        Console.WriteLine("\nEnter '256Merge' to merge and analyse 'Net_1_256.txt' and 'Net_3_256.txt': ");
        Console.WriteLine("Enter '2048Merge' to merge and analyse 'Net_1_2048.txt' and 'Net_3_2048.txt': ");
        string option = Console.ReadLine();


        // If statement couples with menu to execute the user's choice.
        if (option == "Net_1_256")
        {
            Console.WriteLine("Analysing filename: Net_1_256.txt..."); // Tells user which filename is being analysed.

            Counter1 = Counter1 + 1;
            // Sorts Net_1_256 array into ascending order.
            int temp = 0; // Temporary value of 0 ends the for loops (lines 36-38).

            for (int i = 0; i <= Net_1_256.Length - 1; i++) // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_1_256.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_1_256[i] > Net_1_256[j]) // If statement checks if element i is greater than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0 
                        temp = Net_1_256[i];
                        Net_1_256[i] = Net_1_256[j];
                        Net_1_256[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_1_256 in ascending order:"); // Tells user the values will be sorted into ascending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_1_256)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            Counter1 = Counter1 + 1;
            // Sorts Net_1_256 array into descending order.
            for (int i = 0; i <= Net_1_256.Length - 1; i++)  // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_1_256.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_1_256[i] < Net_1_256[j])  // If statement checks if element i is less than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0.
                        temp = Net_1_256[i];
                        Net_1_256[i] = Net_1_256[j];
                        Net_1_256[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_1_256 in descending order:"); // Tells user the values will be sorted into descending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_1_256)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            Counter1 = Counter1 + 1;
            // Finds every 10th value in the Net_1_256 array.
            Console.Write("\nEvery 10th value of the array is: ");// Tells user every 10th value will be printed out.
            for (int i = 0; i < Net_1_256.Length && i * 10 < Net_1_256.Length; ++i) // For loop iterates from element 0, iterating across the two conditions (the length of the array and every 10th element, and increments i, then tells the value.
            {
                Console.Write(Net_1_256[i * 10] + ", "); // Prints a comma between each 10th element found by the for loop above.
            }

            Counter1 = Counter1 + 1;
            // Uses the LinearSearch function to find the requested element in the array
            Console.WriteLine("\nTo search for a value in the array, please enter the integer value you wish to search for: "); // Asks user to input an integer.
            int target = int.Parse(Console.ReadLine()); // The users input is set as the 'target' variable.
            int position = LinearSearch(Net_1_256, target); // The index variable is defined as the LinearSearch() method, using the chosen area and target varaible as arguments.

            // If statement states whether the 'target' has been found and its position within the array. If not, the nearest value is stated instead.
            if (position != -1)
                Console.WriteLine($"The value {target} has been found at index {position}.");
            else
                Console.WriteLine($"The value {target} was not found in Net_1_256.");

            Console.WriteLine($"Count is : {Counter1}");
        }

        else if (option == "Net_2_256")
        {
            Console.WriteLine("Analysing filename: Net_2_256.txt..."); // Tells user which filename is being analysed.

            // Sorts Net_2_256 array into ascending order.
            Counter1 = Counter1 + 1;
            int temp = 0; // Temporary value of 0 ends the for loops (lines 160-162).

            for (int i = 0; i <= Net_2_256.Length - 1; i++) // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_2_256.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_2_256[i] > Net_2_256[j]) // If statement checks if element i is greater than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0 
                        temp = Net_2_256[i];
                        Net_1_256[i] = Net_2_256[j];
                        Net_1_256[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_2_256 in ascending order:"); // Tells user the values will be sorted into ascending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_2_256)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Sorts Net_1_256 array into descending order.
            Counter1 = Counter1 + 1;
            for (int i = 0; i <= Net_2_256.Length - 1; i++)  // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_2_256.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_2_256[i] < Net_2_256[j])  // If statement checks if element i is less than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0.
                        temp = Net_2_256[i];
                        Net_2_256[i] = Net_2_256[j];
                        Net_2_256[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_2_256 in descending order:"); // Tells user the values will be sorted into descending order.

            Counter1 = Counter1 + 1;

            // Foreach prints each value on a new line.
            foreach (var item in Net_2_256)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Finds every 10th value in the Net_1_256 array.
            Counter1 = Counter1 + 1;
            Console.Write("\nEvery 10th value of the array is: ");// Tells user every 10th value will be printed out.
            for (int i = 0; i < Net_1_256.Length && i * 10 < Net_2_256.Length; ++i) // For loop iterates from element 0, iterating across the two conditions (the length of the array and every 10th element, and increments i, then tells the value.
            {
                Console.Write(Net_2_256[i * 10] + ", "); // Prints a comma between each 10th element found by the for loop above.
            }


            // Uses the LinearSearch function to find the requested element in the array
            Counter1 = Counter1 + 1;
            Console.WriteLine("\nTo search for a value in the array, please enter the integer value you wish to search for: "); // Asks user to input an integer.
            int target = int.Parse(Console.ReadLine()); // The users input is set as the 'target' variable.
            int position = LinearSearch(Net_2_256, target); // The index variable is defined as the LinearSearch() method, using the chosen area and target varaible as arguments.

            // If statement states whether the 'target' has been found and its position within the array. If not, the nearest value is stated instead.
            if (position != -1)
                Console.WriteLine($"The value {target} has been found at index {position}.");
            else
                Console.WriteLine($"The value {target} was not found in Net_2_256.");

            Console.WriteLine($"Count is : {Counter1}");
        }

        else if (option == "Net_3_256")
        {
            Console.WriteLine("Analysing filename: Net_3_256.txt..."); // Tells user which filename is being analysed.

            // Sorts Net_3_256 array into ascending order.
            Counter1 = Counter1 + 1;
            int temp = 0; // Temporary value of 0 ends the for loops (lines 237-239).

            for (int i = 0; i <= Net_3_256.Length - 1; i++) // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_3_256.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_3_256[i] > Net_3_256[j]) // If statement checks if element i is greater than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0. 
                        temp = Net_3_256[i];
                        Net_3_256[i] = Net_3_256[j];
                        Net_3_256[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_3_256 in ascending order:"); // Tells user the values will be sorted into ascending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_3_256)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Sorts Net_3_256 array into descending order.
            Counter1 = Counter1 + 1;
            for (int i = 0; i <= Net_3_256.Length - 1; i++)  // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_3_256.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_3_256[i] < Net_3_256[j])  // If statement checks if element i is less than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0.
                        temp = Net_3_256[i];
                        Net_3_256[i] = Net_3_256[j];
                        Net_3_256[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_3_256 in descending order:"); // Tells user the values will be sorted into descending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_3_256)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Finds every 10th value in the Net_1_256 array.
            Counter1 = Counter1 + 1;
            Console.Write("\nEvery 10th value of the array is: ");// Tells user every 10th value will be printed out.
            for (int i = 0; i < Net_3_256.Length && i * 10 < Net_3_256.Length; ++i) // For loop iterates from element 0, iterating across the two conditions (the length of the array and every 10th element, and increments i, then tells the value.
            {
                Console.Write(Net_3_256[i * 10] + ", "); // Prints a comma between each 10th element found by the for loop above.
            }


            // Uses the LinearSearch function to find the requested element in the array
            Counter1 = Counter1 + 1;
            Console.WriteLine("\nTo search for a value in the array, please enter the integer value you wish to search for: "); // Asks user to input an integer.
            int target = int.Parse(Console.ReadLine()); // The users input is set as the 'target' variable.
            int position = LinearSearch(Net_3_256, target); // The index variable is defined as the LinearSearch() method, using the chosen area and target varaible as arguments.

            // If statement states whether the 'target' has been found and its position within the array. If not, the nearest value is stated instead.
            if (position != -1)
                Console.WriteLine($"The value {target} has been found at index {position}.");
            else
                Console.WriteLine($"The value {target} was not found in Net_3_256.");

            Console.WriteLine($"Count is : {Counter1}");
        }
        else if (option == "Net_1_2048")
        {
            Console.WriteLine("Analysing filename: Net_1_2048.txt..."); // Tells user which filename is being analysed.

            // Sorts Net_1_2048 array into ascending order.
            Counter1 = Counter1 + 1;
            int temp = 0; // Temporary value of 0 ends the for loops (lines 312-314).

            for (int i = 0; i <= Net_1_2048.Length - 1; i++) // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_1_2048.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_1_2048[i] > Net_1_2048[j]) // If statement checks if element i is greater than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0 
                        temp = Net_1_2048[i];
                        Net_1_2048[i] = Net_1_2048[j];
                        Net_1_2048[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_1_2048 in ascending order:"); // Tells user the values will be sorted into ascending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_1_2048)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Sorts Net_1_2048 array into descending order.
            Counter1 = Counter1 + 1;
            for (int i = 0; i <= Net_1_2048.Length - 1; i++)  // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_1_2048.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_1_2048[i] < Net_1_2048[j])  // If statement checks if element i is less than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0.
                        temp = Net_1_2048[i];
                        Net_1_2048[i] = Net_1_2048[j];
                        Net_1_2048[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_1_2048 in descending order:"); // Tells user the values will be sorted into descending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_1_2048)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Finds every 50th value in the Net_1_2048 array.
            Counter1 = Counter1 + 1;
            Console.Write("\nEvery 50th value of the array is: ");// Tells user every 50th value will be printed out.
            for (int i = 0; i < Net_1_2048.Length && i * 50 < Net_1_2048.Length; ++i) // For loop iterates from element 0, iterating across the two conditions (the length of the array and every 50th element, and increments i, then tells the value.
            {
                Console.Write(Net_1_2048[i * 50] + ", "); // Prints a comma between each 50th element found by the for loop above.
            }


            // Uses the LinearSearch function to find the requested element in the array
            Counter1 = Counter1 + 1;
            Console.WriteLine("\nTo search for a value in the array, please enter the integer value you wish to search for: "); // Asks user to input an integer.
            int target = int.Parse(Console.ReadLine()); // The users input is set as the 'target' variable.
            int position = LinearSearch(Net_1_2048, target); // The index variable is defined as the LinearSearch() method, using the chosen area and target variable as arguments.

            // If statement states whether the 'target' has been found and its position within the array. If not, the nearest value is stated instead.
            if (position != -1)
                Console.WriteLine($"The value {target} has been found at index {position}.");
            else
                Console.WriteLine($"The value {target} was not found in Net_1_2048.");

            Console.WriteLine($"Count is : {Counter1}");
        }

        else if (option == "Net_2_2048")
        {
            Console.WriteLine("Analysing filename: Net_2_2048.txt..."); // Tells user which filename is being analysed.

            // Sorts Net_2_2048 array into ascending order.
            Counter1 = Counter1 + 1;
            int temp = 0; // Temporary value of 0 ends the for loops (lines 388-390).

            for (int i = 0; i <= Net_2_2048.Length - 1; i++) // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_2_2048.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_2_2048[i] > Net_2_2048[j]) // If statement checks if element i is greater than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0 
                        temp = Net_2_2048[i];
                        Net_2_2048[i] = Net_2_2048[j];
                        Net_2_2048[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_2_2048 in ascending order:"); // Tells user the values will be sorted into ascending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_2_2048)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Sorts Net_2_2048 array into descending order.
            Counter1 = Counter1 + 1;
            for (int i = 0; i <= Net_2_2048.Length - 1; i++)  // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_2_2048.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_2_2048[i] < Net_2_2048[j])  // If statement checks if element i is less than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0.
                        temp = Net_2_2048[i];
                        Net_2_2048[i] = Net_2_2048[j];
                        Net_2_2048[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_2_2048 in descending order:"); // Tells user the values will be sorted into descending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_2_2048)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Finds every 50th value in the Net_2_2048 array.
            Counter1 = Counter1 + 1;
            Console.Write("\nEvery 50th value of the array is: ");// Tells user every 50th value will be printed out.
            for (int i = 0; i < Net_2_2048.Length && i * 50 < Net_2_2048.Length; ++i) // For loop iterates from element 0, iterating across the two conditions (the length of the array and every 50th element, and increments i, then tells the value.
            {
                Console.Write(Net_2_2048[i * 50] + ", "); // Prints a comma between each 50th element found by the for loop above.
            }


            // Uses the LinearSearch function to find the requested element in the array.
            Counter1 = Counter1 + 1;
            Console.WriteLine("\nTo search for a value in the array, please enter the integer value you wish to search for: "); // Asks user to input an integer.
            int target = int.Parse(Console.ReadLine()); // The users input is set as the 'target' variable.
            int position = LinearSearch(Net_2_2048, target); // The index variable is defined as the LinearSearch() method, using the chosen area and target variable as arguments.

            // If statement states whether the 'target' has been found and its position within the array. If not, the nearest value is stated instead.
            if (position != -1)
                Console.WriteLine($"The value {target} has been found at index {position}.");
            else
                Console.WriteLine($"The value {target} was not found in Net_2_2048.");

            Console.WriteLine($"Count is : {Counter1}");
        }
        else if (option == "Net_3_2048")
        {
            Console.WriteLine("Analysing filename: Net_3_2048.txt..."); // Tells user which filename is being analysed.

            // Sorts Net_3_2048 array into ascending order.
            Counter1 = Counter1 + 1;
            int temp = 0; // Temporary value of 0 ends the for loops (lines 388-390).

            for (int i = 0; i <= Net_3_2048.Length - 1; i++) // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_3_2048.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_3_2048[i] > Net_3_2048[j]) // If statement checks if element i is greater than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0 
                        temp = Net_3_2048[i];
                        Net_3_2048[i] = Net_3_2048[j];
                        Net_3_2048[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_3_2048 in ascending order:"); // Tells user the values will be sorted into ascending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_3_2048)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Sorts Net_3_2048 array into descending order.
            Counter1 = Counter1 + 1;
            for (int i = 0; i <= Net_3_2048.Length - 1; i++)  // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < Net_3_2048.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (Net_3_2048[i] < Net_3_2048[j])  // If statement checks if element i is less than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0.
                        temp = Net_3_2048[i];
                        Net_3_2048[i] = Net_3_2048[j];
                        Net_3_2048[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in Net_3_2048 in descending order:"); // Tells user the values will be sorted into descending order.

            // Foreach prints each value on a new line.
            foreach (var item in Net_3_2048)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Finds every 50th value in the Net_3_2048 array.
            Counter1 = Counter1 + 1;
            Console.Write("\nEvery 50th value of the array is: ");// Tells user every 50th value will be printed out.
            for (int i = 0; i < Net_3_2048.Length && i * 50 < Net_3_2048.Length; ++i) // For loop iterates from element 0, iterating across the two conditions (the length of the array and every 50th element, and increments i, then tells the value.
            {
                Console.Write(Net_3_2048[i * 50] + ", "); // Prints a comma between each 50th element found by the for loop above.
            }


            // Uses the LinearSearch function to find the requested element in the array
            Counter1 = Counter1 + 1;
            Console.WriteLine("\nTo search for a value in the array, please enter the integer value you wish to search for: "); // Asks user to input an integer.
            int target = int.Parse(Console.ReadLine()); // The users input is set as the 'target' variable.
            int position = LinearSearch(Net_3_2048, target); // The index variable is defined as the LinearSearch() method, using the chosen area and target variable as arguments.

            // If statement states whether the 'target' has been found and its position within the array. If not, the nearest value is stated instead.
            if (position != -1)
                Console.WriteLine($"The value {target} has been found at index {position}.");
            else
                Console.WriteLine($"The value {target} was not found in Net_3_2048.");

            Console.WriteLine($"Count is : {Counter1}");
        }
        else if (option == "256Merge")
        {
            Console.WriteLine("Net_1_256 and Net_3_256 filenames will now be merged...");
            Counter1 = Counter1 + 1;
            int[] merged_256 = Net_1_256.Concat(Net_3_256).ToArray(); // An integer array is created that concats Net_1_256 and Net_3_256 together using the Concat() method. The result is added to the integer array using the ToArray() method.
            Console.WriteLine(String.Join(" ", merged_256)); // Uses the Join() method to create a space between each element in the merged integer array.

            Console.ReadKey();

            // Sorts merged array into ascending order.
            Counter1 = Counter1 + 1;
            int temp = 0; // Temporary value of 0 ends the for loops (lines 36-38).

            for (int i = 0; i <= merged_256.Length - 1; i++) // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < merged_256.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (merged_256[i] > merged_256[j]) // If statement checks if element i is greater than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0 
                        temp = merged_256[i];
                        merged_256[i] = merged_256[j];
                        merged_256[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in merged_256 in ascending order:"); // Tells user the values will be sorted into ascending order.

            // Foreach prints each value on a new line.
            foreach (var item in merged_256)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Sorts merged_256 array into descending order.
            Counter1 = Counter1 + 1;
            for (int i = 0; i <= merged_256.Length - 1; i++)  // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < merged_256.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (merged_256[i] < merged_256[j])  // If statement checks if element i is less than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0.
                        temp = merged_256[i];
                        merged_256[i] = merged_256[j];
                        merged_256[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in merged_256 in descending order:"); // Tells user the values will be sorted into descending order.

            // Foreach prints each value on a new line.
            foreach (var item in merged_256)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Finds every 10th value in the merged_256 array.
            Counter1 = Counter1 + 1;
            Console.Write("\nEvery 10th value of the array is: ");// Tells user every 10th value will be printed out.
            for (int i = 0; i < merged_256.Length && i * 10 < merged_256.Length; ++i) // For loop iterates from element 0, iterating across the two conditions (the length of the array and every 10th element, and increments i, then tells the value.
            {
                Console.Write(merged_256[i * 10] + ", "); // Prints a comma between each 10th element found by the for loop above.
            }


            // Uses the LinearSearch function to find the requested element in the array.
            Counter1 = Counter1 + 1;
            Console.WriteLine("\nTo search for a value in the array, please enter the integer value you wish to search for: "); // Asks user to input an integer.
            int target = int.Parse(Console.ReadLine()); // The users input is set as the 'target' variable.
            int position = LinearSearch(merged_256, target); // The index variable is defined as the LinearSearch() method, using the chosen area and target varaible as arguments.

            // If statement states whether the 'target' has been found and its position within the array. If not, the nearest value is stated instead.
            if (position != -1)
                Console.WriteLine($"The value {target} has been found at index {position}.");
            else
                Console.WriteLine($"The value {target} was not found in merged_256.");

            Console.WriteLine($"Count is : {Counter1}");
        }

        else if (option == "2048Merge")
        {
            Console.WriteLine("Net_1_2048 and Net_3_2048 filenames will now be merged...");
            Counter1 = Counter1 + 1;
            int[] merged_2048 = Net_1_2048.Concat(Net_3_2048).ToArray(); // An integer array is created that concats Net_1_2048 and Net_3_2048 together using the Concat() method. The result is added to the integer array using the ToArray() method.
            Console.WriteLine(String.Join(" ", merged_2048)); // Uses the Join() method to create a space between each element in the merged integer array.

            Console.ReadKey();

            // Sorts merged array into ascending order.
            Counter1 = Counter1 + 1;
            int temp = 0; // Temporary value of 0 ends the for loops (lines 619 - 621).

            for (int i = 0; i <= merged_2048.Length - 1; i++) // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < merged_2048.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (merged_2048[i] > merged_2048[j]) // If statement checks if element i is greater than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0 
                        temp = merged_2048[i];
                        merged_2048[i] = merged_2048[j];
                        merged_2048[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in merged_2048 in ascending order:"); // Tells user the values will be sorted into ascending order.

            // Foreach prints each value on a new line.
            foreach (var item in merged_2048)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Sorts merged_2048 array into descending order.
            Counter1 = Counter1 + 1;
            for (int i = 0; i <= merged_2048.Length - 1; i++)  // For loop checks the first position of the array and iterates the length of the array.
            {
                for (int j = i + 1; j < merged_2048.Length; j++) // For loop defines j as iterating from the i+1 position and iterates the length of the array.
                {
                    if (merged_2048[i] < merged_2048[j])  // If statement checks if element i is less than element j, elements are both set to 0 and ends the for loops. 
                    {
                        // For loops end once the iterator 'i' in the array is set to 0.
                        temp = merged_2048[i];
                        merged_2048[i] = merged_2048[j];
                        merged_2048[j] = temp;
                    }
                }
            }
            Console.WriteLine("Values in merged_2048 in descending order:"); // Tells user the values will be sorted into descending order.

            // Foreach prints each value on a new line.
            foreach (var item in merged_2048)
            {
                Console.WriteLine(item);
            }

            // Waits for user input before executing the next algorithm.
            Console.ReadKey();

            // Finds every 10th value in the merged_2048 array.
            Counter1 = Counter1 + 1;
            Console.Write("\nEvery 10th value of the array is: ");// Tells user every 10th value will be printed out.
            for (int i = 0; i < merged_2048.Length && i * 10 < merged_2048.Length; ++i) // For loop iterates from element 0, iterating across the two conditions (the length of the array and every 10th element, and increments i, then tells the value.
            {
                Console.Write(merged_2048[i * 10] + ", "); // Prints a comma between each 10th element found by the for loop above.
            }


            // Uses the LinearSearch function to find the requested element in the array.
            Counter1 = Counter1 + 1;
            Console.WriteLine("\nTo search for a value in the array, please enter the integer value you wish to search for: "); // Asks user to input an integer.
            int target = int.Parse(Console.ReadLine()); // The users input is set as the 'target' variable.
            int position = LinearSearch(merged_2048, target); // The index variable is defined as the LinearSearch() method, using the chosen area and target varaible as arguments.

            // If statement states whether the 'target' has been found and its position within the array. If not, the nearest value is stated instead.
            if (position != -1)
                Console.WriteLine($"The value {target} has been found at index {position}.");
            else
                Console.WriteLine($"The value {target} was not found in merged_2048.");

            Console.WriteLine($"Count is : {Counter1}");
        }

        else
        {
            // If user inputs invalid input, the following error messages will be printed
            Console.WriteLine("Invalid input: please try entering a valid option.");
            Console.WriteLine("Your options are: 'Net_1_256', 'Net_2_256', 'Net_3_256', 'Net_1_2048', 'Net_2_2048', 'Net_3_2048', 'Merge256', 'Merge2048'.");
        }
    }
}