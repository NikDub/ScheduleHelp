using scheduleHelp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scheduleHelp
{
    public partial class Form2 : Form
    {
        public int id;
        public Form2()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            using (KikushaDB dB = new KikushaDB())
            {
                comboBox1.Items.AddRange(dB.Subjects.Select(i => i.name).ToArray());
                comboBox2.Items.AddRange(dB.Groups.Select(i => i.name).ToArray());
                comboBox3.Items.AddRange(dB.Rooms.Select(i => i.name + " " + i.housing).ToArray());
                comboBox4.Items.AddRange(dB.Days.Select(i => i.name).ToArray());
                comboBox5.Items.AddRange(dB.WeekColors.Select(i => i.name).ToArray());
                comboBox6.Items.AddRange(dB.LessonsTime.ToList().Select(i => $"{i.timestart} - {i.timestop} in {i.corpus}").ToArray());
                comboBox7.Items.AddRange(new List<string>() { "1", "2", "0" }.ToArray());
                comboBox8.Items.AddRange(dB.Teachers.Select(i => i.name).ToArray());
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            using (KikushaDB dB = new KikushaDB())
            {
                var temp = dB.Subjects.FirstOrDefault(m => m.name.StartsWith(comboBox1.Text));
                if (temp != null)
                {
                    label8.Text = temp.id.ToString();
                }
                else
                    label8.Text = "";
            }

        }

        private void ComboBox1_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                using (KikushaDB dB = new KikushaDB())
                    comboBox1.Text = dB.Subjects.ToList().FirstOrDefault(m => m.id == int.Parse(label8.Text)).name;
            }
            catch (Exception)
            {
                label8.Text = "";
            }
        }

        private void comboBox8_TextChanged(object sender, EventArgs e)
        {
            using (KikushaDB dB = new KikushaDB())
            {
                var temp = dB.Teachers.FirstOrDefault(m => m.name.StartsWith(comboBox8.Text));
                if (temp != null)
                {
                    label17.Text = temp.id.ToString();
                }
                else
                    label17.Text = "";
            }

        }

        private void ComboBox8_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                using (KikushaDB dB = new KikushaDB())
                    comboBox8.Text = dB.Teachers.ToList().FirstOrDefault(m => m.id == int.Parse(label17.Text)).name;
            }
            catch (Exception)
            {
                label17.Text = "";
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            using (KikushaDB dB = new KikushaDB())
            {
                var temp = dB.Groups.FirstOrDefault(m => m.name.StartsWith(comboBox2.Text));
                if (temp != null)
                {
                    label9.Text = temp.id.ToString();
                }
                else
                    label9.Text = "";
            }

        }

        private void ComboBox2_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                using (KikushaDB dB = new KikushaDB())
                    comboBox2.Text = dB.Groups.ToList().FirstOrDefault(m => m.id == int.Parse(label9.Text)).name;
            }
            catch (Exception)
            {
                label9.Text = "";
            }
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (KikushaDB dB = new KikushaDB())
                {
                    var temp = dB.Rooms.ToList().FirstOrDefault(m => m.name.StartsWith(comboBox3.Text.Split()[0]));
                    if (temp != null)
                    {
                        label10.Text = temp.id.ToString();
                    }
                    else
                        label10.Text = "";
                }
            }
            catch (Exception) { }
        }

        private void ComboBox3_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                using (KikushaDB dB = new KikushaDB())
                {
                    var roomInfo = dB.Rooms.ToList().FirstOrDefault(m => m.id == int.Parse(label10.Text.Split()[0]));
                    comboBox3.Text = roomInfo.name + " " + roomInfo.housing;
                }
            }
            catch (Exception)
            {
                label10.Text = "";
            }
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            using (KikushaDB dB = new KikushaDB())
            {
                var temp = dB.Days.FirstOrDefault(m => m.name.StartsWith(comboBox4.Text));
                if (temp != null)
                {
                    label11.Text = temp.id.ToString();
                }
                else
                    label11.Text = "";
            }
        }

        private void ComboBox4_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                using (KikushaDB dB = new KikushaDB())
                    comboBox4.Text = dB.Days.ToList().FirstOrDefault(m => m.id == int.Parse(label11.Text)).name;
            }
            catch (Exception)
            {
                label11.Text = "";
            }
        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            using (KikushaDB dB = new KikushaDB())
            {
                var temp = dB.WeekColors.FirstOrDefault(m => m.name.StartsWith(comboBox5.Text));
                if (temp != null)
                {
                    label12.Text = temp.id.ToString();
                }
                else
                    label12.Text = "";
            }
        }

        private void ComboBox5_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                using (KikushaDB dB = new KikushaDB())
                    comboBox5.Text = dB.WeekColors.ToList().FirstOrDefault(m => m.id == int.Parse(label12.Text)).name;
            }
            catch (Exception)
            {
                label12.Text = "";
            }
        }

        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            using (KikushaDB dB = new KikushaDB())
            {
                var temp = dB.LessonsTime.FirstOrDefault(m => m.timestart.ToString().StartsWith(comboBox6.Text));
                if (temp != null)
                    label13.Text = temp.id.ToString();
            }
        }

        private void ComboBox6_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                using (KikushaDB dB = new KikushaDB())
                {
                    var time = dB.LessonsTime.ToList().FirstOrDefault(m => m.id == int.Parse(label13.Text));
                    comboBox6.Text = $"{time.timestart} - {time.timestop} in {time.corpus}";
                }
            }
            catch (Exception)
            {
                label13.Text = "";
            }
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (KikushaDB dB = new KikushaDB())
                {
                    if (label8.Text == "")
                    {
                        var asd = dB.Subjects.Add(new Subjects() { name = comboBox1.Text });
                        dB.SaveChanges();
                        label8.Text = asd.id.ToString();
                    }

                    var tempitem = dB.Schedules.FirstOrDefault(i => i.id == id);

                    tempitem.subjectnameid = int.Parse(label8.Text);
                    tempitem.groupid = int.Parse(label9.Text);
                    tempitem.roomid = int.Parse(label10.Text);
                    tempitem.dayid = int.Parse(label11.Text);
                    tempitem.week_colorid = int.Parse(label12.Text);
                    tempitem.lessonstimeid = int.Parse(label13.Text);
                    tempitem.subgroup = int.Parse(comboBox7.Text);

                    if (label17.Text != "")
                        tempitem.teacherid = int.Parse(label17.Text);

                    dB.SaveChanges();
                }
                label15.Text = "Успешно";
                Close();
            }
            catch (Exception)
            {
                label15.Text = "Ошибка";
            }
        }
    }
}
