using System;
using System.Windows.Forms;

public class MushroomForm : Form
{
    Label lblQuestion = new Label();

    int step = 1;          
    bool forest, convex;   

    public MushroomForm()
    {
        Text = "Mushroom";
        ClientSize = new System.Drawing.Size(360, 220);
        StartPosition = FormStartPosition.CenterScreen;

        Label info = new Label
        {
            Text = "Think of one of the six mushrooms, then answer honestly.",
            Left = 20,
            Top = 15,
            Width = 320,
            Height = 35
        };

        lblQuestion.SetBounds(20, 65, 320, 30);
        lblQuestion.Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold);
        lblQuestion.Text = "Does your mushroom grow in a forest?";

        Button btnYes = new Button { Text = "Yes", Left = 60, Top = 105, Width = 100, Height = 32 };
        Button btnNo = new Button { Text = "No", Left = 200, Top = 105, Width = 100, Height = 32 };
        btnYes.Click += (s, e) => Answer(true);
        btnNo.Click += (s, e) => Answer(false);

        Button btnBack = new Button { Text = "Back", Left = 60, Top = 165, Width = 100, Height = 30 };
        Button btnLogout = new Button { Text = "Logout", Left = 200, Top = 165, Width = 100, Height = 30 };
        btnBack.Click += (s, e) => { new ChooseForm().Show(); Close(); };
        btnLogout.Click += (s, e) => { Program.Login.Show(); Close(); };

        Controls.AddRange(new Control[] { info, lblQuestion, btnYes, btnNo, btnBack, btnLogout });

        FormClosed += (s, e) =>
        {
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        };
    }

    void Answer(bool yes)
    {
        if (step == 1)                          
        {
            forest = yes;
            step = 2;
            lblQuestion.Text = "Does your mushroom have a convex cup?";
        }
        else if (step == 2)                     
        {
            convex = yes;

            if (!forest)                       
            {
                if (convex) Finish("Agaric Jaunissant");
                else Finish("Coprin chevelu");
            }
            else
            {
                step = 3;
                if (convex) lblQuestion.Text = "Does your mushroom have a ring?";
                else lblQuestion.Text = "Does your mushroom have gills?";
            }
        }
        else                                    
        {
            if (convex)
            {
                if (yes) Finish("Amanite tue-mouche");
                else Finish("Pied bleu");
            }
            else
            {
                if (yes) Finish("Girolle");
                else Finish("Cepe de Bordeaux");
            }
        }
    }

    void Finish(string name)
    {
        MessageBox.Show("Your mushroom is: " + name);

        // Start again for the next game
        step = 1;
        lblQuestion.Text = "Does your mushroom grow in a forest?";
    }
}