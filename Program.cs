namespace EmpresaApp;

public class Empresa
{
    private const double MinSalary = 207.44;
    private const double GiftBonusPerChild = 150;
    private const string AppTitle = "ACTIVIDAD 6. EMPRESA";
    private static readonly char[] Areas = new[] { 'A', 'B', 'C' };

    private const string AppSummary = (
        """
        Esta aplicación se encarga de calcular el bono navideño que reciben los empleados de una empresa, mostrando además el monto obtenido por cada tipo de bono.
        Se contemplan los bonos por área y antigüedad, y el bono para regalos que se obtiene por la cantidad de hijos del empleado.
        """
    );

    public static void Main()
    {
        ConsoleUtils.Greeting(AppTitle, AppSummary);
        
        do
        {
            ConsoleUtils.ClearIfDefault();
            ConsoleUtils.Print("Ingresa tu información para poder calcular tu bono.");
            var area = ConsoleUtils.ReadOption("Selección de área", Areas);
            var seniorityMonths = ConsoleUtils.ReadInt("Ingresa la cantidad de meses que llevas en la empresa", Constraint.PositiveOrZero);
            var childrenNumber = ConsoleUtils.ReadInt("Ingresa la cantidad de hijos que tienes", Constraint.PositiveOrZero);
            
            var bonus = GetBonus(area, seniorityMonths);
            var giftBonus = GetGiftBonus(childrenNumber);
            var total = bonus + giftBonus;
            ConsoleUtils.ClearIfDefault();
            ConsoleUtils.Print(
                $"""
                RESUMEN DE PAGO DE BONOS
                Bono por area / antigüedad: ${bonus}
                Bono para regalos:          ${giftBonus}
                Total:                      ${total}
                """
            );
        } while (!ConsoleUtils.Confirm("¿Deseas salir de la aplicación?"));

        ConsoleUtils.Farewell("Bye UwU");
    }

    private static double GetBonus(char area, int seniorityMonths) => (area, seniorityMonths) switch
    {
        ('A', < 24) => 5,
        ('A', >= 24) => 8,
        ('B', < 36) => 9,
        ('B', >= 36) => 12,
        ('C', < 60) => 14,
        ('C', >= 60) => 17,
        _ => 0
    } * MinSalary;

    private static double GetGiftBonus(int childrenNumber) => childrenNumber * GiftBonusPerChild;
}