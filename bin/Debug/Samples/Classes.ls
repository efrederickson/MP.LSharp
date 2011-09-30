;;; define a method for use in defclass
(defmethod "mname1" "arg" "(prl arg)")

;;; Create a class.
;;; you can specify multiple methods
(defclass "Class1" "object" mname1)

;;; Create an instance of "Class1"
(= c (new Class1))

;;; Run our method
(call mname1 c "HAI!")