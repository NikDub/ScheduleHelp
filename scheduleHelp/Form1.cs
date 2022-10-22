using scheduleHelp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace scheduleHelp
{

    public partial class Form1 : Form
    {
        string group = null;
        public Form1()
        {
            InitializeComponent();
            Start();
            CreateData();
            //var word = new Word.Application();
            //var doc = word.Documents.Open(@"C:\Users\nikdu\source\repos\scheduleHelp\scheduleHelp\fit-1.docx");
            //var asd = doc.Tables[2].Cell(1,3).Range.Text;
            //var asd1 = doc.Tables[2].Cell(2,2).Range.Text;
            //var asd2 = doc.Tables[2].Cell(2,1).Range.Text;
            //doc.Close();
        }

        void CreateData()
        {
            using (KikushaDB dB = new KikushaDB())
            {
                IQueryable<ScheduleForShow> list;
                if(group == null)
                    list = dB.Schedules.Include(e => e.Groups)
                        .Include(e => e.Days)
                        .Include(e => e.Subjects)
                        .Include(e => e.Rooms)
                        .Include(e => e.WeekColors)
                        .Include(e => e.LessonsTime)
                        .Include(e => e.Teachers)
                        .Select(e => new ScheduleForShow
                        {
                            id = e.id,
                            subject = e.Subjects.name,
                            teacher = e.Teachers.name,
                            group = e.Groups.name,
                            room = e.Rooms.name,
                            day = e.Days.name,
                            weekcolor = e.WeekColors.name,
                            time = e.LessonsTime.timestart.ToString(),
                            subgroup = e.subgroup.ToString()
                        })
                        .AsNoTracking();
                else
                    list = dB.Schedules.Include(e => e.Groups)
                      .Include(e => e.Days)
                      .Include(e => e.Subjects)
                      .Include(e => e.Rooms)
                      .Include(e => e.WeekColors)
                      .Include(e => e.LessonsTime)
                      .Include(e => e.Teachers)
                      .Where(e=>e.Groups.name == group)
                      .Select(e => new ScheduleForShow
                      {
                          id = e.id,
                          subject = e.Subjects.name,
                          teacher = e.Teachers.name,
                          group = e.Groups.name,
                          room = e.Rooms.name,
                          day = e.Days.name,
                          weekcolor = e.WeekColors.name,
                          time = e.LessonsTime.timestart.ToString(),
                          subgroup = e.subgroup.ToString()
                      })
                      .AsNoTracking();

                dataGridView1.DataSource = list.ToList();
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                dataGridView1.AllowUserToDeleteRows = false;
            }
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

        private void button1_Click(object sender, EventArgs e)
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

                    var temp = dB.Schedules.Add(new Schedules()
                    {
                        subjectnameid = int.Parse(label8.Text),
                        groupid = int.Parse(label9.Text),
                        roomid = int.Parse(label10.Text),
                        dayid = int.Parse(label11.Text),
                        week_colorid = int.Parse(label12.Text),
                        lessonstimeid = int.Parse(label13.Text),
                        subgroup = int.Parse(comboBox7.Text),
                    });

                    if (label17.Text != "")
                        temp.teacherid = int.Parse(label17.Text);

                    dB.SaveChangesAsync();
                }
                label15.Text = "Успешно";
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
                comboBox6.Items.Clear();
                comboBox7.Items.Clear();
                comboBox8.Items.Clear();
                Start();
                CreateData();
            }
            catch (Exception)
            {
                label15.Text = "Ошибка";
            }
        }

        private void DataGridView1_CellMouseDoubleClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs ex)
        {
            if (dataGridView1.SelectedCells.Count == 1 && dataGridView1.SelectedCells[0]?.ColumnIndex == 0)
            {
                using (KikushaDB dB = new KikushaDB())
                {
                    var cellval = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                    var temp = dB.Schedules.Include(e => e.Groups).Include(e => e.Days).Include(e => e.Subjects)
                                .Include(e => e.Rooms).Include(e => e.WeekColors).Include(e => e.LessonsTime).Include(e => e.Teachers)
                                .Where(item => item.id == cellval).ToList()
                                .Select(e => new ScheduleForShow
                                {
                                    id = e.id,
                                    subject = e.Subjects.name,
                                    teacher = e.Teachers?.name,
                                    group = e.Groups.name,
                                    room = e.Rooms?.name,
                                    day = e.Days.name,
                                    weekcolor = e.WeekColors.name,
                                    time = e.LessonsTime.timestart.ToString(),
                                    subgroup = e.subgroup?.ToString()
                                }).FirstOrDefault();

                    Form2 form = new Form2();
                    form.comboBox1.Text = temp.subject;
                    form.comboBox2.Text = temp.group;
                    form.comboBox3.Text = temp.room;
                    form.comboBox4.Text = temp.day;
                    form.comboBox5.Text = temp.weekcolor;
                    form.comboBox6.Text = temp.time;
                    form.comboBox7.Text = temp.subgroup;
                    form.comboBox8.Text = temp.teacher;
                    form.id = temp.id;
                    form.ShowDialog();

                    comboBox1.Items.Clear();
                    comboBox2.Items.Clear();
                    comboBox3.Items.Clear();
                    comboBox4.Items.Clear();
                    comboBox5.Items.Clear();
                    comboBox6.Items.Clear();
                    comboBox7.Items.Clear();
                    comboBox8.Items.Clear();
                    Start();
                    CreateData();
                }
            }

        }

        private void TextBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox1.Text == "")
                    group = null;
                else
                    group = textBox1.Text;
                CreateData();
            }
        }

    }
}
