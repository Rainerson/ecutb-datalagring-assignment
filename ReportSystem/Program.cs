using ReportSystem.Services;

var menu = new MenuService();
while (true)
{
    Console.Clear();

    Console.WriteLine("Välkommen till Felrapportering");
    Console.WriteLine("1. Skapa ett ärende");
    Console.WriteLine("2. Visa alla ärenden");
    Console.WriteLine("3. Visa ett specifikt");
    Console.WriteLine("4. Byt status på ett ärende");
    Console.WriteLine("Välj ett av alternativen ovan");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await menu.CreateReport(); break;

        case "2":
            Console.Clear();
            await menu.ShowAllReports(); break;

        case "3":
            Console.Clear();
            await menu.ShowOneReport(); break;

        case "4":
            Console.Clear();
            await menu.UpdateReportStatus(); break;

    }
}

