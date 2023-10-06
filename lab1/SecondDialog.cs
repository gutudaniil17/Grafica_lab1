using System.Globalization;

namespace lab1;

using System;

class SecondDialog : Form
{
    private const string fileOfMyFoo = "C:\\Users\\Gutu\\RiderProjects\\Grafica_lab1\\lab1\\FileOfMyFoo.txt";
    private string[] linesFromFile = null;

    public SecondDialog()
    {
        Text = "Dialog based application";

        StartPosition = FormStartPosition.Manual;
        Location = new System.Drawing.Point(10, 10);
        Size = new System.Drawing.Size(1300, 700);

        Closed += new System.EventHandler(MainDialog_Closed);

        MouseDoubleClick +=
            new MouseEventHandler(MyForm_MouseDoubleClick);
        linesFromFile = MyService.ReadLinesFromFile(fileOfMyFoo);
    }

    private void MainDialog_Closed(object sender, EventArgs e)
    {
        Dispose();
    }


    private void MyForm_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        mydraw();
    }

    private void mydraw()
    {
        Graphics g = Graphics.FromHwnd(this.Handle);

        // Cream culorile
        Color MYTGCOLOR = Color.FromArgb(255, 0, 0); //rosu
        Color STTGCOLOR = Color.FromArgb(0, 255, 0); //verde

        int cpx = (int)(this.ClientRectangle.Width / 2);
        int cpy = (int)(this.ClientRectangle.Height / 2);

        Pen AxPen = new Pen(Color.Blue, 1);
        g.DrawLine(AxPen, 0, cpy, this.ClientRectangle.Width, cpy);
        g.DrawLine(AxPen, cpx, 0, cpx, this.ClientRectangle.Height);


        double a, b;

        a = -1;
        b = 1;

        double precision = 0.005;


        double scalex = this.ClientRectangle.Width / (b - a) * 0.8;
        double scaley = this.ClientRectangle.Height / 2.0 * 0.8;


        int graphsegments = 400;

        double x1, x2, y1, y2, step;
        int ix1, ix2, iy1, iy2;

        step = (b - a) / (double)graphsegments;

        x2 = a;
        y2 = myFunc(x2, precision);

        ix2 = cpx + (int)(x2 * scalex);
        iy2 = cpy - (int)(y2 * scaley);

        // Cream penite
        Pen RedPen1 = new Pen(Color.Red, 1);
        Pen PurplePen = new Pen(Color.Purple, 1);
        Pen StPen = new Pen(STTGCOLOR, 1);

        // Cream pensule
        SolidBrush GreenBrush = new SolidBrush(Color.Green);
        SolidBrush MyBrush = new SolidBrush(MYTGCOLOR);
        SolidBrush StBrush = new SolidBrush(STTGCOLOR);


        int k = 0;
        while (x2 < b)
        {
            string line = linesFromFile[k];
            k++;
            string[] splited = line.Split("\t");
            x1 = x2;
            y1 = y2;
            ix1 = ix2;
            iy1 = iy2;
            x2 += step;

            y2 = myFunc(x2, precision);
            ix2 = cpx + (int)(x2 * scalex);
            iy2 = cpy - (int)(y2 * scaley);

            g.DrawLine(RedPen1, ix1, iy1, ix2, iy2);

            iy1 = cpy - (int)(Convert.ToDouble(splited[1]) * scaley);
            
            g.DrawLine(StPen, ix1 + 0, iy1 - 2, ix1 + 0, iy1 + 2);
            g.DrawLine(StPen, ix1 + 2, iy1 + 2, ix1 + 2, iy1 + 2);
        }
    }

    double myFunc(double x, double eps)
    {
        int k = 1;
        double sum = -1;
        double t = 1;
        do
        {
            sum += t;
            t = Math.Pow(x, k) / k;
            k++;
        } while (Math.Abs(t) >= eps);

        string toFile = x + "\t" + -sum;
        return -sum;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        mydraw();
    }
}