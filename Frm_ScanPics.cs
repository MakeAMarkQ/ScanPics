using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScanPics
{
    public partial class ScanPics : Form
    {
        private bool bLastMove = false;
        private bool bClose=false;
        private bool bOnWork = false;
        //private int iXkpl = 15;
        //private int iYkpl = 10;
        private int iXKoko = 80;
        private int iYKoko = 110;
        private int iXkpl = 0;
        //private ListBox LBox_Delete = new ListBox();
        private int iYkpl = 0;
        private int iEnd=0;
        private PictureBox PBx_pi = null;
        private int iStart = 0;
        //private Button[] PicButs;
        //private PictureBox[,] PicBoxs;
        private DirectoryInfo[] Hakemistot;
        private String strFile = "Latest.txt";
        private String strKohdeFile = "Kohde.txt";
        private String StrKohdePolku=String.Empty;
        private String strMainPath = String.Empty;
        //PictureBox PBx_pi = new PictureBox();

       public ScanPics()
        {
            InitializeComponent();
        }

        private void ScanPics_Load(object sender, EventArgs e)
        {
            if (File.Exists(strKohdeFile))
                StrKohdePolku = File.ReadAllText(strKohdeFile);
            if (File.Exists(strFile))
                strMainPath = File.ReadAllText(strFile);

        }
        private Form Look;
        private void PicBoxs_Click(object sender, EventArgs e)
        {
            //PictureBox thispic = (PictureBox)sender;
            //Form Lookclick = new Form();
            //Lookclick.Size = new Size(800, 800);
            //Lookclick.Location = new Point(1, 1);
            //Lookclick.StartPosition = FormStartPosition.Manual;
            //PictureBox lookpic = new PictureBox();
            //lookpic.Size = new Size(790, 750);
            //lookpic.SizeMode = PictureBoxSizeMode.Zoom;
            //lookpic.Top = 1;
            //lookpic.Left = 1;
            //lookpic.Image = thispic.Image;
            //Lookclick.Controls.Add(lookpic);
            //Lookclick.Show();

        }
        private void PicButs_MouseClick(object sender, MouseEventArgs e)
        {
            bOnWork = true;
            Button btn = (Button)sender;
            String Name = btn.Name;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    //if (btn.Text.Substring(0,4) == "del ")
                    //{
                    //    btn.Text = btn.Text.Replace("del ", "mov ");
                    //    bLastMove = true;
                    //}
                    //else
                    //{
                    //    if (btn.Text.Substring(0, 4) == "mov ")
                    //        btn.Text = btn.Text.Replace("mov ", "del ");
                    //    else
                    //        btn.Text = btn.Text.Insert(0, "del ");
                    //    bLastMove = false;
                    //}
                    break;
                case MouseButtons.Middle:
                    break;

                case MouseButtons.Right:
                    //int tx=0, ty=0;
                    //bool bBreak = false;
                    //int ex=0, ey=0;
                    //String[] ToBtn = Name.Split(',');
                    //ty = int.Parse(ToBtn[0]);
                    //tx = int.Parse(ToBtn[1]);
                    //int iLoop=ty*iXkpl+tx;
                    //for (int y = iLoop; y >= 0; y--)
                    //{
                    //    if ((PicButs[y].Text.Substring(0, 4) == "del ") || (PicButs[y].Text.Substring(0, 4) == "mov "))
                    //    {
                    //        bLastMove = true;
                    //        if (PicButs[y].Text.Substring(0, 4) == "del ")
                    //            bLastMove = false;
                    //        ey = y;
                    //        bBreak = true;
                    //        break;
                    //    }
 
                    //}
                    //int lx = tx;
                    //int ly = ty;
                    //for (int y = iLoop; y >= 0; y--)
                    //{
                    //    if ((PicButs[y].Text.Substring(0, 4) == "del ") || (PicButs[y].Text.Substring(0, 4) == "mov "))
                    //    {
                                
                    //        bBreak = true;
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if (bLastMove)
                    //            PicButs[y].Text = PicButs[y].Text.Insert(0, "mov ");
                    //        else
                    //            PicButs[y].Text = PicButs[y].Text.Insert(0, "del ");

                    //    }
                          

            //        }
                    break;
            }
            bOnWork = false;

        }
        private void PicButs_Click(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //if (btn.Font.Strikeout)
            //    btn.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Regular);
            //else
            //    btn.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Strikeout);
        }
        private void PicButs_MouseEnter(object sender, EventArgs e)
        {
            bOnWork = true;
            PictureBox thispic = (PictureBox)sender;
            int iSize = SC_Base.SplitterDistance;
            Look = new Form();
            Look.FormBorderStyle = FormBorderStyle.FixedSingle;
            Look.Location = new Point(1, 1);
            Look.StartPosition = FormStartPosition.Manual;
            PictureBox lookpic = new PictureBox();
            lookpic.SizeMode = PictureBoxSizeMode.Zoom;
            lookpic.Size = new Size(iSize - 2, iSize-2);
            lookpic.Top = 1;
            lookpic.Left = 1;
            lookpic.Image = thispic.Image;
            Look.Size = new Size(iSize, lookpic.Height+50);
            Look.Controls.Add(lookpic);
            Look.Show();
        }

        private void PicButs_MouseLeave(object sender, EventArgs e)
        {
            //if (Look.Shown)
            Look.Close();
            bOnWork = false;
        }
        public Boolean NaytaKuvaPictureBoxissa(
                            Panel TmpPanel,
                            PictureBox TmpPbxSource,
                            String StrLbxSourceItem,int xMax,int yMax)
        {

            //String[] Nimi=StrLbxSourceItem;
            //uint uiHash = uint.Parse(StrLbxSourceItem);

            //FT_Temp = new FileTieto();
            if (!File.Exists(StrLbxSourceItem))
                return false;
            Bitmap btmp_Source = new Bitmap(StrLbxSourceItem);
            //Bitmap btmp_Source=new Bitmap(btmp_ASource,new Size(xMax-10,yMax-30));
            //btmp_ASource.Dispose();
            if (btmp_Source == null) return false;
            Size btmp_Source_size = btmp_Source.Size;
            //int bm_C_x = btmp_Source_size.Width;
            //int bm_C_y = btmp_Source_size.Height;
            //if (bm_C_x > bm_C_y)
            //{
            //    bm_C_y = (bm_C_y * (TmpPanel.Size.Width - 10)) / bm_C_x;
            //    bm_C_x = TmpPanel.Size.Width - 10;
            //}
            //else
            //{
            //    bm_C_x = (bm_C_x * (TmpPanel.Size.Height - 10)) / bm_C_y;
            //    bm_C_y = TmpPanel.Size.Height - 10;
            //}
            //if (bm_C_y > TmpPanel.Size.Height - 10)
            //{
            //    bm_C_x = (bm_C_x * (TmpPanel.Size.Height - 10)) / bm_C_y;
            //    bm_C_y = TmpPanel.Size.Height - 10;
            //}
            TmpPbxSource.MaximumSize = btmp_Source_size;
            TmpPbxSource.Size = TmpPbxSource.MaximumSize;
            TmpPbxSource.Image = new Bitmap(btmp_Source, TmpPbxSource.MaximumSize);
            btmp_Source.Dispose();
            TmpPanel.Controls.Add(TmpPbxSource);

            return true;
        }//bool NäytäKuvaPictureBoxissa
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FlBrD_Scan = new FolderBrowserDialog();

            if(File.Exists(strFile))
                FlBrD_Scan.SelectedPath = File.ReadAllText(strFile);
            FlBrD_Scan.ShowNewFolderButton = false;
            //PnlPics.Controls.Clear();
            if (FlBrD_Scan.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(strFile, FlBrD_Scan.SelectedPath);
    //            var files = Directory.GetFiles(@"d:\", "*").OrderByDescending(d => new FileInfo(d).LastWriteTime);
    //foreach(var directory in files)
    //{
                //DirectoryInfo HakemistoInfo = new DirectoryInfo(FlBrD_Scan.SelectedPath);
                //DirectoryInfo[] Hakemistot = HakemistoInfo.GetDirectories("*", SearchOption.TopDirectoryOnly);
                List<String> Polut = new List<string>();
                var files = Directory.GetDirectories(FlBrD_Scan.SelectedPath, "*", SearchOption.TopDirectoryOnly).OrderBy(d => new FileInfo(d).LastWriteTime);//CreationTime);
               //foreach (DirectoryInfo Hakemisto in Hakemistot)
                if (Polut.IndexOf(FlBrD_Scan.SelectedPath) == -1) 
                    Polut.Add(FlBrD_Scan.SelectedPath);
               foreach (var Hakemisto in files)
               {
                   if(Polut.IndexOf(Hakemisto)==-1)
                    Polut.Add(Hakemisto);
               }
                //                   Polut.Add(Hakemisto.FullName);
                //}
                //Polut.Add(HakemistoInfo.FullName);
               LBxPolut.Items.Clear();
                foreach (var Hakemisto in Polut)
                {
                    LBxPolut.Items.Add(Hakemisto);
                }
                LBxPolut.SelectedIndex = 0;
            }
            strMainPath = FlBrD_Scan.SelectedPath;

        }

        private void TSBtn_Work_Click(object sender, EventArgs e)
        {
            bOnWork = true;
            if (StrKohdePolku == String.Empty)
                TSBtn_destination_Click(sender, e);
            TSSPro.Minimum = 0;
            TSSPro.Maximum = iEnd - iStart + 1;
            TSSPro.Value = 0;
            if (null == PBx_pi) return;
            //PBx_pi.Image.Dispose();
            for (int i = iStart; i <= iEnd; i++)
            {
                String Orig = LBx_Nimet.Items[iStart].ToString();
                string file = Orig.Remove(0, Orig.LastIndexOf("\\") + 1);
                try
                {
                    File.Move(Orig, StrKohdePolku + "\\" + file);
                }
                catch (IOException err)
                {
                    TSSL_Path.Text = err.Message;
                } 
                LBx_Nimet.Items.RemoveAt(iStart);
                TSSPro.Value++;
            }
            if (iStart > 0)
                Tr.Value = iStart - 1;
            else
                Tr.Value = iStart;
            Tr.Maximum = LBx_Nimet.Items.Count - 1;
            Tr.TickFrequency = Tr.Maximum / 20;
            TSB_End.BackColor = Color.Gray;
            iEnd = 0;
            TSTXT_End.Text = "";
            TS_Home.BackColor = Color.Gray;
            iStart = 0;
            TSTXT_Start.Text = "";
            TSSL_Path.Text = LBxPolut.Items[LBxPolut.SelectedIndex].ToString() + " Jäljellä: " + LBx_Nimet.Items.Count.ToString();
            {
                string[] stopWordArray = new string[LBx_Nimet.Items.Count];
                LBx_Nimet.Items.CopyTo(stopWordArray, 0);
                File.WriteAllLines(LBxPolut.Items[LBxPolut.SelectedIndex].ToString() + "\\Files.txt", stopWordArray);
            }
            TSSPro.Value = 0; bOnWork = false;

        }

        private void TSBtn_destination_Click(object sender, EventArgs e)
        {
            //String strFile = "Kohde.txt";
            FolderBrowserDialog FlBrD_Scan = new FolderBrowserDialog();
            FlBrD_Scan.ShowNewFolderButton = false;
            if (FlBrD_Scan.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(strKohdeFile, FlBrD_Scan.SelectedPath);
                StrKohdePolku = FlBrD_Scan.SelectedPath;
            }
        }

        private void TSBtn_Next_Click(object sender, EventArgs e)
        {
            if (LBx_Nimet.Items.Count > 0)
            {
                bOnWork = true;
                iXkpl = Pnl_Pics.Width / iXKoko;
                iYkpl = Pnl_Pics.Height / iYKoko;
                
                TSSL_Path.Text = LBxPolut.Items[LBxPolut.SelectedIndex].ToString() + " Jäljellä: " + LBx_Nimet.Items.Count.ToString();
                {
                    string[] stopWordArray = new string[LBx_Nimet.Items.Count];
                    LBx_Nimet.Items.CopyTo(stopWordArray, 0);
                    File.WriteAllLines(LBxPolut.Items[LBxPolut.SelectedIndex].ToString() + "\\Files.txt", stopWordArray);
                }
                bOnWork = false;
            }
            else
            {
                bOnWork = true;
                
                String Polku = LBxPolut.Items[LBxPolut.SelectedIndex].ToString();
                if (strMainPath != Polku)
                {
                    var files = from file in
                                    Directory.EnumerateFiles(Polku)
                                where file.ToLower().Contains(".jpg")
                                select file;
                    if (files.Count() != 0)
                         File.Delete(Polku + "\\Files.txt");
                }
                bOnWork = false;
            }

        }

        private void ScanPics_FormClosing(object sender, FormClosingEventArgs e)
        {
            bOnWork = false;
            bClose = true;
        }

        private void LBxPolut_SelectedIndexChanged(object sender, EventArgs e)
        {
            iXkpl = Pnl_Pics.Width / iXKoko;
            iYkpl = Pnl_Pics.Height / iYKoko;
            //PicBoxs = new PictureBox[iYkpl, iXkpl];
            //PicButs = new Button[iYkpl * iXkpl];
            //Pnl_Pics.Controls.Clear();
            int iKoko = iXkpl * iYkpl;
            int i = 0;
            LBx_Nimet.Items.Clear();
            if (LBxPolut.SelectedIndex == -1)
                LBxPolut.SelectedIndex = 0;
            String Hakemisto = LBxPolut.Items[LBxPolut.SelectedIndex].ToString();
            //LBxPolut.Items.Add(Hakemisto);
            TSSL_Path.Text = Hakemisto;
            TSSPro.Value = 0;
            LBxPolut.Refresh();
            if (File.Exists(Hakemisto + "\\Files.txt"))
            {
                string[] tiedostot = File.ReadAllLines(Hakemisto + "\\Files.txt");
                LBx_Nimet.Items.AddRange(tiedostot);
                //Tr.Value = 0;
                TSB_Film_Click(sender, e);
                if (LBx_Nimet.Items.Count == 0)
                    Tr.Maximum = LBx_Nimet.Items.Count;
                else
                    Tr.Maximum = LBx_Nimet.Items.Count-1;
                Tr.Value = 0;
                TSSL_Path.Text = Hakemisto + " Haettu: " + LBx_Nimet.Items.Count.ToString();
                return;
            }
            var files = from file in
                            Directory.EnumerateFiles(Hakemisto,"*.*", SearchOption.TopDirectoryOnly)
                        where file.ToLower().Contains(".jpg")
                        select file;
            TSSPro.Maximum = files.Count() + 1;
            //FileInfo[] Tiedostot = Hakemistot[0].GetFiles("*.jpg", SearchOption.TopDirectoryOnly);
            //        FileInfo[] Tiedostot = Hakemisto.GetFiles("*.jpg", SearchOption.TopDirectoryOnly);
            //foreach (FileInfo Tiedosto in Tiedostot)
            int y = 0;
            int x = 0;

            foreach (var Tiedosto in files)
            {
                if (bClose) return;
                int iCount = 0;
                while (bOnWork)
                {
                    System.Threading.Thread.Sleep(10);
                    iCount++;
                    if (iCount == 100)
                    {
                        iCount = 0;
                        Application.DoEvents();
                    }
                }
                TSSPro.Value++;
                LBx_Nimet.Items.Add(Tiedosto);
                i++;
            }
            Tr.Maximum = LBx_Nimet.Items.Count-1;
            Tr.Value = 0;
            TSSL_Path.Text = Hakemisto + " Luettu: " + LBx_Nimet.Items.Count.ToString();
            {
                string[] stopWordArray = new string[LBx_Nimet.Items.Count];
                LBx_Nimet.Items.CopyTo(stopWordArray, 0);
                File.WriteAllLines(Hakemisto + "\\Files.txt", stopWordArray);
            }
            TSSPro.Value = 0;
            TSB_Film_Click(sender, e);

        }

        private void TSBtn_DeleteAll_Click(object sender, EventArgs e)
        {
            TSSPro.Minimum = 0;
            TSSPro.Maximum = iEnd - iStart + 1;
            TSSPro.Value = 0;
            //PBx_pi.Image.Dispose();
            for (int i = iStart; i <= iEnd; i++)
            {
                if(File.Exists(LBx_Nimet.Items[iStart].ToString()))
                    File.Delete(LBx_Nimet.Items[iStart].ToString());
                LBx_Nimet.Items.RemoveAt(iStart);
                TSSPro.Value++;
                if(TSSPro.Value%10==9)
                    SS_Tool.Refresh();
            }
            if(iStart>0)
                Tr.Value = iStart-1;
            else
                Tr.Value = iStart;
            Tr.Maximum = LBx_Nimet.Items.Count - 1;
            Tr.TickFrequency = Tr.Maximum / 20;
            TSB_End.BackColor = Color.Gray;
            iEnd = 0;
            TSTXT_End.Text = "";
            TS_Home.BackColor = Color.Gray;
            iStart = 0;
            TSTXT_Start.Text = "";
            TSSL_Path.Text = LBxPolut.Items[LBxPolut.SelectedIndex].ToString() + " Jäljellä: " + LBx_Nimet.Items.Count.ToString();
            {
                string[] stopWordArray = new string[LBx_Nimet.Items.Count];
                LBx_Nimet.Items.CopyTo(stopWordArray, 0);
                File.WriteAllLines(LBxPolut.Items[LBxPolut.SelectedIndex].ToString() + "\\Files.txt", stopWordArray);
            }
            TSSPro.Value = 0;
        }

        private void TSBtn_MoveAll_Click(object sender, EventArgs e)
        {
            TSSPro.Minimum = 0;
            TSSPro.Maximum = LBx_Nimet.Items.Count + 1;
            TSSPro.Value = 0;
            for (int i = 0; i < TSSPro.Maximum-1; i++)
            {
                //PBx_pi.Image.Dispose();
                String Orig=LBx_Nimet.Items[0].ToString();
                string file = Orig.Remove(0,Orig.LastIndexOf("\\")+1);
                try
                {
                    File.Move(Orig, StrKohdePolku + "\\" + file);
                }
                catch (IOException err)
                {
                    TSSL_Path.Text = err.Message;
                }
                LBx_Nimet.Items.RemoveAt(0);
                TSSPro.Value++;
            //    PicButs[i].Text = "Moved";
            }
            TSSL_Path.Text = LBxPolut.Items[LBxPolut.SelectedIndex].ToString() + " Jäljellä: " + LBx_Nimet.Items.Count.ToString();
            {
                string[] stopWordArray = new string[LBx_Nimet.Items.Count];
                LBx_Nimet.Items.CopyTo(stopWordArray, 0);
                File.WriteAllLines(LBxPolut.Items[LBxPolut.SelectedIndex].ToString() + "\\Files.txt", stopWordArray);
            }
            TSSPro.Value = 0;
            LBxPolut.SelectedIndex++;

        }

        private void TSB_Film_Click(object sender, EventArgs e)
        {
            TSBtn_Pict_Click(sender,e);
            bOnWork = true;
            //Tr.Dock = DockStyle.Bottom;
            SPC_Kuva.SplitterDistance = Pnl_Pics.Height - 30;
            Tr.Minimum = 0;
            Tr.TickStyle = TickStyle.TopLeft;
            //Tr.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            //Pnl_Pics.Controls.Add(Tr);
            //PBx_pi.Dock = DockStyle.Fill;
            //PBx_pi.SizeMode = PictureBoxSizeMode.Zoom;
            if (LBx_Nimet.Items.Count > 0)
            {
                while (LBx_Nimet.Items.Count > 0 && !File.Exists(LBx_Nimet.Items[Tr.Value].ToString()))
                    LBx_Nimet.Items.RemoveAt(Tr.Value);
                if (Tr.Value > LBx_Nimet.Items.Count)
                    Tr.Value = LBx_Nimet.Items.Count - 1;
                PBx_pi.ErrorImage.Dispose();
                //Bitmap image=null;
                //try
                //{
                //    image = new Bitmap(LBx_Nimet.Items[Tr.Value].ToString());
                //}
                //catch
                //{
                //}
                //PBx_pi.Image = image;
                FileStream fs = new FileStream(LBx_Nimet.Items[Tr.Value].ToString(), FileMode.Open, FileAccess.Read);
                PBx_pi.Image = System.Drawing.Image.FromStream(fs);
                fs.Close();
                //Pnl_Pics.Controls.Add(PBx_pi);
                Tr.Maximum = LBx_Nimet.Items.Count - 1;
                Tr.TickFrequency = Tr.Maximum / 20;
            }
            bOnWork = false;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (LBx_Nimet.Items.Count >= Tr.Value)
            {
                FileStream fs = new FileStream(LBx_Nimet.Items[Tr.Value].ToString(), FileMode.Open, FileAccess.Read);
                PBx_pi.Image = System.Drawing.Image.FromStream(fs);
                fs.Close();
                TSSL_Path.Text = LBxPolut.Items[LBxPolut.SelectedIndex].ToString() + " Jäljellä: " + Tr.Maximum + "-> " + Tr.Value;
                double fET= (double)(100 * Tr.Value) / Tr.Maximum;
                string strEtPors = Math.Round(fET, 1).ToString();
                tSSLbl_trpros.Text = " => " + strEtPors + " %";
                Application.DoEvents();
            }
        }

        private void TSB_End_Click(object sender, EventArgs e)
        {
            Tr.Select();
            iEnd = Tr.Value;
            TSB_End.BackColor = Color.Red;
            TSTXT_End.Text = iEnd.ToString();
        }

        private void TS_Home_Click(object sender, EventArgs e)
        {
            Tr.Select();
            iStart = Tr.Value;
            TS_Home.BackColor = Color.Red;
            TSTXT_Start.Text = iStart.ToString();
        }

        private void TSBtn_Pict_Click(object sender, EventArgs e)
        {
            if (PBx_pi != null)
            {
                PBx_pi.Dispose();
                PBx_pi = null;
            }
            PBx_pi = new PictureBox();
            PBx_pi.SizeMode = PictureBoxSizeMode.Zoom;
             PBx_pi.Dock = DockStyle.Fill;
             SPC_Kuva.Panel1.Controls.Add(PBx_pi);
       }

        private void LBxPolut_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox nlb = (ListBox)sender;
            LBxPolut.SelectedIndex = nlb.Items.IndexOf(nlb.SelectedItem);
            e.Handled = true;
            Tr.Select();
        }

        private void LBxPolut_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tr.Select();
        }

        private void LBxPolut_KeyUp(object sender, KeyEventArgs e)
        {
            Tr.Select();
        }

        private void TlStrpBtn_Del_Click(object sender, EventArgs e)
        {
            //if (bSelctionPressed == false)
            //    return;
            //MakeCorp();
            //if (LBx_Nimet.Items.Count == 0)
            //    return;

            File.Delete(LBx_Nimet.Items[Tr.Value].ToString());
            LBx_Nimet.Items.RemoveAt(Tr.Value);
            if (Tr.Value < Tr.Maximum)
                Tr.Maximum--;
            //PBx_pi.Image = new Bitmap(LBx_Nimet.Items[Tr.Value].ToString());
            if (LBx_Nimet.Items.Count > 0)
            {
                FileStream fs = new FileStream(LBx_Nimet.Items[Tr.Value].ToString(), FileMode.Open, FileAccess.Read);
                PBx_pi.Image = System.Drawing.Image.FromStream(fs);
                fs.Close();
            }
            TSSL_Path.Text = LBxPolut.Items[LBxPolut.SelectedIndex].ToString() + " Jäljellä: " + Tr.Maximum + "-> " + Tr.Value;
            double fET = (double)(100 * Tr.Value) / Tr.Maximum;
            string strEtPors = Math.Round(fET, 1).ToString();
            tSSLbl_trpros.Text = " => "+strEtPors+" %";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //handle your keys here
            if (keyData == Keys.Delete)
            {
                TlStrpBtn_Del_Click(new object(), new EventArgs());

                return true;
            }
            if (keyData == Keys.Left)
            {
                if(Tr.Value>0)
                    Tr.Value--;
                trackBar1_Scroll(new object(), new EventArgs());
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                if (Tr.Value < Tr.Maximum)
                    Tr.Value++;
                trackBar1_Scroll(new object(), new EventArgs());
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

}
