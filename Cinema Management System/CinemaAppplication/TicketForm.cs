using CinamaLib1;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CinemaAppplication
{
    public partial class TicketForm : Form
    {
        public static TicketForm ticketForm;
        public TicketForm()
        {
            InitializeComponent();
            creatSeats();
            InitSeats();
            ticketForm = this;

        }

        // DemoData deklarieren
        DemoData DemoData = new DemoData();
        CinemaModelContainer context = new CinemaModelContainer();



        // Creat Seats and save/update changes in SQL
        private void creatSeats()
        {
            SeatBuilder setseat = new SeatBuilder().setSeat();

            if (context.Seats.Count() == 0)
            {
                try
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        context.Seats.AddRange(setseat.Seats);
                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }


        // Show Init Seats 
        private void InitSeats()
        {
            foreach (Seat var in context.Seats.ToArray())
            {
                int row = Int32.Parse(var.SeatNum.Split('-')[0]);
                int col = Int32.Parse(var.SeatNum.Split('-')[1]);

                Label lbl = new Label();
                lbl.BackColor = Color.LimeGreen;
                lbl.Location = new Point(-50 + col * 90, 40 + row * 50);
                lbl.Font = new Font("Courier New", 11);
                lbl.Name = var.SeatNum;
                lbl.Text = var.SeatNum;
                lbl.Size = new Size(50, 30);
                lbl.TabIndex = 0;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Click += new System.EventHandler(this.lbl_Click);
                groupBox2.Controls.Add(lbl);

            };

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadSchedule();
        }


        // loading Schedule DemoData
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Empty Database");

            try
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {

                    context.Tickets.RemoveRange(context.Tickets.ToArray());
                    context.SaveChanges();

                    context.ScheduleItems.RemoveRange(context.ScheduleItems.ToArray());
                    context.SaveChanges();

                    context.Movies.RemoveRange(context.Movies.ToArray());
                    context.SaveChanges();

                    dbContextTransaction.Commit();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            Console.WriteLine("Fill Database");

            try
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    context.ScheduleItems.AddRange(DemoData.ScheduleItems);
                    context.SaveChanges();

                    dbContextTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // show Demo Day in combo box
            loadSchedule();
        }


        public void loadSchedule()
        {
            try
            {
                var datetime =
                  (from par in context.ScheduleItems
                   orderby par.Time
                   select par.Time.Year.ToString() + " -" + par.Time.Month.ToString() + " -" + par.Time.Day.ToString())
                   .Distinct();

                this.comboBox1.DataSource = datetime.ToArray();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            updateTreeView();
        }




        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        // show the movie information and current seat status(soldtickts) after selecting a scheduleitem 
        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (this.treeView1.SelectedNode.Level == 1)
                {
                    DateTime time = DateTime.Parse(this.comboBox1.Text + " " + this.treeView1.SelectedNode.Text);

                    // find the selected scheduleitem in SQL
                    var item =
                            (from par in context.ScheduleItems
                             where par.Time.Equals(time)
                             select par);

                    // show selected movie information
                    {
                        this.lblActor.Text = item.ToArray()[0].MovieItem.Name;
                        this.lblDirector.Text = item.ToArray()[0].MovieItem.Director;
                        this.lblName.Text = item.ToArray()[0].MovieItem.Name;
                        this.lblFullPrice.Text = item.ToArray()[0].MovieItem.FullPrice.ToString();
                        this.lblDate.Text = item.ToArray()[0].Time.Year.ToString() + " -"
                                          + item.ToArray()[0].Time.Month.ToString() + " -"
                                          + item.ToArray()[0].Time.Day.ToString();
                        this.lblTime.Text = item.ToArray()[0].Time.TimeOfDay.ToString();
                        this.lblType.Text = item.ToArray()[0].MovieItem.MovieType;

                    }

                    //reset all seats color
                    clearSeatColor();
                    //set screen color
                    this.lblScreen.BackColor = Color.DimGray;

                    //find tickets with selected scheduleitem
                    var sqlTickets =
                            (from par in context.Tickets
                             where par.ScheduleItem.Time.Equals(time)
                             select par);

                    foreach (Ticket soldticket in sqlTickets)
                    {
                        string var = soldticket.SeatItem.SeatNum;
                        // change color for sold seats in orangered
                        this.Controls.Find(var, true)[0].BackColor = Color.OrangeRed;

                    }
                }

                else if (this.treeView1.SelectedNode.Level == 0)
                {
                    // find the selected movie in SQL
                    var item =
                            (from par in context.Movies
                             where par.Name.Equals(this.treeView1.SelectedNode.Text)
                             select par);
                    {
                        this.lblActor.Text = item.ToArray()[0].Name;
                        this.lblDirector.Text = item.ToArray()[0].Director;
                        this.lblName.Text = item.ToArray()[0].Name;
                        this.lblFullPrice.Text = item.ToArray()[0].FullPrice.ToString();
                        this.lblType.Text = item.ToArray()[0].MovieType;
                        this.lblTime.Text = "Scheduel not yet selected.";
                        this.lblDate.Text = "Scheduel not yet selected.";
                    }

                    foreach (Label lbltmp in this.groupBox2.Controls.OfType<Label>())
                    {
                        lbltmp.BackColor = Color.LimeGreen;
                    }

                    this.lblScreen.BackColor = Color.DimGray;
                }

                this.rdoNormal.Checked = true;
                this.lblPrice.Text = this.lblFullPrice.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }



        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void lblFullPrice_Click(object sender, EventArgs e)
        {

        }


        /*
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cinemaDBDataSet.ScheduleItems' table. You can move, or remove it, as needed.
            this.scheduleItemsTableAdapter.Fill(this.cinemaDBDataSet.ScheduleItems);

        }
        */



        // select schedule in ComboBox and then show scheduleitems in TreeView
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            updateTreeView();
        }



        // show scheduleitems in TreeView
        private void updateTreeView()
        {
            try
            {
                DateTime date1 = DateTime.Parse(this.comboBox1.Text);
                DateTime date2 = date1.AddDays(1);

                var vari =
                    (from par in context.ScheduleItems
                     where par.Time >= date1 && par.Time < date2
                     orderby par.MovieItem.Name
                     select par);

                this.treeView1.Nodes.Clear();
                TreeNode root = null;

                foreach (ScheduleItem var in vari.ToArray())
                {
                    if (root == null || root.Text != var.MovieItem.Name)
                    {
                        // show node level 0
                        root = new TreeNode(var.MovieItem.Name);
                        this.treeView1.Nodes.Add(root);
                    }
                    // show nod level 1
                    root.Nodes.Add(var.Time.TimeOfDay.ToString());

                };

                this.treeView1.Sort();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }



        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            updateTreeView();

        }


        Label SelectSeat = new Label();
        private void lbl_Click(object sender, EventArgs e)
        {
            try { DateTime tmp = DateTime.Parse(this.lblTime.Text); }
            catch
            {
                MessageBox.Show("Pleae select a movie and time!");
                return;
            }

            if (this.lblPrice.Text == "")
            {
                MessageBox.Show("Pleae select a ticket type!");
                return;
            }

            SelectSeat = sender as Label;
            if (SelectSeat.BackColor == Color.OrangeRed)
            {
                MessageBox.Show("already saled");
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("select this seat?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {

                    //find select scheduleitem
                    DateTime time = DateTime.Parse(this.comboBox1.Text + " " + this.treeView1.SelectedNode.Text);

                    var item =
                            (from par in context.ScheduleItems
                             where par.Time.Equals(time)
                             select par);

                    var sqlSeat =
                            (from par in context.Seats
                             where par.SeatNum.Equals(SelectSeat.Text)
                             select par);

                    string type = string.Empty;
                    type = rdoNormal.Checked ? "Normal" : rdoStudent.Checked ? "Student Ticket" : "Free Ticket";

                    // creat soldticket
                    Ticket ticket = new Ticket();
                    ticket.ScheduleItem = item.ToArray()[0];
                    ticket.SeatItem = sqlSeat.ToArray()[0];
                    ticket.TicketType = type;
                    ticket.Price = Double.Parse(this.lblPrice.Text);

                    //save sold tickets and save in SQL
                    try
                    {
                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {
                            context.Tickets.Add(ticket);
                            context.SaveChanges();

                            dbContextTransaction.Commit();
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    //update seat color after sold
                    this.Controls.Find(ticket.SeatItem.SeatNum, true)[0].BackColor = Color.OrangeRed;

                }
            }

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblScreen_Click(object sender, EventArgs e)
        {

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void rdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbDiscount.Enabled = false;
            this.txtCoupon.Enabled = false;
            this.lblPrice.Text = lblFullPrice.Text;
        }


        private void rdoStudent_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.lblFullPrice.Text != "")
            {
                this.cmbDiscount.Enabled = true;
                this.txtCoupon.Enabled = false;
                if (this.cmbDiscount.Text != "")
                {
                    this.lblPrice.Text = (Double.Parse(this.lblFullPrice.Text) * Double.Parse(this.cmbDiscount.Text) / 10).ToString();
                }
                else
                {
                    this.lblPrice.Text = this.lblFullPrice.Text;
                }

            }


        }

        private void rdoFree_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCoupon.Enabled = true;
            this.cmbDiscount.Enabled = false;
            this.lblPrice.Text = "0";
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }



        // show ticket information in return system
        private void tabControl1_Click(object sender, EventArgs e)
        {
        }

        private void txtBoxReturn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.txtBoxReturn.Text != "")
            {
                var tmp = Convert.ToInt32(this.txtBoxReturn.Text);

                var returnTicket =
                                (from par in context.Tickets
                                 where par.Id.Equals(tmp)
                                 select par);

                if (returnTicket.Count() > 0)
                {
                    try
                    {

                        // show ticket information;
                        this.lblNameReturn.Text = returnTicket.ToArray()[0].ScheduleItem.MovieItem.Name;
                        this.lblDateReturn.Text = returnTicket.ToArray()[0].ScheduleItem.Time.Year.ToString() + " -"
                                                  + returnTicket.ToArray()[0].ScheduleItem.Time.Month.ToString() + " -"
                                                  + returnTicket.ToArray()[0].ScheduleItem.Time.Day.ToString();
                        this.lblTimeReturn.Text = returnTicket.ToArray()[0].ScheduleItem.Time.TimeOfDay.ToString();
                        this.lblTypeReturn.Text = returnTicket.ToArray()[0].TicketType;
                        this.lblFullPriceReturn.Text = returnTicket.ToArray()[0].ScheduleItem.MovieItem.FullPrice.ToString();
                        this.lblPriceReturn.Text = returnTicket.ToArray()[0].Price.ToString();
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);

                    }
                }

                else
                {
                    MessageBox.Show("Ticket noch valid!");
                }

                e.Handled = true;
            }
        }




        // remove return-ticket in sql 
        private void buttonRuturn_Click(object sender, EventArgs e)
        {
            if (this.txtBoxReturn.Text != "")
            {
                var tmp = Convert.ToInt32(this.txtBoxReturn.Text);
                var returnTicket =
                                (from par in context.Tickets
                                 where par.Id.Equals(tmp)
                                 select par);

                if (returnTicket.Count() > 0 &&
                    DialogResult.OK == MessageBox.Show("return this seat?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    try
                    {
                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {

                            context.Tickets.RemoveRange(returnTicket.ToArray());
                            context.SaveChanges();

                            dbContextTransaction.Commit();
                        }

                        //MessageBox.Show("ticket returned.");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);

                    }

                }

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //InitSeats();
            clearSaleSystem();
        }

        private void clearSaleSystem()
        {
            clearSeatColor();
            clearMovieInfo();
            updateTreeView();

        }

        private void clearSeatColor()
        {
            foreach (Label lbltmp in this.groupBox2.Controls.OfType<Label>())
            {
                lbltmp.BackColor = Color.LimeGreen;
            }

            this.lblScreen.BackColor = Color.DimGray;
        }

        private void clearMovieInfo()
        {
            this.lblActor.Text = "";
            this.lblDirector.Text = "";
            this.lblName.Text = "";
            this.lblFullPrice.Text = "";
            this.lblDate.Text = "";
            this.lblTime.Text = "";
            this.lblType.Text = "";
            this.lblPrice.Text = "";

        }

        private void TicketForm_Load(object sender, EventArgs e)
        {
            loadSchedule();
        }

        private void txtBoxReturn_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
