
//	Copyright (C) 2005  Sebastian Faltoni <sebastian@dotnetfireball.org>
//	
//	This library is free software; you can redistribute it and/or
//	modify it under the terms of the GNU Lesser General Public
//	License as published by the Free Software Foundation; either
//	version 2.1 of the License, or (at your option) any later version.
//	
//	This library is distributed in the hope that it will be useful,
//	but WITHOUT ANY WARRANTY; without even the implied warranty of
//	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//	Lesser General Public License for more details.
//	
//	You should have received a copy of the GNU Lesser General Public
//	License along with this library; if not, write to the Free Software
//	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using System.Collections.Generic;
using System.Text;

namespace Fireball.Windows.Forms.CodeEditor
{
    public sealed class Localizations
    {
        private static string _FindDialogText = "Find";
        private static string _FindNextButtonText = "Next Next";
        private static string _FindReplaceButtonText = "Replace";
        private static string _FindMarkAllButtonText = "Mark All";
        private static string _FindCloseButtonText = "Close";
        private static string _FindWhatLabelText = "Find What:";
        private static string _FindReplaceWithLabelText = "Replace With:";
        private static string _FindMatchCaseLabel = "Match Case";
        private static string _FindMatchWholeWordLabel = "Match whole word";
        private static string _FindUseRegExLabel = "Use regular expressions";
        private static string _ReplaceDialogText = "Replace";
        private static string _FindReplaceAllButtonText = "Replace All";

        public static string FindReplaceAllButtonText
        {
            get { return Localizations._FindReplaceAllButtonText; }
            set { Localizations._FindReplaceAllButtonText = value; }
        }

        public static string ReplaceDialogText
        {
            get { return Localizations._ReplaceDialogText; }
            set { Localizations._ReplaceDialogText = value; }
        }

        public static string FindUseRegExLabel
        {
            get { return Localizations._FindUseRegExLabel; }
            set { Localizations._FindUseRegExLabel = value; }
        }

        public static string FindMatchWholeWordLabel
        {
            get { return Localizations._FindMatchWholeWordLabel; }
            set { Localizations._FindMatchWholeWordLabel = value; }
        }

        public static string FindMatchCaseLabel
        {
            get { return Localizations._FindMatchCaseLabel; }
            set { Localizations._FindMatchCaseLabel = value; }
        }

        public static string FindReplaceWithLabelText
        {
            get { return Localizations._FindReplaceWithLabelText; }
            set { Localizations._FindReplaceWithLabelText = value; }
        }

        public static string FindWhatLabelText
        {
            get { return Localizations._FindWhatLabelText; }
            set { Localizations._FindWhatLabelText = value; }
        }

        public static string FindCloseButtonText
        {
            get { return Localizations._FindCloseButtonText; }
            set { Localizations._FindCloseButtonText = value; }
        }

        public static string FindMarkAllButtonText
        {
            get { return Localizations._FindMarkAllButtonText; }
            set { Localizations._FindMarkAllButtonText = value; }
        }

        public static string FindReplaceButtonText
        {
            get { return Localizations._FindReplaceButtonText; }
            set { Localizations._FindReplaceButtonText = value; }
        }

        public static string FindNextButtonText
        {
            get { return Localizations._FindNextButtonText; }
            set { Localizations._FindNextButtonText = value; }
        }

        public static string FindDialogText
        {
            get { return Localizations._FindDialogText; }
            set { Localizations._FindDialogText = value; }
        }
    }
}
