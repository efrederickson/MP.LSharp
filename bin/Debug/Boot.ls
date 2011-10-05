(reference "System.Windows.Forms")
(reference "System.Drawing")
(reference "System.Xml")

(using "System.Windows.forms")
(using "System.Drawing")
(using "System.xml")
(using "LSharp.Interpreter")

(call Banner Program) ;;; Print the Banner from LSharp.Interpreter.Program

(run (new TopLoop));;; Run a TopLoop