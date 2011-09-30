(reference "System.windows.Forms")
(using "System.Windows.Forms")

; Create a form
(= f (new "Form"))

; define a "click" event
(defevent Click f (sender e) (writeline console "Click on {0}, {1}" (X e) (Y e)))

; show the Form
(showdialog f)