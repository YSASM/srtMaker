using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace srtMaker
{
    public partial class Form1 : Form
    {
        private Font selectedFont = null;
        private string selectedFontPath = null;
        private Dictionary<string, Font> fontDict = new Dictionary<string, Font>();
        private Dictionary<string, string> fontPathDict = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            getFonts();
            contentInput.Text = $"��һ����Ļ���ݣ�����˵������ôʹ����������أ���ʵ�ܼ򵥣�һ��һ�е�����ճ�����ݾͿ�����{Environment.NewLine}{Environment.NewLine}�ڶ�����Ļ���ݣ�����˵����������λ��С�����˵�ֶ��������Ļ�������س������Ժ���¶���ᱻ�ж�Ϊ��һ����Ļ������{Environment.NewLine}{Environment.NewLine}��������Ļ���ݣ�����˵����Ժܷ���ش� Excel ����ȫѡһ�У�Ȼ��Ѷ���������Ϣȫճ������Ȼ���ں��ʵĵط��ֶ�";
        }

        private Font loadFont(string path)
        {
            try
            {
                int fontSize;
                var success = int.TryParse(fontSizeInput.Text, out fontSize);
                if (!success)
                {
                    alert("���ʹ���!", "�����С����Ϊ����!");
                    return null;
                }
                PrivateFontCollection pfc = new PrivateFontCollection();
                pfc.AddFontFile(path);
                Font font = new Font(pfc.Families[0], fontSize);
                return font;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void onContentChanged(object sender, EventArgs e)
        {
            makeContentOutput();
        }

        private string convertSecondsToHMS(int totalSeconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(totalSeconds);
            return time.ToString("hh\\:mm\\:ss") + ",000";
        }

        private void makeContentOutput()
        {
            int duration;
            bool success = int.TryParse(durationInput.Text, out duration);
            if (!success)
            {
                alert("���ʹ���!", "������������Ϊ����!");
                return;
            }
            int subtitleLength;
            success = int.TryParse(subtitleLengthInput.Text, out subtitleLength);
            if (!success)
            {
                alert("���ʹ���!", "��Ļ��������Ϊ����!");
                return;
            }
            int subtitleWidth;
            success = int.TryParse(subtitleWidthInput.Text, out subtitleWidth);
            if (!success)
            {
                alert("���ʹ���!", "���п�ȱ���Ϊ����!");
                return;
            }
            int linesLength;
            success = int.TryParse(linesInput.Text, out linesLength);
            if (!success)
            {
                alert("���ʹ���!", "������������Ϊ����!");
                return;
            }
            int fontSize;
            success = int.TryParse(fontSizeInput.Text, out fontSize);
            if (!success)
            {
                alert("���ʹ���!", "�����С����Ϊ����!");
                return;
            }
            var start = 0;
            //contentOutput.SelectionFont = loadFont();
            if(contentOutput.Font.Name != selectedFont.Name)
            {
                contentOutput.Font = selectedFont;
            }
            if(contentOutput.Font.Size != fontSize)
            {
                contentOutput.Font = loadFont(selectedFontPath);
            }
            string content = contentInput.Text;
            var lines = content.Split(Environment.NewLine);
            var sentence = "";
            var count = 1;
            foreach (var line in lines)
            {
                if (count > subtitleLength)
                {
                    break;
                }
                if (line.Length > 0)
                {
                    var end = start + duration;
                    sentence += count + Environment.NewLine;
                    sentence += convertSecondsToHMS(start) + " --> " + convertSecondsToHMS(end) + Environment.NewLine;
                    var formatSentence = "";
                    var lineWidth = 0;
                    var linesLangthCount = 0;
                    foreach (var c in line)
                    {
                        var cWidth = TextRenderer.MeasureText(c + "", selectedFont).Width;
                        if ((lineWidth + cWidth) > subtitleWidth)
                        {
                            linesLangthCount++;
                            if (linesLangthCount >= linesLength)
                            {
                                formatSentence += Environment.NewLine + ellipsisInput.Text;
                                break;
                            }
                            formatSentence += Environment.NewLine + c;
                            lineWidth = cWidth;
                        }
                        else
                        {
                            formatSentence += c;
                            lineWidth += cWidth;
                        }
                    }
                    sentence += formatSentence + Environment.NewLine;
                    start = end;
                    count++;
                }
                else
                {
                    sentence += Environment.NewLine;
                }
            }
            if (contentOutput.Text != sentence)
            {
                contentOutput.Text = sentence;
            }
        }

        private void getFonts()
        {
            fontSelect.Items.Clear();
            string folderPath = Environment.CurrentDirectory + "/Fonts"; // �滻Ϊ����ļ���·��
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string[] files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
            if (files.Length <= 0)
            {
                throw new Exception("�����ļ�Ϊ��");
            }
            int id = 0;
            foreach (string file in files)
            {
                var font = loadFont(file);
                var name = id + ":" + font.Name;
                fontDict[name] = font;
                fontPathDict[name] = file;
                if (font != null)
                {
                    id++;
                    fontSelect.Items.Add(name);
                }
            }
            fontSelect.SelectedIndex = 0;
        }

        private void onFontSelectChange(object sender, EventArgs e)
        {
            var selected = fontSelect.SelectedItem;
            if (selected != null)
            {
                selectedFont = fontDict[selected.ToString()];
                selectedFontPath = fontPathDict[selected.ToString()];
            }
            makeContentOutput();
        }

        private void alert(string title, string message)
        {
            MessageBox.Show(title, message);
        }

        private void saveSrtFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // ��������Ի���
            saveFileDialog.FileName = "output";
            saveFileDialog.Filter = "SRT�ļ�(*.srt) | *.srt"; // �����ļ�����
            saveFileDialog.AddExtension = true; // �Զ������չ��
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileName = saveFileDialog.FileName;
            File.WriteAllText(fileName, contentOutput.Text);
        }

        private void onConfigsInputChange(object sender, EventArgs e)
        {
            makeContentOutput();
        }
    }
}
