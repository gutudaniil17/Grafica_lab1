namespace lab1;

public class MainApp
{
    private const string fileOfMyFoo = "C:\\Users\\Gutu\\RiderProjects\\Grafica_lab1\\lab1\\FileOfMyFoo.txt";
    private const string fileOfAbsolute = "C:\\Users\\Gutu\\RiderProjects\\Grafica_lab1\\lab1\\FileToCheckAbsolute.txt";

    [STAThread]
    public static void Main()
    {
        // MyService.ClearFile(fileOfMyFoo);
        // MyService.ClearFile(fileOfAbsolute);
        // MainDialog mainDialog = new MainDialog();
        // mainDialog.ShowDialog();
        SecondDialog secondDialog = new SecondDialog();
        secondDialog.ShowDialog();
    }
}