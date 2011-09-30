;;; Provides a command line interpreter for L Sharp
;;; NOW IT IS IN L#!!!
;;; TODO: load command line arguments

;;; Banner
(prl "Welcome to L Sharp .NET, a powerful lisp-based scripting language for .NET.")
(prl "Copyright (C) 2005 - 2006 Rob Blackwell & Active Web Solutions.")
(prl "Copyright (C) 2011 mlnlover11 Productions")
(prl "This version of LSI was written in L#")
(prl "This program is free software and is distributed under the terms of")
(prl "the GNU General Public License.")
(prl "For more information, see www.lsharp.org and ")
(prl "http://elijah.awesome99.org/index.php/lsharp")
(prl "")
(= environment System.Environment)
(foreach filename (GetCommandLineArgs environment)
	(prl filename)
	(if (endswith filename "lsi.exe") (prl "") (
		(if (endswith filename "lsi.ls") (prl "") (
			(= filename (replace filename "\\" "\\\\"))
			(prl "Loading " filename)
			(load filename)
		))
	))
)
(= top (new toploop))
(call run top)