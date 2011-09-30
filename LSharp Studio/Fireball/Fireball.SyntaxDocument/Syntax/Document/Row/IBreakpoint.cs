using System;
using System.Drawing;

namespace Fireball.Syntax
{
	public interface IBreakpoint
	{
        event EventHandler BreakpointChanged;

        /// <summary>
        /// The line at which the breakpoint is located
        /// </summary>
        int Line
        {
            get;
            set;
        }

        /// <summary>
        /// The document row on which the breakpoint is located
        /// </summary>
        Row Row
        {
            get;
        }

        /// <summary>
        /// True if the breakpoint is enabled. Otherwise false.
        /// </summary>
        bool Enabled
        {
            get;
            set;
        }

        /// <summary>
        /// Image used to draw the breakpoint when it's enabled
        /// </summary>
        Bitmap BreakpointEnabledImage
        {
            get;
        }

        /// <summary>
        /// Image used to draw the breakpoint when it's disabled
        /// </summary>
        Bitmap BreakpointDisabledImage
        {
            get;
        }
	}
}
