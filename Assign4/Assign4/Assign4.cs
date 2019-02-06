/* Author: Brianna Drew
Student ID: 0622446
Description: This is a program for Air Canada that manages seating assignments on an airplane.

Data Dictionary (Variables):
 * cName: string variable that holds the customer's name entered by the user to be assigned a seat or to search for existing assigned seat to be cancelled.
 * command: char variable that holds the command in which the user wants to do ('B' to book a seat,'C' to cancel a seat, 'P' to print seating assignments, or 'Q' to quit).
 * i: int variable used as a counter in for loops to count which index of SeatAssign array the for loop is on.
 * result: int variable to hold the seat number the booking or cancellation was made for, or a -1 if the action could not be completed.
 * SeatAssign: array that holds 10 strings representing 10 seats on the plane (0-9), item will either hold the name of the customer assigned to that seat, or "" for empty seat.*/

using System;
public static class Assign4
{
    public static void Main()
    {
        // defining variables/arrays and their data types.
        char command;
        string[] SeatAssign = new string[10] {"", "", "", "", "", "", "", "", "", ""};

        // introduction to the program.
        Console.WriteLine("Welcome to the Air Canada airline reservation system.");

        do
        {
            // prompt the user to enter their command.
            Console.WriteLine(" ");
            Console.Write("Enter B to book a seat, C to cancel a seat, P to print seating assignments, or Q to quit. ");
            command = (Convert.ToChar(Console.ReadLine()));

            switch (command)
            {
                // if the user chooses to book a seat.
                case 'B':
                case 'b':
                    // calls the method to perform the booking.
                    Booking(SeatAssign);
                    break; // exit loop.
                // if the user chooses to cancel a seat.
                case 'C':
                case 'c':
                    // calls the method to cancel a seat.
                    Cancel(SeatAssign);
                    break; // exit loop.
                // if the user chooses to print all the seating assignments.
                case 'P':
                case 'p':
                    // calls the method to print all the seating assignments.
                    PrintSeats(SeatAssign);
                    break; // exit loop.
                // if the user chooses to quit the program.
                case 'Q':
                case 'q':
                    break; // exit loop.
                // if the user enters an invalid command.
                default:
                    // error message.
                    Console.WriteLine(" ");
                    Console.WriteLine("Invalid entry. Please try again.");
                    break; // exit loop.
            }
        } while (command != 'Q' && command != 'q'); // stay in the do while loop while the user does not enter 'Q' or 'q' as the command.

        Console.ReadLine();
    }

    // Method: FindEmptySeat
    // Parameters
    //      SeatAssign: array of strings representing seats on the plane storing the name of the occupant of that seat (or "" if seat is empty).
    // Returns: int representing the result (either the seat number for the first empty seat found, or -1 if no empty seats are found).
    public static int FindEmptySeat(string [] SeatAssign)
    {
        // define variable and data type.
        int result = -1;

        for (int i = 0; i < SeatAssign.Length; ++i) // for each seat on the plane... (0-9)
        {
            if (SeatAssign[i] == "") // if the seat is empty...
            {
                result = i; // result is that seat number.
                break; // exit loop.
            }
        }
        return result;
    }

    // Method: FindCustomerSeat
    // Parameters:
    //      SeatAssign: array of strings representing seats on the plane storing the name of the occupant of that seat (or "" if seat is empty).
    //      cName: string that stores the user inputted customer name (from Cancel() method) to be able to find a seat occupied by that name to cancel.
    // Returns: int representing the result (either the seat number for the given customer, or -1 if no seats are found under that name).
    public static int FindCustomerSeat(string [] SeatAssign, string cName)
    {
        // define variable and data type.
        int result = -1;

        for (int i = 0; i < SeatAssign.Length; ++i) // for each seat on the plane... (0-9)
        {
            if (SeatAssign[i] == cName) // if the seat is assigned to the given customer...
            {
                result = i; // result is that seat number.
                break; // exit loop.
            }
        }
        return result;
    }

    // Method: Booking
    // Parameters:
    //      SeatAssign: array of strings representing seats on the plane storing the name of the occupant of that seat (or "" if seat is empty).
    // Returns: void
    public static void Booking(string [] SeatAssign)
    {
        // define variables and data types.
        string cName;
        int result;

        // prompt the user to enter the name of the customer.
        Console.WriteLine(" ");
        Console.Write("Enter the customer's name: ");
        cName = (Convert.ToString(Console.ReadLine()));

        // call method to find number of the first empty seat available.
        result = FindEmptySeat(SeatAssign);

        if (result == -1) // if no empty seats were found...
        {
            // print message saying there were no empty seats avaialble.
            Console.WriteLine(" ");
            Console.WriteLine("There are no empty seats available for {0}.", cName);
        }
        else // if there was an empty seat found...
        {
            // assign that seat to the given customer.
            SeatAssign[result] = cName;
            Console.WriteLine(" ");
            // print confirmation message with the details of the booking.
            Console.WriteLine("{0} has been assigned to seat {1} successfully.", cName, result);
        }
    }

    // Method: Cancel
    // Parameters:
    //      SeatAssign: array of strings representing seats on the plane storing the name of the occupant of that seat (or "" if seat is empty).
    // Returns: void
    public static void Cancel(string [] SeatAssign)
    {
        // define variables and data types.
        string cName;
        int result;

        // prompt the user to enter the name of the customer.
        Console.WriteLine(" ");
        Console.Write("Enter the customer's name: ");
        cName = (Convert.ToString(Console.ReadLine()));

        // call method to find the given customer's seat number.
        result = FindCustomerSeat(SeatAssign, cName);

        if (result == -1) // if there were no seats assigned to the given customer...
        {
            // print message saying that there are no seats assigned to that customer.
            Console.WriteLine(" ");
            Console.WriteLine("There are no seats assigned to the name {0}.", cName);
        }
        else // if there was a seat assigned to the given customer...
        {
            // make that seat empty (cancelling it).
            SeatAssign[result] = "";
            Console.WriteLine(" ");
            // print out a confirmation message with the details of the cancellation.
            Console.WriteLine("{0}'s seat {1} has been cancelled successfully.", cName, result);
        }
    }

    // Method: PrintSeats
    // Parameters:
    //      SeatAssign: array of strings representing seats on the plane storing the name of the occupant of that seat (or "" if seat is empty).
    // Returns: void
    public static void PrintSeats(string [] SeatAssign)
    {
        Console.WriteLine(" ");

        for (int i = 0; i < SeatAssign.Length; ++i) // for each seat on the plane... (0-9)
        {
            if (SeatAssign[i] != "") // if the seat isn't empty...
            {
                // print out that seat number and the customer assigned to it.
                Console.WriteLine("Seat #: {0}, Occupant Name: {1}", i, SeatAssign[i]);
            }
            else // if the seat is empty...
            {
                // print out the seat number and the fact that it's empty.
                Console.WriteLine("-----------{0} IS EMPTY SEAT-----------", i);
            }
        }
    }
}