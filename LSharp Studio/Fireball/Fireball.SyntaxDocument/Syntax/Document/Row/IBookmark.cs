using System;
using System.Drawing;

namespace Fireball.Syntax
{
    public interface IBookmark
    {
        event EventHandler BookmarkChanged;

        /// <summary>
        /// The line at which the bookmark is located
        /// </summary>
        int Line
        {
            get;
            set;
        }

        /// <summary>
        /// True if the bookmark is enabled. Otherwise false.
        /// </summary>
        bool Enabled
        {
            get;
            set;
        }

        /// <summary>
        /// Image used to draw the bookmark when it's enabled
        /// </summary>
        Bitmap BookmarkEnabledImage
        {
            get;
            set;
        }

        /// <summary>
        /// Image used to draw the bookmark when it's disabled
        /// </summary>
        Bitmap BookmarkDisabledImage
        {
            get;
            set;
        }
    }
}
