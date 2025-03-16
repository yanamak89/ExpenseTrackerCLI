using ExpenseTrackerCLI;

class Program
{
    static void Main(string[] args)
    {
        var tracker = new ExpenseTracker();
        if (args.Length == 0) { Console.WriteLine("Usage: expense-tracker <command> [options]"); return; }
        
        switch (args[0])
        {
            case "add":
                if (args.Length < 4) { Console.WriteLine("Usage: add --description <desc> --amount <amount>"); return; }
                string desc = args[2];
                if (!decimal.TryParse(args[4], out decimal amount)) { Console.WriteLine("Invalid amount"); return; }
                tracker.AddExpense(desc, amount);
                break;
            
            case "list":
                tracker.ListExpenses();
                break;

            case "delete":
                if (args.Length < 3 || !int.TryParse(args[2], out int id)) { Console.WriteLine("Invalid ID"); return; }
                tracker.DeleteExpense(id);
                break;

            case "summary":
                int? month = args.Length == 3 && int.TryParse(args[2], out int m) ? m : null;
                tracker.ShowSummary(month);
                break;

            default:
                Console.WriteLine("Unknown command");
                break;
        }
    }
}