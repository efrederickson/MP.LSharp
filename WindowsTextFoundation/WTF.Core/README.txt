WTF (WindowsTextFoundation) is an attempt to create plaintext files that 
define objects (like in WPF). 

Format: 
BEGIN <Type> <Name> <constructor args>
    Property1 = Value
    Property2 = System.Drawing.PointF(2,2)
ENDOBJECT

Example: 

BEGIN System.Windows.Forms.Form frm "Hello"
    Size = System.Drawing.Point(10, 10)
    Text = "Hai"
    TabIndex = 1
ENDOBJECT

Current Languages: 
C#
VB.NET
L#

Platforms:
Windows XP/7

TODO:
Mono Support
[Languages]: Boo, J#, F#, Python, Ruby
Extendable (for language exporting)