namespace WinFormsApp3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            bool onlyInstance;

            Mutex mtx = new Mutex(true, "WinFormsApp3", out onlyInstance);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (onlyInstance)
            {
                Application.Run(new Form1());
        }
            else
                MessageBox.Show("Приложение уже запущено",  "Сообщение",   MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}