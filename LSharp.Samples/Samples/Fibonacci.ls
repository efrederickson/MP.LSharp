;;; Compute Fibonacci numbers

(defun fib (n)
     (if (eql n 0) 0
       (eql n 1) 1
       (+ (fib (- n 1)) (fib (- n 2)))))

;;; Print the first 15 Fibonacci numbers
(for i 0 15
     (prl (fib i)))

;;; Time how long it takes
;;; (time (fib 15))