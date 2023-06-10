using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Emit;

namespace _10._11_10._30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        static long GetDirectorySize(System.IO.DirectoryInfo directory,bool includeSubdir)
        {
            long totalSize = 0;
          
            System.IO.FileInfo[] files = directory.GetFiles();
            foreach (System.IO.FileInfo file in files)
            {
                totalSize += file.Length;
            }
            
             if (includeSubdir)
            {
                System.IO.DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (System.IO.DirectoryInfo dir in dirs)
                {
                    totalSize += GetDirectorySize(dir, true);
                }
            }
            return totalSize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            System.IO.DirectoryInfo dir = new
            System.IO.DirectoryInfo(@"c:\Intel");
            textBox1.Text = "Общий размер: " +
            GetDirectorySize(dir, true).ToString() + " байт.";
            this.Cursor = Cursors.Default;

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            TreeNode rootNode = new TreeNode(@"C:\");
            treeView1.Nodes.Add(rootNode);
         
            FillNodes(rootNode);
            treeView1.Nodes[0].Expand();
          
        }
        private void FillNodes(TreeNode dirNode)
        {
            DirectoryInfo dir = new DirectoryInfo(dirNode.FullPath);
            foreach (DirectoryInfo dirItem in dir.GetDirectories())
            {
                
                TreeNode newNode = new TreeNode(dirItem.Name);
                dirNode.Nodes.Add(newNode);
                newNode.Nodes.Add("*");
            }
        }
        private void treeDirectory_BeforeExpand(object sender,
         TreeViewCancelEventArgs e)
        {
            
            if (e.Node.Nodes[0].Text == "*")
            {
                e.Node.Nodes.Clear();
                FillNodes(e.Node);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] astrFiles = System.IO.Directory.GetFiles(@"c:\");
            listView1.Items.Add("Всего файлов: " + astrFiles.Length);
            foreach (string file in astrFiles)
                listView1.Items.Add(file);
        }

        private void button9_Click(object sender, EventArgs e)
        {

            string[] directoryEntries =
            System.IO.Directory.GetFileSystemEntries(@"c:\windows");
            foreach (string str in directoryEntries)
            {
                listView1.Items.Add(str);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] astrFiles = System.IO.Directory.GetFiles(@"c:\", "*.in?");
            listView1.Items.Add("Всего файлов: " + astrFiles.Length);
            foreach (string file in astrFiles)
                listView1.Items.Add(file);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\test.txt"))
                textBox1.Text = "Файл test.txt существует";
            else
                textBox1.Text = "Файл test.txt не существует";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Полный путь к файлу
            string fileNamePath = @"c:\windows\system32\notepad.exe";
            // Имя файла с расширением
            listView1.Items.Add(System.IO.Path.GetFileName(fileNamePath));
            // Имя файла без расширения
            listView1.Items.Add(
            System.IO.Path.GetFileNameWithoutExtension(fileNamePath));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Полный путь к файлу
            string fileNamePath = @"c:\windows\system32\notepad.exe";
            // Получим расширение файла
            listView1.Items.Add(System.IO.Path.GetExtension(fileNamePath));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // путь к тестовому файлу
            string path = @"c:\Users\79621\source\repos\2.26-2.34";
            // если файлы имел атрибут Скрытый
            if ((System.IO.File.GetAttributes(path) &
            System.IO.FileAttributes.Hidden)
            == System.IO.FileAttributes.Hidden)
            {
                // то устанавливаем атрибут Normal
                System.IO.File.SetAttributes(path,
                System.IO.FileAttributes.Normal);
                MessageBox.Show("Файл больше не является скрытым", path);
            }
            else // если файл не был скрытым
            {
                // то устанавливаем у файла атрибут Скрытый
                System.IO.File.SetAttributes(path,
                System.IO.File.GetAttributes(path) |
                System.IO.FileAttributes.Hidden);
                MessageBox.Show("Файл стал скрытым", path);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Выводим информацию о файле.
            System.IO.FileInfo file = new
            System.IO.FileInfo(@"c:\Users\79621\source\repos\2.26-2.34");
            listView1.Items.Clear();
            listView1.Items.Add("Свойства для файла: " + file.Name);
            listView1.Items.Add("Наличие файла: " + file.Exists.ToString());
            if (file.Exists)
            {
                listView1.Items.Add("Время создания файла: ");
                listView1.Items.Add(file.CreationTime.ToString());
                listView1.Items.Add("Последнее изменение файла: ");
                listView1.Items.Add(file.LastWriteTime.ToString());
                listView1.Items.Add("Файл был открыт в последний раз: ");
                listView1.Items.Add(file.LastAccessTime.ToString());
                listView1.Items.Add("Размер файла (в байтах): ");
                listView1.Items.Add(file.Length.ToString());
                listView1.Items.Add("Атрибуты файла: ");
                listView1.Items.Add(file.Attributes.ToString());
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.FileVersionInfo info =
            System.Diagnostics.FileVersionInfo.GetVersionInfo(@"c:\Users\79621\source\repos\2.26-2.34");
         
            listBox1.Items.Add("Выбранный файл: " + info.FileName);
            listBox1.Items.Add("Product Name: " + info.ProductName);
            listBox1.Items.Add("Product Version: " + info.ProductVersion);
            listBox1.Items.Add("Company Name: " + info.CompanyName);
            listBox1.Items.Add("File Version: " + info.FileVersion);
            listBox1.Items.Add("File Description: " + info.FileDescription);
            listBox1.Items.Add("Original Filename: " + info.OriginalFilename);
            listBox1.Items.Add("Legal Copyright: " + info.LegalCopyright);
            listBox1.Items.Add("InternalName: " + info.InternalName);
            listBox1.Items.Add("IsDebug: " + info.IsDebug);
            listBox1.Items.Add("IsPatched: " + info.IsPatched);
            listBox1.Items.Add("IsPreRelease: " + info.IsPreRelease);
            listBox1.Items.Add("IsPrivateBuild: " + info.IsPrivateBuild);
            listBox1.Items.Add("IsSpecialBuild: " + info.IsSpecialBuild);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            // Создаем временный файл
            listBox1.Items.Add(System.IO.Path.GetTempFileName());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string randomFile = System.IO.Path.GetRandomFileName();
            MessageBox.Show(randomFile); // вернет что-то типа 5wvzx2n0.lby
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string tempText = System.IO.Path.ChangeExtension(
            System.IO.Path.GetRandomFileName(), ".txt");
            MessageBox.Show(tempText);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string fileName = @"c:\test.txt";
            FileStream stream = new FileStream(fileName,
             FileMode.Open, FileAccess.Read, FileShare.None);
            
            stream.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string fileName = @"c:\test.txt";
            FileStream stream = File.Open(fileName, FileMode.Open);
            stream.Lock(0, stream.Length);
            stream.Unlock(0, stream.Length);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string fileName = @"c:\wutemp\test.bin";
            // Создадим новый пустой файл
            if (System.IO.File.Exists(fileName))
            {
                MessageBox.Show("Указанный файл уже существует!", fileName);
                return;
            }
            System.IO.FileStream fs = new System.IO.FileStream(fileName,
            System.IO.FileMode.CreateNew);
            // Запишем данные в файл
            System.IO.BinaryWriter w = new System.IO.BinaryWriter(fs);

            for (int i = 0; i < 11; i++)
            {
                w.Write((int)i);
            }
            w.Close();
            fs.Close();
            // Попытаемся прочитать записанное
            fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open,
            System.IO.FileAccess.Read);
            System.IO.BinaryReader binread = new System.IO.BinaryReader(fs);
            // считываем данные из test.bin
            for (int i = 0; i < 11; i++)
            {
                MessageBox.Show(binread.ReadInt32().ToString());
            }
            w.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string fileName = @"c:\wutemp\text.txt";
            if (System.IO.File.Exists(fileName))
            {
                MessageBox.Show("Указанный файл уже существует.", fileName);
                return;
            }
            System.IO.StreamWriter sr = System.IO.File.CreateText(fileName);
            sr.WriteLine("Раз, два, три, четыре, пять");
            sr.WriteLine("1, 2, 3. 9 1/2 и так далее");
            sr.WriteLine("Я изучаю {0} и {1}.", "C#", "Visual Basic");
            sr.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string fileName = @"c:\wutemp\text.txt";
            // Добавляем одну строчку в текстовый файл
            using (System.IO.StreamWriter sw =
            System.IO.File.AppendText(fileName))
            {
                sw.WriteLine("Добавили еще одну строчку");
            }
            // Прочитаем текст из файла
            using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    MessageBox.Show(s);
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // Создадим экземпляр StreamReader для чтения из файла
            using (System.IO.StreamReader sr = new StreamReader(@"c:\Users\79621\source\repos\2.26-2.34"))
            {
                String line;
                // Читаем каждую строку, пока не достигнем конца файла
                while ((line = sr.ReadLine()) != null)
                {
                    MessageBox.Show(line);
                }
            }
        }
    }
}
