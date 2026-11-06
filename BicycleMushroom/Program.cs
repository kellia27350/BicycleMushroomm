using System;
using System.Windows.Forms;

static class Program
{
    // We keep the Login form here so every other form can show it again
    public static LoginForm Login;

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Login = new LoginForm();
        Application.Run(Login);
    }
}