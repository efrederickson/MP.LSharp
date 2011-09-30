using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace LSharp.Studio.Core.Utils
{
    public class ToolStripFlatBorderRenderer : ToolStripProfessionalRenderer
    {
        protected override void Initialize(ToolStrip toolStrip)
        {
            base.Initialize(toolStrip);
            this.RoundedEdges = false;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            Rectangle rect = e.AffectedBounds;
            Brush b = new LinearGradientBrush(rect, this.ColorTable.StatusStripGradientBegin,
                                              this.ColorTable.StatusStripGradientEnd, 270.0f);
            e.Graphics.FillRectangle(b, rect);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            Rectangle rect = e.ToolStrip.ClientRectangle;
            rect.Width -= 1;
            e.Graphics.DrawRectangle(new Pen(SystemColors.ControlDark), rect);
        }
    }
}
