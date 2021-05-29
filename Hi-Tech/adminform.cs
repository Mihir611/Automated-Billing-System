using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class adminform : Form
    {
        bool hided=true;
        bool hided1=true;
        bool hided2=true;
        bool hided3 = true;
        public adminform()
        {
            InitializeComponent();
         
        }
    private void button1_Click(object sender, EventArgs e)
        {
            DialogResult m1 = MessageBox.Show("Do u want to close the company???", "EXIT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(m1==DialogResult.OK )
            {
                DialogResult m2 = MessageBox.Show("Do you want to take the backup of the company??", "Backup Now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(m2==DialogResult.Yes )
                {
                    bkup bk1 = new bkup();
                    bk1.Show();
                    Close();
                }
                if (m2 == DialogResult.No)
                {
                    timer6.Start();
                }
            }
            if(m1==DialogResult.Cancel )
            {
                MessageBox.Show("User pressed cancel process stopped....");
            }
        }
    private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            this.panel7.BackColor = ColorTranslator.FromHtml("lime");
            this.panel8.BackColor = ColorTranslator.FromHtml("Black");
            this.panel9.BackColor = ColorTranslator.FromHtml("Black");
            this.panel10.BackColor = ColorTranslator.FromHtml("Black");
            this.panel35.BackColor = ColorTranslator.FromHtml("Black");
            this.panel45.BackColor = ColorTranslator.FromHtml("Black");
            this.panel44.BackColor = ColorTranslator.FromHtml("Black");

        }
        private void adminform_Load(object sender, EventArgs e)
        {
            button14.Visible = false;
            adminmain1.BringToFront();
            button10.Visible = false;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel18.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel24.Visible = false;
            panel19.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Qty from Stock where QtY<=Re_Order", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
            DialogResult check=MessageBox .Show ( "There are few items which are going negative in Stock please re-order it to mintain the stock","ORDER IT",MessageBoxButtons.OKCancel ,MessageBoxIcon.Warning );
                if(check==DialogResult.OK )
                {
                    place_order1.BringToFront();
                }
            }
            con.Close();
            label1.Text = DateTime.Now.ToLongTimeString();
            timer5.Start();
         
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (hided == true)
            {
                panel3.Height = panel3.Height + 20;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                button38.Visible = false;
                button6.Visible = false;
                panel44.Visible = false;
                panel45.Visible = false;
                pictureBox2.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox3.Visible = false;

                if (panel3.Height >= 300)
                {
                    timer1.Stop();
                    hided = false;
                    this.Refresh();
                }
            }
            else if (hided == false)
            {
                panel3.Height = panel3.Height - 20;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                button38.Visible = true;
                button6.Visible = true;
                panel44.Visible = true;
                panel45.Visible = true;
                pictureBox2.Visible = true;
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                pictureBox3.Visible = true;
                if (panel3.Height <= 62)
                {
                   
                    timer1.Stop();
                    hided = true;
                    this.Refresh();
                }
            }

        }
         private void timer2_Tick(object sender, EventArgs e)
        {
            if (hided1 == true)
            {
                panel4.Height = panel4.Height + 20;
                panel5.Visible = false;
                panel6.Visible = false;
                button38.Visible = false;
                button6.Visible = false;
                panel44.Visible = false;
                panel45.Visible = false;
                button2.Enabled = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox3.Visible = false;
                if (panel4.Height >= 300)
                {
                    timer2.Stop();
                    hided1 = false;
                    this.Refresh();
                }
            }
            else if (hided1 == false)
            {
                panel4.Height = panel4.Height - 20;
                button2.Enabled = true;
                panel5.Visible = true;
                panel6.Visible = true;
                button38.Visible = true;
                button6.Visible = true;
                panel44.Visible = true;
                panel45.Visible = true;
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                pictureBox3.Visible = true;
                if (panel4.Height <= 55)
                {
                    timer2.Stop();
                    hided1 = true;
                    this.Refresh();
                }
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (hided2 == true)
            {
                panel5.Height = panel5.Height + 20;
                panel35.Visible = false;
                button39.Visible = false;
                panel44.Visible = false;
                button38.Visible = false; 
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                if (panel5.Height >= 160)
                {
                    timer3.Stop();
                    hided2 = false;
                    this.Refresh();
                }
            }
            else if (hided2 == false)
            {
                panel5.Height = panel5.Height - 20;
                panel35.Visible = true;
                button39.Visible = true;
                panel44.Visible = true;
                button38.Visible = true;
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
                if (panel5.Height <= 62)
                {
                    timer3.Stop();
                    hided2 = true;
                    this.Refresh();
                }
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (hided3 == true)
            {

                panel6.Height = panel6.Height + 20;

                if (panel6.Height >= 250)
                {
                    timer4.Stop();
                    hided3 = false;
                    this.Refresh();
                }
            }
            else if (hided3 == false)
            {
                panel6.Height = panel6.Height - 20;
                if (panel6.Height <= 62)
                {
                    timer4.Stop();
                    hided3 = true;
                    this.Refresh();
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            timer2.Start();
            this.panel7.BackColor = ColorTranslator.FromHtml("Black");
            this.panel8.BackColor = ColorTranslator.FromHtml("lime");
            this.panel9.BackColor = ColorTranslator.FromHtml("Black");
            this.panel10.BackColor = ColorTranslator.FromHtml("Black");
            this.panel35.BackColor = ColorTranslator.FromHtml("Black");
            this.panel45.BackColor = ColorTranslator.FromHtml("Black");
            this.panel44.BackColor = ColorTranslator.FromHtml("Black");
        }
        private void button13_Click(object sender, EventArgs e)
        {
            timer3.Start();
            
            this.panel7.BackColor = ColorTranslator.FromHtml("Black");
            this.panel8.BackColor = ColorTranslator.FromHtml("Black");
            this.panel9.BackColor = ColorTranslator.FromHtml("lime");
            this.panel10.BackColor = ColorTranslator.FromHtml("Black");
            this.panel35.BackColor = ColorTranslator.FromHtml("Black");
            this.panel45.BackColor = ColorTranslator.FromHtml("Black");
            this.panel44.BackColor = ColorTranslator.FromHtml("Black");
        }
        private void button17_Click(object sender, EventArgs e)
        {
            timer4.Start();
            this.panel7.BackColor = ColorTranslator.FromHtml("Black");
            this.panel8.BackColor = ColorTranslator.FromHtml("Black");
            this.panel9.BackColor = ColorTranslator.FromHtml("Black");
            this.panel10.BackColor = ColorTranslator.FromHtml("lime");
            this.panel35.BackColor = ColorTranslator.FromHtml("Black");
            this.panel44.BackColor = ColorTranslator.FromHtml("Black");
            this.panel45.BackColor = ColorTranslator.FromHtml("Black");
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            //sendmailbutton
            sendmail1.CLEAR();
            sendmail1.BringToFront();
            editcompany1.clear();
            button10.Visible = false;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel18.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel19.Visible = false;
            panel29.Visible = false;
            panel24.Visible = false;
            panel30.Visible = false;
        }
         private void button19_Click(object sender, EventArgs e)
        {
            //editcompany
            editcompany1.BringToFront();
            button10.Visible = false;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel18.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel19.Visible = false;
            panel24.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
            }
//supin
        private void button10_Click(object sender, EventArgs e)
        {//supin
            purchasebill PO = new purchasebill();
            PO.Show();
            purchasebill1.BringToFront();
            button14.Visible = false;
            panel14.Visible = false;
           
            this.panel13.BackColor = ColorTranslator.FromHtml("lime");
            this.panel14.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel15.BackColor = ColorTranslator.FromHtml("DimGray");
        }
         private void button14_Click(object sender, EventArgs e)
        {//supin
            //supinmodify1.BringToFront();
            //supinmodify YU = new supinmodify();
            //YU.Show();
            //this.panel14.BackColor = ColorTranslator.FromHtml("lime");
            //this.panel13.BackColor = ColorTranslator.FromHtml("DimGray");
            // this.panel15.BackColor = ColorTranslator.FromHtml("DimGray");
         }
        private void button22_Click(object sender, EventArgs e)
        {//supin
            supinlist LI = new supinlist();
            LI.Show();
            supinlist1.BringToFront();
            button14.Visible = false;
            panel14.Visible = false;
          
            this.panel15.BackColor = ColorTranslator.FromHtml("lime");
            this.panel13.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel14.BackColor = ColorTranslator.FromHtml("DimGray");
        }
       //supin
        private void button4_Click(object sender, EventArgs e)
        {
            button14.Visible = false;
            panel14.Visible = false;
            button10.Visible = true;
          
            button22.Visible = true;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = true;
           
            panel15.Visible = true;
            panel16.Visible = false;
            panel17.Visible = false;
            panel18.Visible = false;
            purchasebill1.BringToFront();
            this.panel14.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel15.BackColor = ColorTranslator.FromHtml("DimGray");
            panel19.Visible = false;
            panel24.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
        }
//supout
        private void button3_Click(object sender, EventArgs e)
        {
            salesbillopener1.BringToFront();
            single_list1.CLEANV();
            button10.Visible = false ;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = true;
            button24.Visible = true;
            button25.Visible = true;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel16.Visible = true;
            panel17.Visible = true;
            panel18.Visible = true;
           this.panel17.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel16.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel18.BackColor = ColorTranslator.FromHtml("lime");
            panel19.Visible = false;
            panel24.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
        }
        private void button25_Click(object sender, EventArgs e)
        {
            single_list trt = new single_list();
            trt.Show();
            salesbillopener1.BringToFront();
            single_list1.CLEANV();
           
            this.panel18.BackColor = ColorTranslator.FromHtml("lime");
            this.panel17.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel16.BackColor = ColorTranslator.FromHtml("DimGray");
        }
        private void button24_Click(object sender, EventArgs e)
        {
            single_list GFH = new single_list();
            GFH.Show();
            single_list1.BringToFront();
           
            single_list1.CLEANV();
            this.panel17.BackColor = ColorTranslator.FromHtml("lime");
            this.panel18.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel16.BackColor = ColorTranslator.FromHtml("DimGray");
        }
         private void button23_Click(object sender, EventArgs e)
        {
            supoutlistalllitem yt = new supoutlistalllitem();
            yt.Show();
            supoutlistalllitem1.BringToFront();
            single_list1.CLEANV();
           
            this.panel16.BackColor = ColorTranslator.FromHtml("lime");
            this.panel17.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel18.BackColor = ColorTranslator.FromHtml("DimGray");
        }
        //STOCK
        private void button5_Click(object sender, EventArgs e)
        {
            stock DF = new stock();
            DF.Show();
            stock1.restartt();
          
            stock1.BringToFront();
            button10.Visible = false;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel18.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel19.Visible = false;
            panel24.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
        }
        //ITEMMASTER
        private void button8_Click(object sender, EventArgs e)
        {
            panel19.Visible = true;
            panel24.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
            itemmasteradd1.BringToFront();
            itemmasteradd1.cleer();
            itemmodify1.cleane();
            itemmasterlist1.moclean();
            itemmasterdel1.delcleaner();
            this.panel20.BackColor = ColorTranslator.FromHtml("lime");
            this.panel21.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel22.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel23.BackColor = ColorTranslator.FromHtml("DimGray");
         }
        //ITMADD
        private void button26_Click(object sender, EventArgs e)
        {
            Itemmasteradd gfgf = new Itemmasteradd();
            gfgf.Show();
            itemmasteradd1.BringToFront();
            itemmasteradd1.cleer();
            itemmodify1.cleane();
            itemmasterlist1.moclean();
            itemmasterdel1.delcleaner();
            this.panel20.BackColor = ColorTranslator.FromHtml("lime");
            this.panel21.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel22.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel23.BackColor = ColorTranslator.FromHtml("DimGray");
        }
        //ITLIST
        private void button27_Click(object sender, EventArgs e)
        {
            itemmasterlist Bt = new itemmasterlist();
            Bt.Show();
            itemmasterlist1.BringToFront();
          
            itemmodify1.cleane();
            itemmasteradd1.cleer();
            itemmasterlist1.moclean();
            itemmasterdel1.delcleaner();
            this.panel21.BackColor = ColorTranslator.FromHtml("lime");
            this.panel20.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel22.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel23.BackColor = ColorTranslator.FromHtml("DimGray");
        }
        //ITMODIFY
        private void button28_Click(object sender, EventArgs e)
        {
            ITEMMODIFY FT = new ITEMMODIFY();
            FT.Show();
            itemmodify1.BringToFront();
            itemmodify1.cleane();
            itemmasteradd1.cleer();
            itemmasterlist1.moclean();
            itemmasterdel1.delcleaner();
            this.panel22.BackColor = ColorTranslator.FromHtml("lime");
            this.panel21.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel20.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel23.BackColor = ColorTranslator.FromHtml("DimGray");
        }
        //ITDEL
        private void button29_Click(object sender, EventArgs e)
        {
            itemmasterdel UF = new itemmasterdel();
            UF.Show();
            itemmasterdel1.BringToFront();
            itemmasterdel1.delcleaner();
           
            itemmodify1.cleane();
            itemmasteradd1.cleer();
            itemmasterlist1.moclean();
            this.panel23.BackColor = ColorTranslator.FromHtml("lime");
            this.panel21.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel22.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel20.BackColor = ColorTranslator.FromHtml("DimGray");
        }
        //ACCOUNT MASTER
        private void button7_Click(object sender, EventArgs e)
        {
            addacmaster1.BringToFront();
            addacmaster1.ADCLEAR();
            acmodify1.clenn();
            panel24.Visible = true;
            this.panel28.BackColor = ColorTranslator.FromHtml("lime");
            this.panel27.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel26.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel25.BackColor = ColorTranslator.FromHtml("DimGray");
            button10.Visible = false;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel18.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel19.Visible = false;
            panel30.Visible = false;
            panel29.Visible = false;
        }
        private void button33_Click(object sender, EventArgs e)
        {
            
            addacmaster1.BringToFront();
            acmodify1.clenn();
            addacmaster1.ADCLEAR();
            this.panel28.BackColor = ColorTranslator.FromHtml("lime");
            this.panel27.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel26.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel25.BackColor = ColorTranslator.FromHtml("DimGray");
        }
        private void button32_Click(object sender, EventArgs e)
        {
            acmasterlist D = new acmasterlist();
            D.Show();
            acmasterlist1.BringToFront();
           
            addacmaster1.ADCLEAR();
            acmodify1.clenn();
            this.panel27.BackColor = ColorTranslator.FromHtml("lime");
            this.panel28.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel26.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel25.BackColor = ColorTranslator.FromHtml("DimGray");
        }
        private void button31_Click(object sender, EventArgs e)
        {
            ACMODIFY TT = new ACMODIFY();
            TT.Show();
            acmodify1.BringToFront();
          
            acmodify1.clenn();
            addacmaster1.ADCLEAR();
            this.panel26.BackColor = ColorTranslator.FromHtml("lime");
            this.panel27.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel28.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel25.BackColor = ColorTranslator.FromHtml("DimGray");
        }
         private void button30_Click(object sender, EventArgs e)
        {
            acmasterdel LI = new acmasterdel();
            LI.Show();
            acmasterdel1.BringToFront();
           
            acmodify1.clenn();
            addacmaster1.ADCLEAR();
            this.panel25.BackColor = ColorTranslator.FromHtml("lime");
            this.panel27.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel26.BackColor = ColorTranslator.FromHtml("DimGray");
            this.panel28.BackColor = ColorTranslator.FromHtml("DimGray");
        }
        //RETURNS  //puchase retrun
        private void button6_Click(object sender, EventArgs e)
        {
            panel29.Visible = false;
            // this.panel33.BackColor = ColorTranslator.FromHtml("lime");
            // this.panel32.BackColor = ColorTranslator.FromHtml("DimGray");
            purchase_return1.BringToFront();
            button10.Visible = false;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel18.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel19.Visible = false;
            panel24.Visible = false;
            panel30.Visible = false;
            this.panel45.BackColor = ColorTranslator.FromHtml("lime");
            this.panel44.BackColor = ColorTranslator.FromHtml("Black");
            this.panel10.BackColor = ColorTranslator.FromHtml("Black");
            this.panel35.BackColor = ColorTranslator.FromHtml("Black");
            this.panel7.BackColor = ColorTranslator.FromHtml("Black");
            this.panel8.BackColor = ColorTranslator.FromHtml("Black");
            this.panel9.BackColor = ColorTranslator.FromHtml("Black");
        }
     //EMP
        private void button20_Click(object sender, EventArgs e)
        {
            panel30.Visible = true;
            panel30.BringToFront();
            empdetailadd1.BringToFront();
            empdetailadd1.EMPADDCLEAN();
            empdetailmodify1.fr();
            this.panel34.BackColor = ColorTranslator.FromHtml("lime");
            this.panel31.BackColor = ColorTranslator.FromHtml("DimGray");
            button10.Visible = false;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel18.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel19.Visible = false;
            panel24.Visible = false;
            panel29.Visible = false;
        }
         private void button35_Click(object sender, EventArgs e)
        {
            empdetailadd1.BringToFront();
            empdetailadd1.EMPADDCLEAN();
            this.panel34.BackColor = ColorTranslator.FromHtml("lime");
            this.panel31.BackColor = ColorTranslator.FromHtml("DimGray");
         }
        private void button34_Click(object sender, EventArgs e)
        {
            empdetailmodify GG = new empdetailmodify();
            GG.Show();
            empdetailmodify1.BringToFront();
            empdetailmodify1.fr();
            this.panel31.BackColor = ColorTranslator.FromHtml("lime");
            this.panel34.BackColor = ColorTranslator.FromHtml("DimGray");
        }
        //PLACE ORDER
        private void button21_Click(object sender, EventArgs e)
        {
            place_order UID = new place_order();
            UID.Show();
            place_order1.BringToFront();
          
            button10.Visible = false;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel18.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel19.Visible = false;
            panel24.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
        }
        private void button39_Click(object sender, EventArgs e)
        {
            generate_QR_BAR_code1.BringToFront();
            button10.Visible = false;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel18.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel19.Visible = false;
            panel24.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
            this.panel35.BackColor = ColorTranslator.FromHtml("lime");
            this.panel7.BackColor = ColorTranslator.FromHtml("Black");
            this.panel8.BackColor = ColorTranslator.FromHtml("Black");
            this.panel9.BackColor = ColorTranslator.FromHtml("Black");
            this.panel10.BackColor = ColorTranslator.FromHtml("Black");
            this.panel45.BackColor = ColorTranslator.FromHtml("Black");
            this.panel44.BackColor = ColorTranslator.FromHtml("Black");
        }
        private void button40_Click(object sender, EventArgs e)
        {
            salarycalculation ttt = new salarycalculation();
            ttt.Show();
            salarycalculation1.BringToFront();
            button10.Visible = false;
            button14.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel18.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel19.Visible = false;
            panel24.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0.0)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                timer2.Stop();
                this.Close();
            }
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.BackColor = ColorTranslator.FromHtml("RED");
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.BackColor = ColorTranslator.FromHtml("Transparent");
        }
        private void button38_Click(object sender, EventArgs e)
        {
            ATTENDANCE st = new ATTENDANCE();
            st.Show();
            this.panel44.BackColor = ColorTranslator.FromHtml("lime");
            this.panel45.BackColor = ColorTranslator.FromHtml("Black");
            this.panel10.BackColor = ColorTranslator.FromHtml("Black");
            this.panel35.BackColor = ColorTranslator.FromHtml("Black");
            this.panel7.BackColor = ColorTranslator.FromHtml("Black");
            this.panel8.BackColor = ColorTranslator.FromHtml("Black");
            this.panel9.BackColor = ColorTranslator.FromHtml("Black");

        }

        private void button16_Click(object sender, EventArgs e)
        {
            salaryreport SE = new salaryreport();
            SE.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            STOCKOREPORT OI = new STOCKOREPORT();
            OI.Show();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            purorderreportt DT = new purorderreportt();
            DT.Show();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            salesrep1.BringToFront();
        }

        private void salesrep1_Load(object sender, EventArgs e)
        {

        }

        private void button43_Click(object sender, EventArgs e)
        {
            purchaserrreport1.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            adminmain1.BringToFront();
        }

        private void adminmain1_Load(object sender, EventArgs e)
        {
          
        }
        //backup
        private void button12_Click(object sender, EventArgs e)
        {
            bkup b = new bkup();
            b.Show();
        }
        //restore
        private void button11_Click(object sender, EventArgs e)
        {
            rest r = new rest();
            r.Show();
        }
    }
}