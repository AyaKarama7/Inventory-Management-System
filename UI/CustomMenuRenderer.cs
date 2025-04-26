using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public class CustomMenuRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            // Background color for menu items
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 32, 63)), e.Item.ContentRectangle);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            // Text color for menu items
            e.TextColor = ColorTranslator.FromHtml("#ADEFD1");
            base.OnRenderItemText(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Border color for MenuStrip
            using (Pen borderPen = new Pen(Color.FromArgb(0, 32, 63), 2))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(Point.Empty, e.ToolStrip.Size - new Size(1, 1)));
            }
        }
    }
}
