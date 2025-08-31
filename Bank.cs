using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        Dictionary<string, int> accounts = new Dictionary<string, int>();

        
        accounts["Omar"] = 100;

        
        string customerName = "Omar";
        int depositAmount = 50;

        if (accounts.ContainsKey(customerName))
        {
           
            Console.WriteLine($"{customerName} found in system with balance {accounts[customerName]}.");
            accounts[customerName] += depositAmount;
            Console.WriteLine($"Updated balance: {accounts[customerName]}");
        }
        else
        {
            
            accounts[customerName] = depositAmount;
            Console.WriteLine($"{customerName} was not found. New account created with balance {accounts[customerName]}.");
        }
    }
}
