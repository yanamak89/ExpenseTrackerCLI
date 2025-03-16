using System.Globalization;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace ExpenseTrackerCLI;

public class ExpenseTracker
{
    private const string FilePath = "expenses.json";
    private List<Expense> expenses;

    public ExpenseTracker()
    {
        expenses = LoadExpenses();
    }

    private List<Expense> LoadExpenses()
    {
        if (!File.Exists(FilePath)) return new List<Expense>();
        string json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<Expense>>(json) ?? new List<Expense>();
    }

    private void SaveExpenses()
    {
        File.WriteAllText(FilePath, JsonConvert.SerializeObject(expenses, (Newtonsoft.Json.Formatting)Formatting.Indented));
    }

    public void AddExpense(string description, decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Error: Amount should be positive.");
            return;
        }
        var expense = new Expense { Id = expenses.Count + 1, Date = DateTime.Now, Description = description, Amount = amount };
        expenses.Add(expense);
        SaveExpenses();
        Console.WriteLine($"Expense added successfully (ID: {expense.Id})");
    }

    public void ListExpenses()
    {
        Console.WriteLine("# ID  Date       Description  Amount");
        foreach (var e in expenses)
        {
            Console.WriteLine($"# {e.Id}   {e.Date:yyyy-MM-dd}  {e.Description}  ${e.Amount}");
        }
    }

    public void DeleteExpense(int id)
    {
        var expense = expenses.FirstOrDefault(e => e.Id == id);
        if (expense == null)
        {
            Console.WriteLine("Error: Expense ID not found.");
            return;
        }
        expenses.Remove(expense);
        SaveExpenses();
        Console.WriteLine("Expense deleted successfully");
    }

    public void ShowSummary(int? month = null)
    {
        var filteredExpenses = month.HasValue ?
            expenses.Where(e => e.Date.Month == month.Value && e.Date.Year == DateTime.Now.Year) : expenses;
        decimal total = filteredExpenses.Sum(e => e.Amount);
        Console.WriteLine(month.HasValue
            ? $"Total expenses for {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month.Value)}: ${total}"
            : $"Total expenses: ${total}");
    }
}