(using "System.Windows.Forms")

;;; LSL in L#
;;; MAKE SURE TO COMPILE AS A WinForms PROGRAM!!
(= env system.Environment)
(= filename (GetValue (GetCommandLineArgs env) 0))
(= filename (Replace filename "\\" "\\\\"))

;;; the beauty of this is we just need to call Load... theoretically.
(load filename)
