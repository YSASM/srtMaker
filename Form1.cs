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
            contentInput.Text = $"第一条字幕内容，比如说咱们怎么使用这个工具呢，其实很简单，一行一行地往里粘贴内容就可以了{Environment.NewLine}{Environment.NewLine}第二条字幕内容，比如说软件靠【两次换行】或者说分段来检测字幕分条，回车两次以后的新段落会被判定为下一条字幕的内容{Environment.NewLine}{Environment.NewLine}第三条字幕内容，比如说你可以很方便地从 Excel 里面全选一列，然后把多条文字信息全粘过来，然后在合适的地方分段";
        }

        private Font loadFont(string path)
        {
            try
            {
                int fontSize;
                var success = int.TryParse(fontSizeInput.Text, out fontSize);
                if (!success)
                {
                    alert("类型错误!", "字体大小必须为数字!");
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
                alert("类型错误!", "持续描述必须为数字!");
                return;
            }
            int subtitleLength;
            success = int.TryParse(subtitleLengthInput.Text, out subtitleLength);
            if (!success)
            {
                alert("类型错误!", "字幕条数必须为数字!");
                return;
            }
            int subtitleWidth;
            success = int.TryParse(subtitleWidthInput.Text, out subtitleWidth);
            if (!success)
            {
                alert("类型错误!", "换行宽度必须为数字!");
                return;
            }
            int linesLength;
            success = int.TryParse(linesInput.Text, out linesLength);
            if (!success)
            {
                alert("类型错误!", "限制行数必须为数字!");
                return;
            }
            int fontSize;
            success = int.TryParse(fontSizeInput.Text, out fontSize);
            if (!success)
            {
                alert("类型错误!", "字体大小必须为数字!");
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
            string folderPath = Environment.CurrentDirectory + "/Fonts"; // 替换为你的文件夹路径
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string[] files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
            if (files.Length <= 0)
            {
                throw new Exception("字体文件为空");
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
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // 创建保存对话框
            saveFileDialog.FileName = "output";
            saveFileDialog.Filter = "SRT文件(*.srt) | *.srt"; // 设置文件类型
            saveFileDialog.AddExtension = true; // 自动添加扩展名
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
