;; Factorial

; the Factorial function
(defun fact(n) 
	(if (eql n 0) 1 (* n (fact (- n 1)))))

;; call it
(fact 5)