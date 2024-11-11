using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srtMaker
{
    public class CustomTextBox : TextBox
    {
        private Font customFont;

        public CustomTextBox()
        {
            // 初始化自定义字体
            customFont = new Font("Consolas", 12, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 应用自定义字体
            e.Graphics.DrawString(this.Text, customFont, SystemBrushes.WindowText, new PointF(0, 0));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // 释放自定义字体资源
                customFont.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
